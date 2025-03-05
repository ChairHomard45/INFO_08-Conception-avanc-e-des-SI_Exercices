namespace Exercice4_ExpBool.ExpressionBool;

public class Variable : IExpressionBool
{
    private string _name;

    public Variable(string name)
    {
        _name = name;
    }

    public bool Evalue(Contexte context)
    {
       return context.GetValueAssociatedToVariable(this);
    }
}