namespace Exercice5_LeGlacier.Glace;

public abstract class CoupeGlace
{
    protected readonly List<Parfum> Parfums;

    protected CoupeGlace(List<Parfum> parfums)
    {
        Parfums = parfums;
    }

    public abstract double Prix();
    
    public abstract void Description();
}