namespace Exercice2;

public class MonstreMarin : Monstre, ICloneable
{
  public int _TypeEau { get; set; }
  public List<Nageoire> _Nageoire = new List<Nageoire>();
  
  /*
  public MonstreMarin Clone()
  {
    return (MonstreMarin)MemberwiseClone();
  }
  */
  public new object Clone()
  {
    MonstreMarin newMonstreMarin = (MonstreMarin) base.Clone();
    newMonstreMarin._Nageoire = new List<Nageoire>();
    newMonstreMarin._TypeEau = _TypeEau;
    foreach (Nageoire nageoire in _Nageoire)
    {
      newMonstreMarin._Nageoire.Add((Nageoire) nageoire.Clone());
    }
    return newMonstreMarin;
  }
}