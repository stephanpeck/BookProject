using BookProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookProject.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBookRepository repository;

        public NavigationMenuViewComponent (IBookRepository r)
        {
            repository = r;
        }
        public IViewComponentResult Invoke()
        {
            //denotes the selected category -- @(category == ViewBag.SelectedCategory ? "btn-primary" : "btn-outline-secondary")
            ViewBag.SelectedCategory = RouteData?.Values["category"];


            return View(repository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x)
                
                );
        }
    }
}
