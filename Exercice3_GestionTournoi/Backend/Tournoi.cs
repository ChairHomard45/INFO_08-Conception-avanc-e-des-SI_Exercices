namespace Exercice3_GestionTournoi.Backend
{
    public class Tournoi : IObservable<NotificationTournoi>, IObserver<NotificationChrono>, IObservable<NotificationChrono>
    {
        private string _nomTournoi = string.Empty;
        private readonly int _nbJoueursMinParEquipe = 3;
        private int _lastId = 0;
        private static readonly object Lock = new object();
        private readonly Dictionary<int,Equipe> _equipes = new ();
        private readonly Dictionary<int,Joueur> _joueurs = new ();
        private readonly Chronometre _chrono = new Chronometre();

        // Rendre Tournoi en Singleton
        private static Tournoi? _instance;
        private Tournoi()
        {
            // Chrono
            _chrono.Subscribe(this);
            Subscribe(_chrono);
        }

        public static Tournoi Instance
        {
            get
            {
                lock (Lock)
                {
                    return _instance ??= new Tournoi();
                }
            }
        }

        public void SetNomTournoi(string nom)
        {
            _nomTournoi = nom;
        }

        public string GetNomTournoi()
        {
            return _nomTournoi;
        }


        /// 
        /// Tournoi Observable Pour Forms
        /// 
        // Une liste des observateurs (observers) - ici les frames admin et joueur
        private readonly HashSet<IObserver<NotificationTournoi>> _observateurs = new();
        // Une liste des notifications
        private readonly HashSet<NotificationTournoi> _notifications = new();

        // Méthode qui permet d'ajouter un nouvel observateur (implémente la méthode Subscribe de l'interface IObservable)
        public IDisposable Subscribe(IObserver<NotificationTournoi> observateur)
        {
            // Si l'obervateur n'est pas encore dans la liste, on l'ajoute
            if (_observateurs.Add(observateur))
            {
                // On lui envoie les notifications
                foreach (var notification in _notifications)
                {
                    observateur.OnNext(notification);
                }
            }
            return new Unsubscriber<NotificationTournoi>(_observateurs, observateur);
        }


        internal sealed class Unsubscriber<TNotification> : IDisposable
        {
            private readonly ISet<IObserver<TNotification>> _observers;
            private readonly IObserver<TNotification> _observer;

            internal Unsubscriber(
                ISet<IObserver<TNotification>> observers,
                IObserver<TNotification> observer) => 
                (_observers, _observer) = 
                (observers, observer);

            public void Dispose() => _observers.Remove(_observer);
        }

        /// 
        ///  Chrono Old Impl
        /// 

        public void UpdateTime(NotificationTournoi notif)
        {
            foreach (var observateur in _observateurs)
            {
                observateur.OnNext(notif);
            }
        }

        public void StartInscription(TimeSpan duree)
        {
            foreach (var observateur in _observateurs)
            {
                NotificationTournoi notif = new NotificationTournoi { Type = NotificationTournoiType.InscriptBegin };
                observateur.OnNext(notif);
            }
            foreach (var observateur in _observateursChrono)
            {
                NotificationChrono notif = new NotificationChrono { Type = NotificationChronoType.InscriptBegin, delai = 1000, duree = duree };
                observateur.OnNext(notif);
            }
        }

        /// 
        /// Termine l'inscription par le bouton
        /// 
        public void StopInscriptionByButton()
        {
            List<Equipe> equipeNonValide = this.GetEquipes().FindAll(t => t.IsReady == false).ToList();

            foreach (Equipe equip in equipeNonValide)
            {
                foreach (Joueur j in equip.GetJoueurs())
                {
                    _joueurs.Remove(j.getId());
                }
                _equipes.Remove(equip.getId());
                foreach (var observateur in _observateurs)
                {
                    NotificationTournoi notif = new NotificationTournoi { Equipe = equip, Type = NotificationTournoiType.TeamRemoved };
                    observateur.OnNext(notif);
                }
            }
            NotifyObserverFormsOfEnd();
            NotifyObserverChronoOfEnd();
        }

        ///
        /// Termine l'inscription par le Chrono
        ///
        public void StopInscriptionByChrono()
        {
            List<Equipe> equipeNonValide = this.GetEquipes().FindAll(t => t.IsReady == false).ToList();

            foreach (Equipe equip in equipeNonValide)
            {
                foreach (Joueur j in equip.GetJoueurs())
                {
                    _joueurs.Remove(j.getId());
                }
                _equipes.Remove(equip.getId());
                foreach (var observateur in _observateurs)
                {
                    NotificationTournoi notif = new NotificationTournoi { Equipe = equip, Type = NotificationTournoiType.TeamRemoved };
                    observateur.OnNext(notif);
                }
            }
            NotifyObserverFormsOfEnd();
        }

        ///
        /// Sert a avertir les Forms de la fin de l'inscription
        /// 
        public void NotifyObserverFormsOfEnd()
        {
            foreach (var observateur in _observateurs)
            {
                NotificationTournoi notif = new NotificationTournoi { Type = NotificationTournoiType.InscriptEnd };
                observateur.OnNext(notif);
            }
        }

        ///
        /// Sert a avertir les Chrono que la fin a été déclencher par le bouton
        ///
        public void NotifyObserverChronoOfEnd()
        {
            foreach (var observateur in _observateursChrono)
            {
                NotificationChrono notif = new NotificationChrono { Type = NotificationChronoType.InscriptEnd };
                observateur.OnNext(notif);
            }
        }

        /// 
        /// Tournoi Observer Pour Chrono
        /// 
        private IDisposable? _cancellation;
        public virtual void Subscribe2(Chronometre provider)
        {
            _cancellation = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            _cancellation?.Dispose();
        }
        public void OnNext(NotificationChrono notification)
        {
            switch (notification.Type)
            {
                case NotificationChronoType.UpdateChrono:
                    UpdateTime(new NotificationTournoi { Type = NotificationTournoiType.UpdateChrono, tempsRestant = notification.tempsRestant });
                    break;
                case NotificationChronoType.InscriptEnd:
                    StopInscriptionByChrono();
                    break;

            }

        }
        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        /// 
        /// Tournoi Observable Pour Chrono
        ///

        // Une liste des observateurs (observers) - ici Chrono
        private readonly HashSet<IObserver<NotificationChrono>> _observateursChrono = new();
        private readonly HashSet<NotificationChrono> _notificationsChrono = new();

        // Méthode qui permet d'ajouter un nouvel observateur (implémente la méthode Subscribe de l'interface IObservable)
        public IDisposable Subscribe(IObserver<NotificationChrono> observateur)
        {
            // Si l'obervateur n'est pas encore dans la liste, on l'ajoute
            if (_observateursChrono.Add(observateur))
            {
                // On lui envoie les notifications
                foreach (var notification in _notificationsChrono)
                {
                    observateur.OnNext(notification);
                }
            }
            return new Unsubscriber<NotificationChrono>(_observateursChrono, observateur);
        }

        ///

        public bool IsUniquePseudo(string pseudo)
        {
            return !_joueurs.Values.Any(joueur => joueur.getPseudo() == pseudo);
        }

        public bool IsUniqueNomEquipe(string nomEquipe)
        {
            return !_equipes.Values.Any(equipe => equipe.getNomEquipe() == nomEquipe);
        }

        public bool IsEquipeComplete(int idEquipe)
        {
            if (_equipes[idEquipe].getNbJoueurs() >= _nbJoueursMinParEquipe)
            {
                _equipes[idEquipe].IsReady = true;

                ///////////// Notification que l'équipe est prète
                foreach (var observateur in _observateurs)
                {
                    NotificationTournoi notif = new NotificationTournoi { Equipe = _equipes[idEquipe], Type = NotificationTournoiType.TeamReady };
                    observateur.OnNext(notif);
                }

                return true;
            }
            return false;
        }

        public Joueur AddJoueur(string pseudo, int idEquipe)
        {
            lock (Lock)
            {
                _lastId++;
                Joueur joueur = new Joueur(_lastId, pseudo);
                _joueurs.Add(_lastId, joueur);
                _equipes[idEquipe].AddJoueur(joueur);

                ///////////// Notification de l'ajout d'un joueur dans une équipe
                foreach (var observateur in _observateurs)
                {
                    NotificationTournoi notif = new NotificationTournoi { Equipe = _equipes[idEquipe], Type = NotificationTournoiType.NewPlayer, Joueur = joueur };
                    observateur.OnNext(notif);
                }

                return joueur;
            }
        }

        public Equipe GetEquipe(int idEquipe)
        {
            return _equipes[idEquipe];
        }

        public Equipe? AddEquipe(string nomEquipe)
        {
            
            lock (Lock)
            {
                if (IsUniqueNomEquipe(nomEquipe))
                {
                    _lastId++;
                    Equipe equipe = new Equipe(_lastId, nomEquipe);
                    _equipes.Add(_lastId, equipe);

                    ///////////// Notification de l'ajout d'une équipe
                    foreach (var observateur in _observateurs)
                    {
                        NotificationTournoi notif = new NotificationTournoi { Equipe = equipe, Type = NotificationTournoiType.NewTeam};
                        observateur.OnNext(notif);
                    }

                    return equipe;
                }
                return null;
            }
        }

        public List<Equipe> GetEquipes()
        {
            return _equipes.Values.ToList();
        }

        public List<Joueur> GetJoueurs()
        {
            return _joueurs.Values.ToList();
        }
    }
}
