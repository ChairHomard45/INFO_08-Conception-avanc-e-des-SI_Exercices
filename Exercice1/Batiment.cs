namespace Program;

public class Batiment
{
  private string _nom;
  private List<Salle> _salles = new List<Salle>();
  private List<Mur> _murs = new List<Mur>();
  private Personne _gardien;

  public void AjouterSalle(string nom)
  {
    Salle salle = new Salle(nom);
    _salles.Add(salle);
  }

  public void AffecterGardien(Personne gardien)
  {
    _gardien = gardien;
  }
}