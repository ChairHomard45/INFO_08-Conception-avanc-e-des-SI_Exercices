using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice3GestionTournoi.Backend
{
    public class Equipe 
    {
        private int Id;
        private string NomEquipe;
        public bool IsReady;
        private List<Joueur> _joueurs ;

        public Equipe(int id, string nom)
        {
            Id = id;
            NomEquipe = nom;
            IsReady = false;
            _joueurs = new List<Joueur>();
        }
       public int getId()
        {
            return Id;
        }

        public string getNomEquipe()
        {
            return NomEquipe;
        }

        public List<Joueur> GetJoueurs()
        {
            return _joueurs.ToList();
        }

        public int getNbJoueurs()
        {
            return _joueurs.Count;
        }

        public void AddJoueur(Joueur j)
        {
            _joueurs.Add(j);
        }

        public string DisplayEquipe
        {
            get
            {
                return Id + " : " + NomEquipe + " - Nombre de joueurs : " + _joueurs.Count;
            }
        }
    }
}
