using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice3GestionTournoi.Backend
{
    public class Tournoi : IObservable<NotificationTournoi>
    {
        public string NomTournoi = string.Empty;
        public int NbJoueursMinParEquipe = 3;
        private int _lastId = 0;
        private static readonly object Lock = new object();
        private Dictionary<int,Equipe> _equipes = new Dictionary<int, Equipe>();
        private Dictionary<int,Joueur> _joueurs = new Dictionary<int, Joueur>();

        // Rendre Tournoi en Singleton
        private static Tournoi? _instance;
        private Tournoi()
        {

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

        internal sealed class Unsubscriber<Notification> : IDisposable
        {
            private readonly ISet<IObserver<Notification>> _observers;
            private readonly IObserver<Notification> _observer;

            internal Unsubscriber(
                ISet<IObserver<Notification>> observers,
                IObserver<Notification> observer) => 
                (_observers, _observer) = 
                (observers, observer);

            public void Dispose() => _observers.Remove(_observer);
        }
        /// 
        ///  Chrono
        /// 
        public Chronometre chrono = new Chronometre();

        public void updateTime(NotificationTournoi notif)
        {
            foreach (var observateur in _observateurs)
            {
                observateur.OnNext(notif);
            }
        }

        public void startInscription(TimeSpan duree)
        {
            foreach (var observateur in _observateurs)
            {
                NotificationTournoi notif = new NotificationTournoi { Type = NotificationTournoiType.InscriptBegin };
                observateur.OnNext(notif);
            }
            chrono.Start(1000,duree);
        }
        public void stopInscription()
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
            foreach (var observateur in _observateurs)
            {
                NotificationTournoi notif = new NotificationTournoi { Type = NotificationTournoiType.InscriptEnd };
                observateur.OnNext(notif);
            }

            chrono.Stop();
        }

        //

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
            if (_equipes[idEquipe].getNbJoueurs() >= NbJoueursMinParEquipe)
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

        public Equipe AddEquipe(string nomEquipe)
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
