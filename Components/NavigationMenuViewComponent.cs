using TempleToursProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleToursProject.Components
{                                   //inheritance from asp
    public class NavigationMenuViewComponent : ViewComponent
    {
        private ITourRepository repository;

        public NavigationMenuViewComponent (ITourRepository r)
        {
            repository = r;
        }
        public IViewComponentResult Invoke()
        {
            //denotes the selected category -- @(category == ViewBag.SelectedCategory ? "btn-primary" : "btn-outline-secondary")
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            //dynamically adds a new category for books
            return View(repository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x)
                
                );
        }
    }
}
