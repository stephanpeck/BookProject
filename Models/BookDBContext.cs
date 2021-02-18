using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//DBContext page
namespace BookProject.Models
{
    public class BookDbContext : DbContext
    {
        public BookDbContext (DbContextOptions<BookDbContext> options) : base (options)
        {

        }

        public DbSet<BookModel> BookModels { get; set; }
    }
}
