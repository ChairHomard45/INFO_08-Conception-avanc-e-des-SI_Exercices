namespace Exercice5_LeGlacier_V2.Glace.Supplement;

public class CoulisFraise : SupplementGlace
{
  public CoulisFraise(CoupeGlace coupe) : base(coupe)
  {
  }

  public override double Prix()
  {
    return Coupe.Prix() + 1.00;
  }

  public override string Description()
  {
    return Coupe.Description() + " avec son coulis de fraises fraîches";
  }
}