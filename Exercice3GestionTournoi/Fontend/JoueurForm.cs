using Exercice3GestionTournoi.Backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercice3GestionTournoi.Fontend
{
    public partial class JoueurForm : Form, IObserver<NotificationTournoi>
    {
        private Equipe? equipe = null;
        private bool IsEquipeComplete = false;
        ////// Ajouter par Clément
        private Tournoi tournoi;
        //////
        public JoueurForm(/*Tournoi tournoi*/)
        {
            InitializeComponent();
            ////// Ajouter par Clément
            //this.tournoi = tournoi;

            this.tournoi = Tournoi.Instance;
            //////
        }

        private void textNomEquipe_TextChanged(object sender, EventArgs e)
        {
            bool isUnique = false;
            //////// Your code
            //////// Ecrire le code pour vérifier que le nom de l'équipe est bien unique

            isUnique = tournoi.IsUniqueNomEquipe(textNomEquipe.Text);

            //////////
            if (!isUnique)
            {
                labelErreurNomEquipe.ForeColor = Color.Red;
                labelErreurNomEquipe.Text = "Ce nom d'équipe est déjà pris";
                boutonJouer.Enabled = false;
            }
            else
            {
                labelErreurNomEquipe.ForeColor = Color.Green;
                labelErreurNomEquipe.Text = "Nom d'équipe disponible";
                boutonJouer.Enabled = true;
            }
        }

        private void textPseudo_TextChanged(object sender, EventArgs e)
        {
            bool isUnique = false;
            //////// Your code
            //////// Ecrire le code pour vérifier que le nom du membre est bien unique

            isUnique = tournoi.IsUniquePseudo(textPseudo.Text);

            //////////
            if (!isUnique)
            {
                labelErreurPseudo.ForeColor = Color.Red;
                labelErreurPseudo.Text = "Ce pseudo est déjà pris";
            }
            else
            {
                labelErreurPseudo.ForeColor = Color.Green;
                labelErreurPseudo.Text = "Pseudo disponible";
            }
        }
        private void AjouterEquipe()
        {
            //////// Your code
            //////// Ecrire le code pour rajouter l'équipe en backend et récupérer l'équipe avec son Id

            if (tournoi.IsUniqueNomEquipe(textNomEquipe.Text)) {
                equipe = tournoi.AddEquipe(textNomEquipe.Text);
            }
               

            //////////
            if (equipe == null)
            {
                labelErreurNomEquipe.ForeColor = Color.Red;
                labelErreurNomEquipe.Text = "Création de l'équipe impossible!!";
            }
            else
            {
                {
                    labelErreurNomEquipe.ForeColor = Color.Green;
                    labelErreurNomEquipe.Text = "Equipe numéro " + equipe.getId() + " créée!!";
                    labelErreur.ForeColor = Color.Red;
                    labelErreur.Text = "Rajoutez les membres de votre équipe pour jouer!";
                    textNomEquipe.Enabled = false;
                    labelErreurPseudo.Visible = true;
                    labelPseudo.Visible = true;
                    LabelMembres.Visible = true;
                    textPseudo.Visible = true;
                    buttonAjouter.Visible = true;
                    listMembresEquipe.Items.Clear();
                    listMembresEquipe.Visible = true;
                    boutonJouer.Text = "Jouer";
                }
            }
        }

        private void buttonAjouterJoueur_Click(object sender, EventArgs e)
        {
            bool isUnique = false;
            //////// Your code
            //////// Ecrire le code pour vérifier que le pseudo du joueur est bien unique

            isUnique = tournoi.IsUniquePseudo(textPseudo.Text);

            //////////
            if (!isUnique)
            {
                labelErreurPseudo.ForeColor = Color.Red;
                labelErreurPseudo.Text = "Ce pseudo est déjà pris";
            }
            if (equipe != null && textPseudo.Text != "" && isUnique)
            {
                Joueur? joueur = null;
                //////// Your code
                //////// Ecrire le code pour ajouter un joueur en back et récupérer l'équipe modifiée

                joueur = tournoi.AddJoueur(textPseudo.Text, equipe.getId());
                equipe = tournoi.GetEquipe(equipe.getId());

                ////////
                if (joueur == null)
                {
                    labelErreurPseudo.ForeColor = Color.Red;
                    labelErreurPseudo.Text = "Impossible de rajouter " + textPseudo.Text + " à l'équipe";
                }
                else
                {
                    labelErreurPseudo.ForeColor = Color.Green;
                    labelErreurPseudo.Text = textPseudo.Text + " rajouté à l'équipe";
                    textPseudo.Text = "";
                    listMembresEquipe.Items.Clear();
                    Joueur[]? joueurs = null;
                    //////// Your  code
                    //////// Récupérer la liste des joueurs et la transformer en tableau

                    joueurs = equipe.GetJoueurs().ToArray();

                    ////////
                    if (joueurs != null) listMembresEquipe.Items.AddRange(joueurs);
                    // Pour pouvoir afficher les informations du joueur et pas sa référence objet
                    // Créez une méthode DisplayJoueur dans la classe joueur
                    listMembresEquipe.DisplayMember = "DisplayJoueur";

                    //////// Your  code
                    //////// Vérifiez si l'équipe est complète

                    IsEquipeComplete = tournoi.IsEquipeComplete(equipe.getId());

                    ////////
                    if (IsEquipeComplete)
                    {
                        labelErreur.ForeColor = Color.Green;
                        labelErreur.Text = "Equipe complète, attendez la fin de la phase d'inscription";
                    }
                }
            }
        }
        private void boutonJouer_Click(object sender, EventArgs e)
        {
            if (equipe == null)
            {
                AjouterEquipe();
            }
            else if (equipe != null && !IsEquipeComplete)
            {
                labelErreur.ForeColor = Color.Red;
                labelErreur.Text = "Composition de l'équipe invalide. Impossible de lancer la partie!!";
            }
            else if (equipe != null && IsEquipeComplete)
            {
                // Equipe prête
                this.Hide();

            }
        }

        private void JoueurForm_Load(object sender, EventArgs e)
        {
            labelErreur.ForeColor = Color.Black;
            labelErreur.Text = "Saisissez le nom de l'équipe";
            textNomEquipe.Enabled = false;

            Subscribe(tournoi);
        }

        private void JoueurForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (tournoi != null)
            {
                Unsubscribe();
            }
        }


        /// ! Observer Implémentation

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
                case NotificationTournoiType.InscriptBegin:
                    InscriptionBegin();
                    break;
                case NotificationTournoiType.InscriptEnd:
                    InscriptionEnd();
                    break;

            }
               
        }
        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        // Custom fonction:
        private void InscriptionBegin()
        {
            labelErreur.ForeColor = Color.LimeGreen;
            labelErreur.Text = "La phase d'inscription a commencer!";
            labelErreurNomEquipe.ForeColor = Color.Black;
            labelErreurNomEquipe.Text = "Saisissez le nom de votre équipe";

            textNomEquipe.Enabled = true;
            boutonJouer.Visible = true;

        }
        private void InscriptionEnd()
        {
            labelErreur.ForeColor = Color.Red;
            labelErreur.Text = "La phase d'inscription est terminée !";
            textNomEquipe.Text = "";
            labelErreurNomEquipe.ForeColor = Color.Black;
            labelErreurNomEquipe.Text = "";
            equipe = null;

            textNomEquipe.Enabled = false;
            labelErreurPseudo.Visible = false;
            labelPseudo.Visible = false;
            LabelMembres.Visible = false;
            textPseudo.Visible = false;
            buttonAjouter.Visible = false;
            listMembresEquipe.Items.Clear();
            listMembresEquipe.Visible = false;
            boutonJouer.Visible = false;
        }


    }
}
