namespace Exercice5_LeGlacier_V2.Glace;

public abstract class CoupeGlace
{
    protected internal readonly List<Parfum> Parfums;

    protected CoupeGlace(List<Parfum> parfums)
    {
        Parfums = parfums;
    }
    
    public abstract double Prix();
    
    public abstract string Description();
}