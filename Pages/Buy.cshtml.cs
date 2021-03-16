using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TempleToursProject.Models;
using TempleToursProject.Infrastructure;

namespace TempleToursProject.Pages
{
    public class BuyModel : PageModel
    {

        //creating instacne of our repository
        private ITourRepository repository;

        //Constructor
        public BuyModel (ITourRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        //Properties
        public Cart Cart { get; set; }

        public string ReturnUrl { get; set; }

        //Methods
        //public void OnGet(string returnUrl)
        //{
        //    //if null, use /, which would be root
        //    ReturnUrl = returnUrl ?? "/";
        //    Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        //}

        //FROM BOOK CHANGED
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }





        public IActionResult OnPost(long bookID, string returnUrl)
        {
            BookModel bookModel = repository.Books.FirstOrDefault(b => b.BookID == bookID);

            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(bookModel, 1);

            //HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });

        }

        //REMOVING FROM CART -- from Textbook
        public IActionResult OnPostRemove(long bookID, string returnUrl)
        {
            
            Cart.RemoveLine(Cart.Lines.First(cl =>
            cl.BookModel.BookID == bookID).BookModel);
            return RedirectToPage(new { returnUrl = returnUrl });
        }


    }
}
