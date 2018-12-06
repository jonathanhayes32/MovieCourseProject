using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movies.Domain.Abstract;
using Movies.Domain.Entities;

namespace Movies.WebUI.Controllers
{
    public class TheaterController : Controller
    {
        private ITheaterRepository repository;
        public int PageSize = 4;
        public TheaterController(ITheaterRepository theaterRepository)
        {
            this.repository = theaterRepository;
        }
        public ViewResult List(int page = 1)
        {
            TheatersListViewModel model = new TheatersListViewModel
            {
                Theaters = repository.Theaters
               .OrderBy(p => p.TheaterID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Theaters.Count()
                }
            };
            return View(model);


        }
    }
}