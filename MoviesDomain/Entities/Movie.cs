using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Entities
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Name { get; set; }
        public string MovieRating { get; set; }
        public DateTime MovieReleaseDate { get; set; }
        public string Genre { get; set; }
        public string BeenInTheaters { get; set; }
    }
}
