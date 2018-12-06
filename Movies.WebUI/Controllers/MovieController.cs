using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movies.Domain.Abstract;
using Movies.Domain.Entities;
using Movies.WebUI.Models;

namespace Movies.WebUI.Controllers
{
    public class MovieController : Controller
    {
        private IMovieRepository repository;
        public int PageSize = 4;
        public MovieController(IMovieRepository movieRepository)
        {
            this.repository = movieRepository;
        }
        public ViewResult List(int page = 1)
        {
            MoviesListViewModel model = new MoviesListViewModel
            {
                Movies = repository.Movies
                .OrderBy(m => m.MovieID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Movies.Count()
                }
            };
            return View(model);

        }
    }
}