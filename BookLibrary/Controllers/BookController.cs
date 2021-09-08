using BookLibrary.DTOs;
using BookLibrary.Entities;
using BookLibrary.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Controllers
{
    public class BookController : BaseApiController
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        /// <summary>
        /// Adds book to the database
        /// </summary>
        /// <param name="addBookDto">Data Transfer Object for book to be added to database</param>
        /// <returns></returns>
        /// <response code="200">Book is added successfully</response>
        /// <response code="401">User probably isn't loged in with required role</response>
        [Authorize]
        [HttpPost("add-book")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> AddBook(AddBookDto addBookDto)
        {
            await this.bookService.AddBook(addBookDto);
            return Ok();
        }

        /// <summary>
        /// Gets list of all books from database in JSON format.
        /// </summary>
        /// <returns>
        /// JSON list of all books if user is Authorized.
        /// </returns>
        /// <response code="200">JSON list of all books from database</response>
        /// <response code="401">User probably isn't loged in with required role</response>
        [Authorize(Roles ="Visitor, Administrator")]
        [HttpGet("books")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<IEnumerable<GetBookDto>>> GetBooks()
        {
            var books = await this.bookService.GetBooksAsync();
            return Ok(books);
        }

        /// <summary>
        /// Gets book by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Book by id number</returns>
        /// <response code="200">Book from database</response>
        /// <response code="401">User probably isn't loged in with required role</response>
        [Authorize(Roles ="Visitor, Administrator")]
        [HttpGet("book/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<GetBookDto>> GetBookById(int id)
        {
            var book = await this.bookService.GetBookByIdAsync(id);
            return Ok(book);
        }
    }
}
