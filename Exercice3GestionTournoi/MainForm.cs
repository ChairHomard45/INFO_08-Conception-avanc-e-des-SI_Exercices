using Exercice3GestionTournoi.Backend;
using Exercice3GestionTournoi.Fontend;

namespace Exercice3GestionTournoi
{
    public partial class MainForm : Form
    {
        private Tournoi tournoi;
        public MainForm()
        {
            InitializeComponent();
            ////// Ajouter par Clement
            tournoi = Tournoi.Instance;
            tournoi.NomTournoi = "Tournoi intergallactique";

            AdminForm adminForm = new AdminForm();
            adminForm.Subscribe(Tournoi.Instance);
            adminForm.Show();

            //////
            JoueurForm joueurForm = new JoueurForm();
            joueurForm.Show();
        }


    }
}
