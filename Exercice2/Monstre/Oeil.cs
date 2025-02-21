using System.Drawing;

namespace Exercice2;

public class Oeil : ICloneable
{
  public float Diametre { get; set; }
  public Color Color { get; set; }


  public object Clone()
  {
    Oeil oeil = new Oeil();
    oeil.Diametre = Diametre;
    oeil.Color = Color;
    return oeil;
  }
}