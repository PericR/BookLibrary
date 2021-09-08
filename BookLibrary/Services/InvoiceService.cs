using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookLibrary.Data;
using BookLibrary.DTOs;
using BookLibrary.Entities;
using BookLibrary.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookLibrary.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        public InvoiceService(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public async Task AddInvoice(AddInvoiceDto addInvoiceDto)
        {
            Invoice invoiceToAdd = this.mapper.Map<Invoice>(addInvoiceDto);
            this.dataContext.Invoices.Add(invoiceToAdd);
            
            await this.dataContext.SaveChangesAsync();
        }

        public IEnumerable<GetInvoiceDto> GetInvoiceByBookId(int bookId)
        {
            var invoices = this.dataContext.Invoices.ProjectTo<GetInvoiceDto>(this.mapper.ConfigurationProvider).AsEnumerable().Where(i => i.BookId == bookId).ToList();
            return invoices;
        }

        public async Task<GetInvoiceDto> GetInvoiceById(int id)
        {
            var invoice = await this.dataContext.Invoices.FindAsync(id);
            return this.mapper.Map<GetInvoiceDto>(invoice);
        }

        public IEnumerable<GetInvoiceDto> GetInvoicesByUserId(Guid userId)
        {
            var invoices = this.dataContext.Invoices.ProjectTo<GetInvoiceDto>(this.mapper.ConfigurationProvider).AsEnumerable().Where(i => i.UserId == userId).ToList();
            return invoices;
        }
    }
}
