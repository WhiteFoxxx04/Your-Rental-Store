using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentStation.Dtos
{
    public class GameRentalsDto
    {
        public int customerId { get; set; }
        public List<int> gameIds { get; set; }
    }
}