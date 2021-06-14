using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GolfCourse.Entity
{
    public class Player
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        //AGE REQUIRED
        public int Age { get; set; }
        public string City { get; set; }
        public string EmailId { get; set; }
        public string Experience { get; set; }
        [NotMapped]
        public int TournamentId { get; set; }

    }
}
