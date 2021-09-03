using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookLibrary.Data;
using BookLibrary.DTOs;
using BookLibrary.Entities;
using BookLibrary.Helpers;
using BookLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Services
{
    public class BookService : IBookService
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public BookService(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public async Task AddBook(AddBookDto addBookDto)
        {
            Book bookToAdd = this.mapper.Map<Book>(addBookDto);
            this.dataContext.Books.Add(bookToAdd);
            await this.dataContext.SaveChangesAsync();
        }

        public async Task<GetBookDto> GetBookByIdAsync(int id)
        {
            var book = await this.dataContext.Books.FindAsync(id);
            return this.mapper.Map<GetBookDto>(book);
        }

        public async Task<Book> GetBookByIdForInvoiceAsync(int id)
        {
            return await this.dataContext.Books.FindAsync(id);
        }

        public async Task<IEnumerable<GetBookDto>> GetBooksAsync()
        {
            return await this.dataContext.Books.ProjectTo<GetBookDto>(this.mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
