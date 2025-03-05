using Exercice5_LeGlacier.Glace;

namespace Exercice5_LeGlacier;

public class Commande
{
    private static int _lastId = 0;
    private static Dictionary<int,CoupeGlace> _coupesGlaces = new();
    private double _totalCommande = 0;


    public void EnregistrerCommande()
    {
        Console.WriteLine("Quel coupe de glace voulez-vous?");
        Console.WriteLine("         1. Triple chocolat");
        Console.WriteLine("         2. Fruits Rouges");
        Console.WriteLine("Votre choix (1 ou 2) : ");
        int choice = Convert.ToInt32(Console.ReadLine());
        
        switch (choice)
        {
            case 1:
                _lastId++;
                _coupesGlaces.Add(_lastId,TripleChocolat.Instance);
                _totalCommande += TripleChocolat.Instance.Prix();
                break;
            case 2:
                _lastId++;
                _coupesGlaces.Add(_lastId,FruitsRouges.Instance);
                _totalCommande += FruitsRouges.Instance.Prix();
                break;
        }
        
    }
    
    public void AfficherCommande()
    {
        foreach (KeyValuePair<int, CoupeGlace> coupeGlace in _coupesGlaces)
        {
            Console.WriteLine("******************************************");
            Console.WriteLine("Coupe numéro : " + coupeGlace.Key);
            coupeGlace.Value.Description();
            Console.WriteLine(coupeGlace.Value.Prix() + " Euros");
        }
        Console.WriteLine();
        Console.WriteLine("POUR UN MONTANT DE : " + _totalCommande  + " Euros");
    }
}