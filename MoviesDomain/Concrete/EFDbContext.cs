using Movies.Domain.Entities;
using System.Data.Entity;

namespace Movies.Domain.Concrete
{
   public class EFDbContextTheater : System.Data.Entity.DbContext
    {
       public DbSet<Movie> Movies { get; set; }
    }
}
