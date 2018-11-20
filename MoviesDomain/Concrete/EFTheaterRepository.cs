using Movies.Domain.Abstract;
using Movies.Domain.Entities;
using System.Collections.Generic;

namespace Movies.Domain.Concrete
{

    public class EFTheaterRepository : ITheaterRepository
    {
        private EFDbContextTheater context = new EFDbContextTheater();
        public IEnumerable<Theater> Theaters
        {
            get { return context.Theaters; }
        }
    }
}
    


