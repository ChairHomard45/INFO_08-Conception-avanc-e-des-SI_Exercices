using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exercice3_GestionTournoi.Backend;

namespace Exercice3_GestionTournoi.Fontend
{
    public partial class AdminForm : Form, IObserver<NotificationTournoi>
    {
        private bool competitionBegin = false;
        private int timerD = 0;

        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            refreshForm();
        }

        private void buttonDemarrerCompetition_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Equipe[]? GetEquipes(bool isInscrite)
        {
            return Tournoi.Instance.GetEquipes().FindAll(t => t.IsReady == isInscrite).ToArray();
        }

        private void refreshForm()
        {
            textNomTournoi.Text = Tournoi.Instance.GetNomTournoi();
            listEquipesInscrites.Items.Clear();
            listEquipesInscrites.Items.AddRange(GetEquipes(true));
            listEquipesInscrites.DisplayMember = "DisplayEquipe";
            listEquipesEnCours.Items.Clear();
            listEquipesEnCours.Items.AddRange(GetEquipes(false));
            listEquipesEnCours.DisplayMember = "DisplayEquipe";
            listJoueursInscrits.Items.Clear();
            listJoueursInscrits.Items.AddRange(Tournoi.Instance.GetJoueurs().ToArray());
            listJoueursInscrits.DisplayMember = "DisplayJoueur";
        }

        private void boutonDemarrer_MouseClick(object sender, MouseEventArgs e)
        {
            if (!competitionBegin)
            {
                boutonDemarrer.BackColor = Color.Red;
                boutonDemarrer.Text = "Arrêter la phase d'inscription";


                if (timerD == 0)
                {
                    Tournoi.Instance.StartInscription(new TimeSpan(0, 5, 0));
                }
                else
                {
                    TimeSpan duration = new TimeSpan(0, timerD, 0);
                    Tournoi.Instance.StartInscription(duration);
                }

                competitionBegin = true;
            }
            else
            {
                boutonDemarrer.BackColor = Color.LimeGreen;
                boutonDemarrer.Text = "Démarrer la phase d'inscription";
                Tournoi.Instance.StopInscriptionByButton();
                competitionBegin = false;
            }
        }

        private void numericTime_ValueChanged(object sender, EventArgs e)
        {
            if (numericTime.Value > 0 && numericTime.Value < 59)
            {
                timerD = ((int)numericTime.Value);
                labelChrono.Text = string.Format("{0:D2}:00", timerD);
                labelErreur.Text = "";
            }
            else
            {
                labelErreur.ForeColor = Color.Red;
                labelErreur.Text = "Le nombre doit être entre 1 et 58";
            }
        }

        private void labelChrono_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Observer on Tournoi
        /// </summary>
        /// 

        private IDisposable? _cancellation;
        public virtual void Subscribe(Tournoi provider) => _cancellation = provider.Subscribe(this);
        public virtual void Unsubscribe()
        {
            _cancellation?.Dispose();
        }
        public void OnNext(NotificationTournoi notification)
        {
            switch (notification.Type)
            {
                case NotificationTournoiType.NewTeam:
                    richTextBox.Text += "\n" + DateTime.Now + " - Ajout de l'équipe " + notification.Equipe.DisplayEquipe;
                    break;
                case NotificationTournoiType.NewPlayer:
                    richTextBox.Text += "\n" + DateTime.Now + " - Ajout du joueur " + notification.Joueur.DisplayJoueur + " dans l'équipe  " + notification.Equipe.DisplayEquipe;
                    break;
                case NotificationTournoiType.TeamReady:
                    richTextBox.Text += "\n" + DateTime.Now + " - Equipe  " + notification.Equipe.DisplayEquipe + " prête à jouer";
                    break;
                case NotificationTournoiType.InscriptBegin:
                    richTextBox.Text += "\n" + DateTime.Now + " - Début de la phase d'inscription.";
                    break;
                case NotificationTournoiType.InscriptEnd:
                    richTextBox.Text += "\n" + DateTime.Now + " - Fin de la phase d'inscription. Le tournoi peut commencer !";
                    competitionBegin = true;
                    labelChrono.Text = "05:00";
                    boutonDemarrer.BackColor = Color.LimeGreen;
                    boutonDemarrer.Text = "Démarrer la phase d'inscription";
                    break;
                case NotificationTournoiType.UpdateChrono:
                    labelChrono.Text = notification.tempsRestant.Value.ToString(@"mm\:ss");
                    break;

            }

            refreshForm();

        }
        public void OnCompleted()
        {
        }
        public void OnError(Exception error)
        {
        }

    }
}
