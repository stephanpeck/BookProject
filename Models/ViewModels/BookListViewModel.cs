using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//now that we have this view built, it makes it more flexible, you can change databases and not screw everything up
namespace TempleToursProject.Models.ViewModels
{
    public class TourListViewModel
    {
        public IEnumerable<BookModel> BookModels { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
