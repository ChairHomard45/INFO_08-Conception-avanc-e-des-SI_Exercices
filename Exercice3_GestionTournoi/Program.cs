using Exercice3_GestionTournoi.Backend;

namespace Exercice3_GestionTournoi
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