using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// EFBookRepository
namespace BookProject.Models
{
    public class EFBookRepository : IBookRepository
    {
        private BookDbContext _context;

        //Constructor
        public EFBookRepository (BookDbContext context)
        {
            _context = context;
        }


        //Dbs set from BookDBContext.cs
        public IQueryable<BookModel> Books => _context.BookModels;
    }
}
