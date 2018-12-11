//Holds the unit tests for the other two projects
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Movies.Domain.Abstract;
using Movies.Domain.Entities;
using Movies.WebUI.Controllers;
using Movies.WebUI.Models;


namespace Movies.Unit.Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Can_Paginate()
        {

            // Arrange      
            Mock<IMovieRepository> mock = new Mock<IMovieRepository>();
            mock.Setup(m => m.Movies).Returns(new Movie[] {
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
            Movie[] MovieArray = result.ToArray();
            Assert.IsTrue(MovieArray.Length == 2);
            Assert.AreEqual(MovieArray[0].Name, "M4");
            Assert.AreEqual(MovieArray[1].Name, "M5");
        }
        [TestMethod]
        public void Can_Paginate1()
        {

            // Arrange      
            Mock<ITheaterRepository> mock = new Mock<ITheaterRepository>();
            mock.Setup(t => t.Theaters).Returns(new Theater[] {
                new Theater {TheaterID = 1, TheaterName = "T1"},
                new Theater {TheaterID = 2, TheaterName = "T2"},
                new Theater {TheaterID = 3, TheaterName = "T3"},
                new Theater {TheaterID = 4, TheaterName = "T4"},
                new Theater {TheaterID = 5, TheaterName = "T5"}
            });

            TheaterController controller = new TheaterController(mock.Object); controller.PageSize = 3;

            // Act   
            IEnumerable<Theater> result =
                (IEnumerable<Theater>)controller.List(2).Model;

            // Assert       
            Theater[] TheaterArray = result.ToArray();
            Assert.IsTrue(TheaterArray.Length == 2);
            Assert.AreEqual(TheaterArray[0].TheaterName, "T4");
            Assert.AreEqual(TheaterArray[1].TheaterName, "T5");
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
        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {

            // Arrange 
            Mock<IMovieRepository> mock = new Mock<IMovieRepository>();
            mock.Setup(m => m.Movies).Returns(new Movie[] {
                    new Movie {MovieID = 1, Name = "M1"},
                    new Movie {MovieID = 2, Name = "M2"},
                    new Movie {MovieID = 3, Name = "M3"},
                    new Movie {MovieID = 4, Name = "M4"},
                    new Product {MovieID = 5, Name = "M5"}
                });

            // Arrange 
            MovieController controller = new MovieController(mock.Object);
            controller.PageSize = 3;

            // Act   
            MoviesListViewModel result = (MoviesListViewModel)controller.List(2).Model;

            // Assert  
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }
        [TestMethod]
        public void Can_Send_Pagination_View_Model1()
        {

            // Arrange 
            Mock<ITheaterRepository> mock = new Mock<ITheaterRepository>();
            mock.Setup(t => t.Theaters).Returns(new Theater[] {
                new Theater {TheaterID = 1, TheaterName = "T1"},
                new Theater {TheaterID = 2, TheaterName = "T2"},
                new Theater {TheaterID = 3, TheaterName = "T3"},
                new Theater {TheaterID = 4, TheaterName = "T4"},
                new Theater {TheaterID = 5, TheaterName = "T5"}
            });

            // Arrange 
            TheaterController controller = new TheaterController(mock.Object);
            controller.PageSize = 3;

            // Act   
            TheatersListViewModel result = (TheatersListViewModel)controller.List(2).Model;

            // Assert  
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }
    }
}
