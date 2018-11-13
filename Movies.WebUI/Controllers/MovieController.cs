using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movies.Domain.Abstract;
using Movies.Domain.Entities;

namespace Movies.WebUI.Controllers
{
    public class MovieController : Controller
    {
        private IMovieRepository repository;
        public int Pagesize = 4;
        public MovieController(IMovieRepository movieRepository)
        {
            this.repository = movieRepository;
        }
        public ViewResult List(int page = 1)
        {
            return View(repository.Movies
                .OrderBy(m => m.MovieID)
                .Skip((page - 1) * Pagesize)
                .Take(Pagesize));
        }
    }
}