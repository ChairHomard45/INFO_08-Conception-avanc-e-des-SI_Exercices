using Exercice5_LeGlacier_V1.Glace;

namespace Exercice5_LeGlacier_V1;

public class Commande
{
  private static int _lastId;
  private static Dictionary<int, CoupeGlace> _coupesGlaces = new();
  private double _totalCommande;


  public void EnregistrerCommande()
  {
    int choice;
    string? c;
    do
    {
      do
      {
        Console.WriteLine("Quel coupe de glace voulez-vous?");
        Console.WriteLine("         1. Triple chocolat");
        Console.WriteLine("         2. Fruits Rouges");
        Console.WriteLine("Votre choix (1 ou 2) : ");
        try
        {
          choice = Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException e)
        {
          Console.WriteLine(e.Message);
          choice = 0;
        }
      } while (choice != 1 && choice != 2);

      switch (choice)
      {
        case 1:
          _lastId++;
          _coupesGlaces.Add(_lastId, TripleChocolat.Instance);
          _totalCommande += TripleChocolat.Instance.Prix();
          break;
        case 2:
          _lastId++;
          _coupesGlaces.Add(_lastId, FruitsRouges.Instance);
          _totalCommande += FruitsRouges.Instance.Prix();
          break;
      }

      do
      {
        Console.WriteLine("Voulez-vous une autre coupe glacée? (o ou n)");
        c = Console.ReadLine();
        if (c != "o" && c != "n")
        {
          Console.WriteLine("Valeur " + c + " n'est pas reconnue" );
        }
      } while (c != "o" && c != "n");
    } while (c != "n");
  }

  public void AfficherCommande()
  {
    foreach (KeyValuePair<int, CoupeGlace> coupeGlace in _coupesGlaces)
    {
      Console.WriteLine("******************************************");
      Console.WriteLine("Coupe numéro : " + coupeGlace.Key);
      coupeGlace.Value.Description();
      Console.WriteLine(coupeGlace.Value.Prix() + " Euros");
      Console.WriteLine();
    }

    Console.WriteLine();
    Console.WriteLine("POUR UN MONTANT DE : " + _totalCommande + " Euros");
  }
}