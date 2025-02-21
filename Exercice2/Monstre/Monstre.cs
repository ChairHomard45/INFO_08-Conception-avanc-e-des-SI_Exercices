namespace Exercice2;

public class Monstre : ICloneable
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
    Monstre newMonstre = new Monstre();
    newMonstre._Yeux = new List<Oeil>();
    newMonstre._Nom = _Nom;
    foreach (Oeil oeil in _Yeux)
    {
      newMonstre._Yeux.Add((Oeil) oeil.Clone());
    }
    return newMonstre;
  }
}