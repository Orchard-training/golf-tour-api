using GolfCourse.Entity;
using System.Collections.Generic;

namespace GolfCourse.Repositories
{
    public interface ITournamentRepo
    {
        void AddTournament(Tournament tournament);
        List<Tournament> GetTournaments();
        List<Tournament> GetTournamentsWithPrize();
        List<Player> GetPlayersInTournament(int id);
        // Added Update Functionality as per the  Change Request
        bool UpdateTournamentPrize(int tourId, Tournament tournament);
    }
}