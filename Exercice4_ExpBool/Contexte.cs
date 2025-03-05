using Exercice4_ExpBool.ExpressionBool;

namespace Exercice4_ExpBool;

public class Contexte
{
    private readonly Dictionary<Variable, bool> _listVariable = new Dictionary<Variable, bool>();

    public void Assignee(Variable variable, bool value)
    {
        _listVariable.Add(variable, value);
    }

    public bool GetValueAssociatedToVariable(Variable variable)
    {
        return _listVariable[variable];
    }
}