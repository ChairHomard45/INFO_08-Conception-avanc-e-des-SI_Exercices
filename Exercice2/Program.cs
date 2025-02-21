
using System.Drawing;
using Exercice2;

class Program
{
  public static void Main(String[] args)
  {
    List<Oeil> yeux = new List<Oeil>
    {
      new Oeil { Color = Color.Aquamarine, Diametre = 3 },
      new Oeil { Color = Color.Azure, Diametre = 34 },
      new Oeil { Color = Color.Brown, Diametre = 1 },
    };
    List<Nageoire> nageoires = new List<Nageoire>
    {
      new Nageoire { _TypeNageoire = TypeNageoire.Codale, _Longueur = 2 },
      new Nageoire { _TypeNageoire = TypeNageoire.Pectoral, _Longueur = 5 },
      new Nageoire { _TypeNageoire = TypeNageoire.Pelvienne, _Longueur = 12 },
    };
    MonstreMarin monstreMarin1 = new MonstreMarin
      { _Nom = "ZirVak", _TypeEau = 2, _Nageoire = nageoires, _Yeux = yeux };
    // On veut créer un deuxième monstre, identique au premier mais sans créer de problème d'alias
    MonstreMarin monstreMarin2 = (MonstreMarin)monstreMarin1.Clone();
    Console.WriteLine("");
    Console.WriteLine("");
    // Modifions le second monstre pour vérifier que les deux monstres sont bien distincts
    monstreMarin2._Nom = "Nestor";
    monstreMarin2._Yeux[0].Color=Color.Gold;
    monstreMarin2._Yeux[0].Diametre = 50;
    monstreMarin2._TypeEau = 1;
    monstreMarin2._Nageoire[0]._TypeNageoire = TypeNageoire.Dorsal;
    monstreMarin2._Nageoire[0]._Longueur = 100;
    Afficher(monstreMarin1,monstreMarin2);
  }

  private static void Afficher(MonstreMarin m1, MonstreMarin m2)
  {
    Console.WriteLine("\t\t\tmonstreMarin1\tmonstreMarin2");
    Console.WriteLine("__ Attributs de Monstre");
    Console.WriteLine("Nom\t\t\t" + m1._Nom + "\t\t" + m2._Nom);
    Console.WriteLine("** Oeil");
    Console.WriteLine("Couleur Oeil\t\t" + m1._Yeux[0].Color + "\t" + m2._Yeux[0].Color);
    Console.WriteLine("Diamètre Oeil\t\t" + m1._Yeux[0].Diametre + "\t\t" + m2._Yeux[0].Diametre);
    Console.WriteLine("__ Attributs de Monstre marin");
    Console.WriteLine("TypeEau\t\t\t" + m1._TypeEau + "\t\t" + m2._TypeEau);
    Console.WriteLine("** Nageoire");
    Console.WriteLine("Longueur Nageoire\t" + m1._Nageoire[0]._Longueur + "\t\t" + m2._Nageoire[0]._Longueur);
    Console.WriteLine("Type Nageoire\t\t" + m1._Nageoire[0]._TypeNageoire + "\t\t" + m2._Nageoire[0]._TypeNageoire);

  }
}