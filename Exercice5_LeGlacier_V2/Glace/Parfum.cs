namespace Exercice5_LeGlacier_V2.Glace;

public class Parfum
{
    private string _nom;
    public static Parfum Cassis = new Parfum("Cassis");
    public static Parfum Chocoblanc = new Parfum("Chocolat blanc");
    public static Parfum Chocolait = new Parfum("Chocolat au lait");
    public static Parfum Choconoir = new Parfum("Chocolat noir");
    public static Parfum Fraise = new Parfum("Fraise");
    public static Parfum Framboise= new Parfum("Framboise");

    private Parfum(string name)
    {
        _nom = name;
    }
    
    public override string ToString()
    {
        return _nom;
    }
}