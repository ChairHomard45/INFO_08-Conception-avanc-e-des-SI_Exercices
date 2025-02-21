namespace Exercice2;

public class Nageoire : ICloneable
{
  public float _Longueur { get; set; }
  public TypeNageoire _TypeNageoire { get; set; }

  public object Clone()
  {
    Nageoire nageoire = new Nageoire();
    nageoire._Longueur = _Longueur;
    nageoire._TypeNageoire = _TypeNageoire;
    return nageoire;
  }
}