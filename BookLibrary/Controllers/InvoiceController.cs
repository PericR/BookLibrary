using BookLibrary.DTOs;
using BookLibrary.Entities;
using BookLibrary.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookLibrary.Controllers
{
    public class InvoiceController : BaseApiController
    {
        private readonly IInvoiceService invoiceService;
        private readonly UserManager<User> userManager;
        private readonly IBookService bookService;

        public InvoiceController(IInvoiceService invoiceService, UserManager<User> userManager, IBookService bookService)
        {
            this.invoiceService = invoiceService;
            this.userManager = userManager;
            this.bookService = bookService;
        }

        /// <summary>
        /// Adds new invoice to the database
        /// </summary>
        /// <param name="addInvoiceDto">Empty JSON object that will be filled with data from database</param>
        /// <param name="bookId">Book id</param>
        /// <returns></returns>
        /// <response code="200">Invoice added successfully</response>
        /// <response code="400">Your user or book object might be null.</response>
        [Authorize(Roles ="Visitor, Administrator")]
        [HttpPost("new-invoice/{bookId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> AddInvoice(AddInvoiceDto addInvoiceDto, int bookId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            User user = await this.userManager.Users.FirstOrDefaultAsync(u => u.UserName == userId);

            addInvoiceDto.UserId = user.Id;
            addInvoiceDto.Book = await this.bookService.GetBookByIdForInvoiceAsync(bookId);

            if(user == null || addInvoiceDto.Book == null)
            {
                return BadRequest("Check your user and book for null value.");
            }

            await this.invoiceService.AddInvoice(addInvoiceDto);

            return Ok();
        }

        /// <summary>
        /// Gets all invoices by book id
        /// </summary>
        /// <param name="bookId">Book id</param>
        /// <returns></returns>
        /// <response code="200">Returns all invoices for given book, in JSON format. Empty if no book was found</response>
        [HttpGet("get-by-book-id/{bookId}")] 
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<GetInvoiceDto>> GetInvoicesByBookId(int bookId)
        {
            var invoices =  this.invoiceService.GetInvoiceByBookId(bookId);
            
            return Ok(invoices);
        }

        /// <summary>
        /// Get all invoices by user id (Guid)
        /// </summary>
        /// <param name="userId">User id (Guid)</param>
        /// <returns></returns>
        /// <response code="200">Returns all invoices for given user id, in JSON format. Empty if no book was found</response>
        [HttpGet("get-by-user-id/{userId}")]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<GetInvoiceDto>> GetInvoicesByUserId(Guid userId)
        {
            var invoices = this.invoiceService.GetInvoicesByUserId(userId);

            return Ok(invoices);
        }

        /// <summary>
        /// Gets one invoice by its id
        /// </summary>
        /// <param name="id">Id for the given invoice in database</param>
        /// <returns></returns>
        /// <response code="200">Returns JSON representation for given invoice</response>
        [HttpGet("get-invoice/{id}")]
        [ProducesResponseType(200)]
        public ActionResult<GetInvoiceDto> GetInvoiceById(int id)
        {
            var invoice = this.invoiceService.GetInvoiceById(id);
            return Ok(invoice);
        }
    }
}
