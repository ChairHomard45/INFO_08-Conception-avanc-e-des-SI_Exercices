using Exercice3_GestionTournoi.Backend;
using Exercice3_GestionTournoi.Fontend;

namespace Exercice3_GestionTournoi
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
