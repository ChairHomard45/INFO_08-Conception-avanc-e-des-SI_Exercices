using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Exercice3_GestionTournoi.Backend
{
    public class Chronometre : IObservable<NotificationChrono>, IObserver<NotificationChrono>
    {
        // System.Timers contient un Timer spécifique aux WinForms
        private System.Timers.Timer? Chrono;
        // Fréquence avec laquelle le Timer envoie le temps écoulé (en ms)
        private int Frequence = 1000;
        // Heure de début du chnronomètre
        private DateTime debut = DateTime.Now;
        // Durée du chronomètre en h, mn , sec
        private TimeSpan dureeChrono = new TimeSpan(0, 5, 0);
        // Temps restant avant la fin du chrono
        private TimeSpan tempsRestant = new TimeSpan(0, 5, 0);
        // Indique si le chrono est écoulé
        private bool isActif = true;

        public void Start(int delai, TimeSpan dureeChrono)
        {
            isActif = true;
            this.dureeChrono = dureeChrono;
            this.tempsRestant = dureeChrono;
            Frequence = delai;
            Chrono = new System.Timers.Timer(Frequence);
            //  Ajout d'un événement qui sera appelé toutes les Frequence ms
            Chrono.Elapsed += Tick;
            // Heure courante
            debut = DateTime.Now;
            // Démarrage du chrono
            Chrono.Enabled = true;
        }
        public void Start()
        {
            isActif = true;
            Chrono = new System.Timers.Timer(Frequence);
            Chrono.Elapsed += Tick;
            debut = DateTime.Now;
            Chrono.Enabled = true;
        }
        public void Stop()
        {
            if (Chrono != null)
            {
                Chrono.Enabled = false;
                Chrono.Stop();
            }
        }

        // Méthode appelée pour le Timer toutes les Frequence ms
        private void Tick(object? sender, ElapsedEventArgs e)
        {
            tempsRestant = dureeChrono - (e.SignalTime - debut);

            string tempsRestantString = String.Format("{0:00}:{1:00}:{2:00}", tempsRestant.Hours, tempsRestant.Minutes, tempsRestant.Seconds);
            Trace.WriteLine(tempsRestantString);

            NotifyObservers();

            if (Chrono != null && tempsRestant <= TimeSpan.Zero)
            {
                Chrono.Stop();
                Chrono.Enabled = false;
                Trace.WriteLine("Chrono arrêté");
                isActif = false;

                NotifyOfEnd();
            }

        }

        /// ! Observer Implémentation
        /// 

        // Une liste des observateurs (observers) - ici le Tournoi
        private readonly HashSet<IObserver<NotificationChrono>> _observateurs = new();
        // Une liste des notifications
        private readonly HashSet<NotificationChrono> _notifications = new();

        // Méthode qui permet d'ajouter un nouvel observateur (implémente la méthode Subscribe de l'interface IObservable)
        public IDisposable Subscribe(IObserver<NotificationChrono> observateur)
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
            return new Unsubscriber<NotificationChrono>(_observateurs, observateur);
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

        // Notify observers with the remaining time
        private void NotifyObservers()
        {
            NotificationChrono notif = new NotificationChrono { Type = NotificationChronoType.UpdateChrono, tempsRestant = tempsRestant };
            foreach (var observateur in _observateurs)
            {
                observateur.OnNext(notif);
            }
        }

        // Notify observers that the Chrono has ended
        private void NotifyOfEnd()
        {
            NotificationChrono notif = new NotificationChrono { Type = NotificationChronoType.InscriptEnd };
            foreach (var observateur in _observateurs)
            {
                observateur.OnNext(notif);
            }
        }

        /// ! Observable Implémentation
        private IDisposable? _cancellation;
        public virtual void Subscribe2(Tournoi provider)
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
                case NotificationChronoType.InscriptBegin:
                    if (notification.delai != null && notification.duree != null)
                    {
                        int delai = (int)notification.delai;
                        TimeSpan duree = (TimeSpan) notification.duree;
                        this.Start(delai, duree);
                    } 
                    else
                    {
                        this.Start();
                    }
                    break;
                case NotificationChronoType.InscriptEnd:
                    this.Stop();
                    break;
            }
        }
        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }
    }
}
