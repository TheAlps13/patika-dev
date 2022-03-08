using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private static List<Book> BookList = new List<Book>()
        {
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
        };

       /* [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList = BookList;
            return bookList;
        }*/

        [HttpGet("{id}")]
        public Book GetBookById(int id)
        {
            foreach(Book book in BookList)
                if(book.Id == id)
                    return book;

            return BookList[0];
        }

         [HttpGet]
        public Book Get([FromQuery] int id)
        {
            foreach(Book book in BookList)
                if(book.Id == id)
                    return book;
                    
            return BookList[0];
        }
    }


}