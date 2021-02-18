using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookProject.Models
{
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            BookDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BookDbContext>();

            //are there any migrations that need to happen?

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            //if nothing loaded in the database yet, we are going to add some info in
            if(!context.BookModels.Any())
            {

                context.BookModels.AddRange(

                    new BookModel
                    {
                        
                        Title = "Les Miserables", 
                        AuthorFName = "Victor",
                        AuthorMName = "",
                        AuthorLName = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 9.95


                    },

                    new BookModel
                    {

                        Title = "Team of Rivals",
                        AuthorFName = "Doris",
                        AuthorMName = "Kearns",
                        AuthorLName = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 14.58


                    },

                    new BookModel
                    {

                        Title = "The Snowball",
                        AuthorFName = "Alice",
                        AuthorMName = "",
                        AuthorLName = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 21.54


                    },

                     new BookModel
                     {

                         Title = "American Ulysses",
                         AuthorFName = "Ronald",
                         AuthorMName = "C",
                         AuthorLName = "White",
                         Publisher = "Random House",
                         ISBN = "978-0812981254",
                         Classification = "Non-Fiction",
                         Category = "Historical",
                         Price = 11.61


                     },
                      new BookModel
                      {

                          Title = "Unbroken",
                          AuthorFName = "Laura",
                          AuthorMName = "",
                          AuthorLName = "Hillenbrand",
                          Publisher = "Random House",
                          ISBN = "978-0812974492",
                          Classification = "Non-Fiction",
                          Category = "Historical",
                          Price = 13.33


                      },
                      new BookModel
                      {

                          Title = "The Great Train Robbery",
                          AuthorFName = "Michael",
                          AuthorMName = "",
                          AuthorLName = "Crichton",
                          Publisher = "Vintage",
                          ISBN = "978-0804171281",
                          Classification = "Fiction",
                          Category = "Historical Fiction",
                          Price = 15.95


                      },
                      new BookModel
                      {

                          Title = "Deep Work",
                          AuthorFName = "Cal",
                          AuthorMName = "",
                          AuthorLName = "Newport",
                          Publisher = "Grand Central Publishing",
                          ISBN = "978-1455586691",
                          Classification = "Non-Fiction",
                          Category = "Self-Help",
                          Price = 14.99

                      },
                      new BookModel
                      {

                          Title = "It's Your Ship",
                          AuthorFName = "Michael",
                          AuthorMName = "",
                          AuthorLName = "Abrashoff",
                          Publisher = "Grand Central Publishing",
                          ISBN = "978-1455523023",
                          Classification = "Non-Fiction",
                          Category = "Self-Help",
                          Price = 21.66

                      },
                      new BookModel
                      {

                          Title = "The Virgin Way",
                          AuthorFName = "Richard",
                          AuthorMName = "",
                          AuthorLName = "Branson",
                          Publisher = "Portfolio",
                          ISBN = "978-1591847984",
                          Classification = "Non-Fiction",
                          Category = "Business",
                          Price = 29.16


                      },
                      new BookModel
                      {

                          Title = "Sycamore Row",
                          AuthorFName = "John",
                          AuthorMName = "",
                          AuthorLName = "Grisham",
                          Publisher = "Bantam",
                          ISBN = "978-0553393613",
                          Classification = "Fiction",
                          Category = "Thrillers",
                          Price = 15.03


                      }



                );

                context.SaveChanges();

            }
        }
    }
}
