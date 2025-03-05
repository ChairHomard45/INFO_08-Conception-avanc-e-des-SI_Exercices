namespace Exercice2;

public abstract class Monstre : ICloneable
{
  public string _Nom { get; set; }
  public List<Oeil> _Yeux = new List<Oeil>();
  
  /*
  public Monstre Clone()
  {
    return (Monstre)MemberwiseClone();
  }
  */
  // Solution Proposer

  public object Clone()
  {
    Monstre newMonstre = (Monstre) MemberwiseClone();
    newMonstre._Yeux = new List<Oeil>();
    foreach (Oeil oeil in _Yeux)
    {
      newMonstre._Yeux.Add((Oeil) oeil.Clone());
    }
    return newMonstre;
  }
}