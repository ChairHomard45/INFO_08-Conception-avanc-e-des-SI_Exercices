namespace Program;

public class Salle
{
  private string _numero;
  private List<Mur> _murs = new List<Mur>();

  public Salle(string numero)
  {
    _numero = numero;
  }

  public void AjouterMur(Mur mur)
  {
    _murs.Add(mur);
  }
}