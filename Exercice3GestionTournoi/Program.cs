using Exercice3GestionTournoi.Backend;

namespace Exercice3GestionTournoi
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            //Seed.SeedData();

            Application.Run(new MainForm());
        }
    }
}