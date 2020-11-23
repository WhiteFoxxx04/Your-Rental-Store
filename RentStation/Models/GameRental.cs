using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentStation.Models
{
    public class GameRental
    {
        public int Id { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Game Game { get; set; }

        public DateTime? DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}