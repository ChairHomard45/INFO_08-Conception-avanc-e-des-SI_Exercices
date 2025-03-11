namespace Exercice5_LeGlacier_V2.Glace.Supplement;

public class Chantilly : SupplementGlace
{
  public Chantilly(CoupeGlace coupe) : base(coupe)
  {
  }

  public override double Prix()
  {
    return Coupe.Prix() + 0.50;
  }

  public override string Description()
  {
    return Coupe.Description() + " avec supplément chantilly";
  }
}