namespace Exercice5_LeGlacier_V1.Glace;

public class TripleChocolat : CoupeGlace
{
    private static TripleChocolat? _instance;
    private static readonly object Lock = new();

    public TripleChocolat() : base([Parfum.Chocoblanc, Parfum.Choconoir, Parfum.Chocolait])
    {
    }

    public static TripleChocolat Instance
    {
        get
        {
            lock (Lock)
            {
                return _instance ??= new TripleChocolat();
            }
        }
    }


    public override double Prix()
    {
        return 3.00;
    }

    public override void Description()
    {
        Console.Write("Coupe triple chocolat parfums : ");
        foreach (Parfum parf in Parfums)
        {
            Console.Write(parf + " - ");
        }
        Console.WriteLine();
    }
}