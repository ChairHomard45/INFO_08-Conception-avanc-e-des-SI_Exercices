namespace Exercice4_ExpBool.ExpressionBool.ExpBool;

public abstract class ExpBool : IExpressionBool
{
    protected readonly IExpressionBool Gauche;
    protected readonly IExpressionBool Droite;

    public ExpBool(IExpressionBool gauche, IExpressionBool droite)
    {
        Gauche = gauche;
        Droite = droite;
    }
    
    public ExpBool(IExpressionBool gauche)
    {
        Gauche = gauche;
        Droite = gauche;
    }

    public abstract bool Evalue(Contexte context);
}