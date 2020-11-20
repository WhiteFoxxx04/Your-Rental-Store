using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieRentalsDto
    {
        public int customerId { get; set; }
        public List<int> movieIds { get; set; }
    }
}