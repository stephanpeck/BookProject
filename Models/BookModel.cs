using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
//Model for books, all fields are required except Author Middle Name/Initial
namespace TempleToursProject.Models
{
    public class BookModel
    {
        [Required]
        [Key]
        public int BookID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string AuthorFName { get; set; }
        public string AuthorMName { get; set; }
        [Required]
        public string AuthorLName { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        //Regex expression to make sure the ISBN is correct, Can't test too much because this app doesnt allow for inputs
        [RegularExpression(@"\d{3}-\d{10}", ErrorMessage = "ISBN incorrect, please use this format: 000-0000000000")]
        public string ISBN { get; set; }
        [Required]
        public string Classification { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public double Pages { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
