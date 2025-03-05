namespace Exercice5_LeGlacier.Glace;

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

    public override void Description()
    {
        Console.Write("Coupe fruits rouges parfums : ");
        foreach (Parfum parf in Parfums)
        {
            Console.Write(parf + " - ");
        }
    }
}