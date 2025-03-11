namespace Exercice5_LeGlacier_V2.Glace.Supplement;

public abstract class SupplementGlace : CoupeGlace
{
  protected readonly CoupeGlace Coupe;
  
  public SupplementGlace(CoupeGlace coupe) : base(coupe.Parfums)
  {
    Coupe = coupe;
  }
}