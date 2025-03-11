using Exercice5_LeGlacier_V2.Glace;
using Exercice5_LeGlacier_V2.Glace.Supplement;

namespace Exercice5_LeGlacier_V2;

public class Commande
{
  private static int _lastId;
  private static Dictionary<int, CoupeGlace> _coupesGlaces = new();
  private double _totalCommande;


  public void EnregistrerCommande()
  {
    int choice;
    string? c;
    CoupeGlace coupeGlace;
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

      if (choice == 1)
      {
        coupeGlace = TripleChocolat.Instance;
      }
      else
      {
        coupeGlace = FruitsRouges.Instance;
      }

      // Check supplement
      do
      {
        Console.WriteLine("Voulez-vous un supplement ? (o/n)");
        c = Console.ReadLine();
        if (c != "o" && c != "n")
        {
          Console.WriteLine("Valeur " + c + " n'est pas reconnue" );
        }
      } while (c != "o" && c != "n");
      
      // If o alors
      if (c == "o")
      {
        do
        {
          Console.WriteLine("Quel supplément voulez-vous rajouter ?");
          Console.WriteLine("0. Aucun");
          Console.WriteLine("1. De la Chantilly");
          Console.WriteLine("2. Un coulis de fraise fraîche");
          Console.WriteLine("3. Un nappage chocolat chaud");
          Console.WriteLine("Votre choix : ");
          try
          {
            choice = Convert.ToInt32(Console.ReadLine());
          }
          catch (FormatException e)
          {
            Console.WriteLine(e.Message);
            choice = -1;
          }

          switch (choice)
          {
            case 0:
              break;
            case 1:
              coupeGlace = new Chantilly(coupeGlace);
              break;
            case 2:
              coupeGlace = new CoulisFraise(coupeGlace);
              break;
            case 3:
              coupeGlace = new SauceChocolat(coupeGlace);
              break;
          }
          do
          {
            Console.WriteLine("Voulez-vous un autre supplement ? (o/n)");
            c = Console.ReadLine();
            if (c != "o" && c != "n")
            {
              Console.WriteLine("Valeur " + c + " n'est pas reconnue" );
            }
          } while (c != "o" && c != "n");
        } while (c != "n");
      }
      
      _lastId++; 
      _coupesGlaces.Add(_lastId, coupeGlace); 
      _totalCommande += coupeGlace.Prix();
      
      // Autre coupe de glace
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
      Console.WriteLine(coupeGlace.Value.Description());
      Console.WriteLine(coupeGlace.Value.Prix() + " Euros");
      Console.WriteLine();
    }

    Console.WriteLine();
    Console.WriteLine("POUR UN MONTANT DE : " + _totalCommande + " Euros");
  }
}