using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fisher.Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Fisher.Bookstore.Api.Data;

namespace Fisher.Bookstore.Api.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookstoreContext db;

        public BooksController(BookstoreContext db)
        {
            this.db = db;
            if (this.db.Books.Count() == 0)
            {
                this.db.Books.Add(new Book()
                {
                    Id = 1,
                    Title = "Design Patterns",
                    Author = new Author(),
                    ISBN = "978-0201633610"
                });
                this.db.Books.Add(new Book()
                {
                    Id = 2,
                    Title = "Continuous Delivery",
                    Author = new Author(),
                    ISBN = "978-0321601919"
                });
                this.db.Books.Add(new Book()
                {
                    Id = 3,
                    Title = "The DevOps Handbook",
                    Author = new Author(),
                    ISBN = "978-1942788003"
                });
            }
            this.db.SaveChanges();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.Books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = db.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
       
    }
}