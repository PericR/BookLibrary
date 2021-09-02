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

        public async Task AddBook(Book book)
        {
            this.dataContext.Books.Add(book);
            await this.dataContext.SaveChangesAsync();
        }

        public Task<Book> GetBookByIdAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GetBookDto>> GetBooksAsync()
        {
            return await this.dataContext.Books.ProjectTo<GetBookDto>(this.mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
