using GolfCourse.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfCourse.Context
{
    public class PlayerTournamentDbContext : DbContext
    {
        public PlayerTournamentDbContext(DbContextOptions<PlayerTournamentDbContext> options ):base(options)
        {

        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<PlayerTournament> PlayerTournaments { get; set; }
    }
}
