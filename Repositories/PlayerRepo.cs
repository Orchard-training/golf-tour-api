using GolfCourse.Context;
using GolfCourse.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfCourse.Repositories
{
    public class PlayerRepo : IPlayerRepo
    {
        private readonly PlayerTournamentDbContext _context;

        public PlayerRepo(PlayerTournamentDbContext context)
        {
            _context = context;
        }
        public List<Player> GetPlayers()
        {
            return _context.Players.ToList();
        }

        public bool AddPlayer(Player player)
        {
            try
            {
                _context.Players.Add(player);
                PlayerTournament playerTournament = new PlayerTournament();
                playerTournament.PlayerId = player.Id;
                playerTournament.TournamentId = player.TournamentId;
                _context.PlayerTournaments.Add(playerTournament);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool UpdateExperience(string name, Player player)
        {
            Player existingPlayer = _context.Players.SingleOrDefault(p => p.Name == name);
            if (existingPlayer is null || (existingPlayer.Experience.CompareTo("Professional") == 0))
                return false;
            existingPlayer.Experience = "Professional";
            _context.Players.Update(existingPlayer);
            _context.SaveChanges();
            return true;
        }
        public bool DeleteAmateur(string name)
        {
            Player existingPlayer = _context.Players.SingleOrDefault(p => p.Name == name);
            if (existingPlayer is null || (existingPlayer.Experience.CompareTo("Professional") == 0))
                return false;
            _context.Players.Remove(existingPlayer);
            _context.SaveChanges();
            return true;
        }

   
    }
}
