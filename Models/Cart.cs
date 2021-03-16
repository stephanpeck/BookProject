using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleToursProject.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem (BookModel bookMod, int qty)
        {
            //build a new instance of the object
            CartLine line = Lines
                .Where(b => b.BookModel.BookID == bookMod.BookID)
                .FirstOrDefault();

            //didnt return any results in the list that matched (The item was Not already in their cart)
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    BookModel = bookMod,
                    Quantity = qty
                });
            }
            //The item already was in their cart, so we are just going to add another of the quantity to that item
            else
            {
                line.Quantity += qty;
            }
        }
        //removing from the cart
        public virtual void RemoveLine(BookModel bookMod) =>
            Lines.RemoveAll(x => x.BookModel.BookID == bookMod.BookID);

        public virtual void Clear() => Lines.Clear();


        //little different than videos, double check if errors
        public double ComputeTotalSum()
        {
            return Lines.Sum(e => e.BookModel.Price * e.Quantity);
        }


        //In C#, we can build a class within a class
        public class CartLine
        {
            public int CartLineID { get; set; }
            public BookModel BookModel { get; set; }
            public int Quantity { get; set; }
        }

    }
}
