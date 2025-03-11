using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice3_GestionTournoi.Backend
{
    public class Joueur
    {
        private int Id;
        private string Pseudo;

        public Joueur(int id, string pseudo)
        {
            Id = id;
            Pseudo = pseudo;
        }

        public int getId()
        {
            return Id;
        }

        public string getPseudo()
        {
            return Pseudo;
        }

        public string DisplayJoueur
        {
            get
            {
                return Id + " : " + Pseudo;
            }
        }
    }
}
