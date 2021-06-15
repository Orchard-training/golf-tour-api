using GolfCourse.Context;
using GolfCourse.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfCourse.Repositories
{
    public class TournamentRepo : ITournamentRepo
    {
        private readonly PlayerTournamentDbContext _context;

        public TournamentRepo(PlayerTournamentDbContext context)
        {
            _context = context;
        }
        public List<Tournament> GetTournaments()
        {
            return _context.Tournaments.ToList();
        }

        public List<Tournament> GetTournamentsWithPrize()
        {
            return _context.Tournaments.Where(t => t.Prize > 0).ToList();
        }

        public void AddTournament(Tournament tournament)
        {
            _context.Tournaments.Add(tournament);
            _context.SaveChanges();
        }

        public List<Player> GetPlayersInTournament(int tourId)
        {
            var tournament = _context.Tournaments.Find(tourId);
            if (tournament is null)
                return null;
            var playerTournament = _context.PlayerTournaments.Where(pt => pt.TournamentId == tournament.Id);
            List<Player> player = new();
            foreach (PlayerTournament playerTour in playerTournament)
            {
                player.Add(_context.Players.Find(playerTour.PlayerId));
            }
            return player;
        }
        // Added Update Functionality as per the  Change Request
        public bool UpdateTournamentPrize(int tourId, Tournament tournament)
        {
            Tournament existingTournament = _context.Tournaments.SingleOrDefault(t => t.Id == tourId);
            if (existingTournament is null)
                return false;
            existingTournament.Prize = tournament.Prize;
            _context.Tournaments.Update(existingTournament);
            _context.SaveChanges();
            return true;
        }
    }
}
