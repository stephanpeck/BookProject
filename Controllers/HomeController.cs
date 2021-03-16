using TempleToursProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TempleToursProject.Models.ViewModels;


//Home controller
namespace TempleToursProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ITourRepository _repository;

        //sets the number of items per page returned (5 books per page)
        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, ITourRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        // Loads the index view and sends the book repository along with it in the form of a model so that it can be used in the cshtml page

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Tours()
        {
            return View();
        }



        //if no page parameter is passed in, set to 1
        //public IActionResult Tours(string category, int pageNum = 1)
        //{
        //    //This is a query written in Linq (which we have imported above)
        //    return View(new TourListViewModel
        //    {
        //        BookModels = _repository.Books
        //        //if category is null, then there won't be anything in category. If someone has passed in a category, then it won't be null. So this covers everything
        //        .Where(p => category == null || p.Category == category)
        //        .OrderBy(p => p.BookID)
        //        .Skip((pageNum - 1) * PageSize)
        //        .Take(PageSize)

        //        ,
        //        PagingInfo = new PagingInfo
        //        {
        //            CurrentPage = pageNum,
        //            ItemsPerPage = PageSize,
        //            TotalNumItems = category == null ? _repository.Books.Count() :
        //                _repository.Books.Where (x => x.Category == category).Count()
        //        },
        //        CurrentCategory = category
        //    });
                
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
