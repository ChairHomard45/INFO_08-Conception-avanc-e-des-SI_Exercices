namespace Exercice4_ExpBool.ExpressionBool.ExpBool;

public class ExpEt : ExpBool
{
    public ExpEt(IExpressionBool gauche, IExpressionBool droite) : base(gauche, droite)
    { }
    
    public override bool Evalue(Contexte context)
    {
        return Gauche.Evalue(context) && Droite.Evalue(context);
    }
}