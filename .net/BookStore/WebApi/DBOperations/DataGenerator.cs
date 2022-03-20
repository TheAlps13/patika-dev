using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                    return;

                context.AddRange(
                     new Book
                     {
                         Id = 1,
                         Title = "The Flying Turtle",
                         Writer = "Alper T.",
                         GenreId = 1, // Turtle Personal Growth
                         PageCount = 112,
                         PublishDate = new DateTime(1992, 01, 05)
                     },
                     new Book
                     {
                         Id = 2,
                         Title = "The Martian Chronicles",
                         Writer = "Ray Bradbury",
                         GenreId = 2, // Sci-fi
                         PageCount = 222,
                         PublishDate = new DateTime(1950, 5, 4)
                     },
                        new Book
                        {
                            Id = 3,
                            Title = "The Colour Of Magic",
                            Writer = "Terry Pratchett",
                            GenreId = 3, // Fantastic
                            PageCount = 222,
                            PublishDate = new DateTime(1983, 11, 24)
                        }
                    );

                context.SaveChanges();
            }
        }
    }
}