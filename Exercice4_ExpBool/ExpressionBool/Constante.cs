namespace Exercice4_ExpBool.ExpressionBool;

public class Constante : IExpressionBool
{
    private readonly bool _value;

    public Constante(bool value)
    {
        _value = value;
    }
    
    public bool Evalue(Contexte context)
    {
        return _value;
    }
}