namespace Exercice5_LeGlacier_V2.Glace;

public class FruitsRouges : CoupeGlace
{
    private static FruitsRouges? _instance;
    private static readonly object Lock = new();

    public static FruitsRouges Instance
    {
        get
        {
            lock (Lock)
            {
                return _instance ??= new FruitsRouges();
            }
        }
    }

    private FruitsRouges() : base([Parfum.Cassis, Parfum.Framboise, Parfum.Fraise])
    {
    }
    public override double Prix()
    {
        return 5.50;
    }

    public override string Description()
    {
        string message = "Coupe fruit rouges parfums : ";
        foreach (Parfum parf in Parfums)
        {
            message += parf + " - ";
        }
        return message;
    }
}