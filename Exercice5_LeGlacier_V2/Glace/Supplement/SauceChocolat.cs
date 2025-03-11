namespace Exercice5_LeGlacier_V2.Glace.Supplement;

public class SauceChocolat : SupplementGlace
{
  public SauceChocolat(CoupeGlace coupe) : base(coupe)
  {
  }

  public override double Prix()
  {
    return Coupe.Prix() + 0.70;
  }

  public override string Description()
  {
    return Coupe.Description() + " avec supplément nappage chocolat";
  }
}