using Movies.Domain.Entities;
using System.Collections.Generic;

namespace Movies.Domain.Abstract
{
    public interface ITheaterRepository
    {
        IEnumerable<Theater> Theaters { get; }
    }
}
