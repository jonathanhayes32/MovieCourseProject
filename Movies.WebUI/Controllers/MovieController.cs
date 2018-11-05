﻿using System;
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
        public MovieController(IMovieRepository movieRepository)
        {
            this.repository = movieRepository;
        }
        public ViewResult List()
        {
            return View(repository.Movies);
        }
    }
}