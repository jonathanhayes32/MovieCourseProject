﻿//Holds the unit tests for the other two projects
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Movies.Domain.Abstract;
using Movies.Dmoain.Entities;
using Movies.WebUI.Controlers;
using SportsStore.WebUI.Models;
using SportsStore.WebUI.HtmlHelpers;

namespace Movies.Unit.Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Can_Paginate()
        {

            // Arrange      
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Movies).Returns(new Movies[] {
                new Movie {MovieID = 1, Name = "M1"},
                new Movie {MovieID = 2, Name = "M2"},
                new Movie {MovieID = 3, Name = "M3"},
                new Movie {MovieID = 4, Name = "M4"},
                new Movie {MovieID = 5, Name = "M5"}
            });

            MovieController controller = new MovieController(mock.Object); controller.PageSize = 3;

            // Act   
            IEnumerable<Movie> result =
                (IEnumerable<Movie>)controller.List(2).Model;

            // Assert       
            Product[] prodArray = result.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "M4");
            Assert.AreEqual(prodArray[1].Name, "M5");
        }
        [TestMethod]
        public void Can_Paginate1()
        {

            // Arrange      
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(t => t.Theaters).Returns(new Theater[] {
                new Theater {TheaterID = 1, Name = "T1"},
                new Theater {TheaterID = 2, Name = "T2"},
                new Theater {TheaterID = 3, Name = "T3"},
                new Theater {TheaterID = 4, Name = "T4"},
                new Theater {MovieID = 5, Name = "T5"}
            });

            TheaterController controller = new TheaterController(mock.Object); controller.PageSize = 3;

            // Act   
            IEnumerable<Theater> result =
                (IEnumerable<Theater>)controller.List(2).Model;

            // Assert       
            Product[] prodArray = result.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "T4");
            Assert.AreEqual(prodArray[1].Name, "T5");
        }
        [TestMethod]
        public void Can_Generate_Page_Links()
        {

            // Arrange - define an HTML helper - we need to do this     
            // in order to apply the extension method      
            HtmlHelper myHelper = null;

            // Arrange - create PagingInfo data    
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            // Arrange - set up the delegate using a lambda expression  
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            // Act       
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);
            // Assert    
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"    
+ @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"         
+ @"<a class=""btn btn-default"" href=""Page3"">3</a>",         
result.ToString()); 
        }
    }
}
