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
        [Authorize(Roles ="Visitor, Administrator")]
        [HttpPost("new-invoice/{bookId}")]
        public async Task<ActionResult> AddInvoice(AddInvoiceDto addInvoiceDto, int bookId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await this.userManager.Users.FirstOrDefaultAsync(u => u.UserName == userId);

            addInvoiceDto.UserId = user.Id;
            addInvoiceDto.Book = await this.bookService.GetBookByIdForInvoiceAsync(bookId);
            await this.invoiceService.AddInvoice(addInvoiceDto);

            return Ok();
        }

        [HttpGet("get-by-book-id/{bookId}")]
        public ActionResult<IEnumerable<GetInvoiceDto>> GetInvoicesByBookId(int bookId)
        {
            var invoices =  this.invoiceService.GetInvoiceByBookId(bookId);
            
            return Ok(invoices);
        }

        [HttpGet("get-by-user-id/{userId}")]
        public ActionResult<IEnumerable<GetInvoiceDto>> GetInvoicesByBookId(string userId)
        {
            var invoices = this.invoiceService.GetInvoicesByUserId(userId);

            return Ok(invoices);
        }

        [HttpGet("get-invoice/{id}")]
        public ActionResult<GetInvoiceDto> GetInvoiceById(int id)
        {
            var invoice = this.invoiceService.GetInvoiceById(id);
            return Ok(invoice);
        }
    }
}
