using Exercice3GestionTournoi.Backend;
using Exercice3GestionTournoi.Fontend;

namespace Exercice3GestionTournoi
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
            //
            AdminForm adminForm = new AdminForm();
            adminForm.Subscribe(Tournoi.Instance);
            adminForm.Show();

            //////
            JoueurForm joueurForm = new JoueurForm();
            joueurForm.Show();

            JoueurForm joueurForm2 = new JoueurForm();
            joueurForm2.Show();
        }


    }
}
