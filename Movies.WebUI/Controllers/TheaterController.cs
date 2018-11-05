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
        public TheaterController(ITheaterRepository theaterRepository)
        {
            this.repository = theaterRepository;
        }
        public ViewResult List()
        {
            return View(repository.Theaters);
        }
        
    }
}