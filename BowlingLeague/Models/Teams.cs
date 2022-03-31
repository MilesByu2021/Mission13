using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BowlingLeague.Models
{
    public class Teams
    {
        [Key]
        [Required]
        public int TeamID { get; set; }

        public string TeamName { get; set; }

        //Foregin Table
        public int CaptainID { get; set; }

        [ForeignKey("CaptainID")]
        public Bowlers Bowlers { get; set; }
    }
}
