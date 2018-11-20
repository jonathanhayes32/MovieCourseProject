using Movies.Domain.Abstract;
using Movies.Domain.Entities;
using System.Collections.Generic;

namespace Movies.Domain.Concrete
{
    public class EFMovieRepository : IMovieRepository
    {
        private EFDbContextTheater context = new EFDbContextTheater();
        public IEnumerable<Movie> Movies
        {
            get { return context.Movies}
        }
    }
}
