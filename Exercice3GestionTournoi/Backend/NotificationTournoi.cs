using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice3GestionTournoi.Backend
{
    public readonly record struct NotificationTournoi(NotificationTournoiType Type, Equipe? Equipe, Joueur? Joueur, TimeSpan? tempsRestant);

    public enum NotificationTournoiType
    {
        NewTeam, NewPlayer, TeamReady, TeamRemoved, InscriptBegin, InscriptEnd, UpdateChrono
    }
}
