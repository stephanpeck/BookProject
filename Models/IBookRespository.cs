using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//IBookRepository creates a queryable Book Model
namespace BookProject.Models
{
    public interface IBookRepository
    {
        IQueryable<BookModel> Books { get; }
    }
}
