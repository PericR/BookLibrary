using BookLibrary.DTOs;
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

        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllBooks()
        {
            return await _bookService.GetBooksAsync();
        }*/
    }
}
