using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Entities
{
    public class Theater
    {
        public int TheaterID { get; set; }
        public string TheaterName { get; set; }
        public string AdressLine { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
    }
}
