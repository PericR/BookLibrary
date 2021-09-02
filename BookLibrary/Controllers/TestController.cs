using BookLibrary.DTOs;
using BookLibrary.Entities;
using BookLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Controllers
{
    public class TestController : BaseApiController
    {
        private readonly IBookService _bookService;

        public TestController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("add-book")]
        public async Task<ActionResult> AddBook(Book book)
        {
            await _bookService.AddBook(book);
            return Ok();
        }

        [HttpGet("books")]
        public async Task<ActionResult<IEnumerable<GetBookDto>>> GetBooks()
        {
            var books = await this._bookService.GetBooksAsync();
            return Ok(books);
        }
    }
}
