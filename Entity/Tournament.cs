using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GolfCourse.Entity
{
    //Adding class level comments
    public class Tournament //adding attributes to the tournament class
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Month { get; set; }
        public string City { get; set; }
        public int Prize { get; set; }
    }
}
