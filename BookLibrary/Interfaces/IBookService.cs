using BookLibrary.DTOs;
using BookLibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Interfaces
{
    public interface IBookService
    {
        Task AddBook(Book book);
        Task<IEnumerable<GetBookDto>> GetBooksAsync();
        Task<Book> GetBookByIdAsync();
    }
}
