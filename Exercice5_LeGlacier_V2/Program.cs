namespace Exercice5_LeGlacier_V2;

class Program
{
    public static void Main(String[] args)
    {
        Commande commande = new Commande();
        commande.EnregistrerCommande();
        commande.AfficherCommande();
    }
}