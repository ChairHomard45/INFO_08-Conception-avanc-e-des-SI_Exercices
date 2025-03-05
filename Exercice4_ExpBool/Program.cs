using Exercice4_ExpBool.ExpressionBool;
using Exercice4_ExpBool.ExpressionBool.ExpBool;

namespace Exercice4_ExpBool;

class Program
{
  public static void Main(String[] args)
  {
    ExpBool expression;

    Contexte contexte=new Contexte();

    Variable x = new Variable("X");// crée la variable X

    Variable y = new Variable("Y"); // crée la variable Y

    // construction de 1' expression booléenne
    // "(x et non y) ou (y et vrai)" avec x = faux et y = vrai
    expression = new ExpOu(new ExpEt(x, (new ExpNon(y))), new ExpEt(y, new Constante(true)));


    contexte.Assignee(x, false); // X vaut Faux

    contexte.Assignee(y, true); // Y vaut Vrai

    // L'expression s'évalue

    bool resultat = expression.Evalue(contexte);
    Console.WriteLine("Resultat : " + resultat);
  }
}