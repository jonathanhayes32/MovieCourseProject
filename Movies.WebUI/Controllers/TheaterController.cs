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
            return View(repository.Theaters
                .OrderBy(t => t.TheaterID)
                .Skip ((page - 1) * PageSize)
                .Take(PageSize));
        }
        
    }
}