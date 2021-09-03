using BookLibrary.DTOs;
using BookLibrary.Entities;
using BookLibrary.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost("new-invoice")]
        public async Task<ActionResult> AddInvoice(AddInvoiceDto addInvoiceDto)
        {
            addInvoiceDto.User = await this.userManager.GetUserAsync(HttpContext.User);
            addInvoiceDto.Book = await this.bookService.GetBookByIdForInvoiceAsync(1);
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
