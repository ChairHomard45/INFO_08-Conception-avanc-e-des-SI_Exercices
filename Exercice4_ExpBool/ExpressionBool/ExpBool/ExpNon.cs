﻿namespace Exercice4_ExpBool.ExpressionBool.ExpBool;

public class ExpNon : ExpBool
{
    public ExpNon(IExpressionBool gauche) : base(gauche)
    { }
    
    public override bool Evalue(Contexte context)
    {
        return !Gauche.Evalue(context);
    }
}