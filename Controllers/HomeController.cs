using BookProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BookProject.Models.ViewModels;


//Home controller
namespace BookProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IBookRepository _repository;

        //sets the number of items per page returned (5 books per page)
        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, IBookRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        // Loads the index view and sends the book repository along with it in the form of a model so that it can be used in the cshtml page

        //if no page parameter is passed in, set to 1
        public IActionResult Index(int page = 1)
        {
            //This is a query written in Linq (which we have imported above)
            return View(new BookListViewModel
            {
                BookModels = _repository.Books
                .OrderBy(p => p.BookID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)

                ,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalNumItems = _repository.Books.Count()
                }
            });
                
        }

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
