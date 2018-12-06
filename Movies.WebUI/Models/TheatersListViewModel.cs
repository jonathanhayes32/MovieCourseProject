using System.Collections.Generic;
using Movies.Domain.Entities;

namespace Movies.WebUI.Models
{
    public class TheatersListViewModel
    {
        public IEnumerable<Theater> Theaters { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}