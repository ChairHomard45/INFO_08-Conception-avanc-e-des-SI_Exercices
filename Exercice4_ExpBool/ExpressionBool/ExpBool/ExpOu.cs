namespace Exercice4_ExpBool.ExpressionBool.ExpBool;

public class ExpOu : ExpBool
{
    public ExpOu(IExpressionBool gauche, IExpressionBool droite) : base(gauche, droite)
    { }
    
    public override bool Evalue(Contexte context)
    {
        return Gauche.Evalue(context) || Droite.Evalue(context);
    }
}