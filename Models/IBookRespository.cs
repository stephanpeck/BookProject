using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//ITourRepository creates a queryable Book Model
namespace TempleToursProject.Models
{
    public interface ITourRepository
    {
        IQueryable<BookModel> Books { get; }
    }
}
