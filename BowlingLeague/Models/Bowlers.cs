using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BowlingLeague.Models
{
    public class Bowlers
    {
        [Key]
        [Required]
        public int BowlerID { get; set; }

        [Required(ErrorMessage = "Please enter a first name")]
        public string BowlerFirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name")]
        public string BowlerLastName { get; set; }

        [StringLength(1, ErrorMessage = "The Middle Initial cannot exceed 1 character")]
        public string BowlerMiddleInit { get; set; }

        [Required(ErrorMessage = "Please enter an address")]
        public string BowlerAddress { get; set; }

        [Required(ErrorMessage = "Please enter a city name")]
        public string BowlerCity { get; set; }

        [Required(ErrorMessage = "Please enter a state abbreviation name")]
        public string BowlerState { get; set; }

        [Required(ErrorMessage = "Please enter a zip code")]
        public string BowlerZip { get; set; }

        [Required(ErrorMessage = "Please enter a phone number")]
        public string BowlerPhoneNumber { get; set; }

        //Foregin Table
        [Required(ErrorMessage = "Please enter a Team ID")]
        public int TeamID { get; set; }

        [ForeignKey("TeamID")]
        public Teams Team { get; set; }
    }
}
