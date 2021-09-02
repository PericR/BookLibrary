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
        private readonly IBookService bookService;

        public TestController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpPost("add-book")]
        public async Task<ActionResult> AddBook(AddBookDto addBookDto)
        {
            await this.bookService.AddBook(addBookDto);
            return Ok();
        }

        [HttpGet("books")]
        public async Task<ActionResult<IEnumerable<GetBookDto>>> GetBooks()
        {
            var books = await this.bookService.GetBooksAsync();
            return Ok(books);
        }

        [HttpGet("book/{id}")]
        public async Task<ActionResult<GetBookDto>> GetBookById(int id)
        {
            var book = await this.bookService.GetBookByIdAsync(id);
            return Ok(book);
        }
    }
}
