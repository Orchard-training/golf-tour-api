using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GolfCourse.Entity
{
    public class PlayerTournament
    {
        [Key]
        public int Id { get; set; }
      
        public int PlayerId { get; set; }

        [ForeignKey("Id")]
        public Player Player { get; set; }

        public int TournamentId { get; set; }

        [ForeignKey("Id")]
        public Tournament Tournament { get; set; }
    }
}
