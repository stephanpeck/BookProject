using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// EFBookRepository
namespace TempleToursProject.Models
{
    public class EFBookRepository : ITourRepository
    {
        private TourDbContext _context;

        //Constructor
        public EFBookRepository (TourDbContext context)
        {
            _context = context;
        }


        //Dbs set from TourDbContext.cs
        public IQueryable<BookModel> Books => _context.BookModels;
    }
}
