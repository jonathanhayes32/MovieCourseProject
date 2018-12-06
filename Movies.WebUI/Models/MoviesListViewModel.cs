using System.Collections.Generic;
using Movies.Domain.Entities;

namespace Movies.WebUI.Models
{
    public class MoviesListViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}