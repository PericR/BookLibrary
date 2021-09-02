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
        Task AddBook(AddBookDto addBookDto);
        Task<IEnumerable<GetBookDto>> GetBooksAsync();
        Task<GetBookDto> GetBookByIdAsync(int id);
    }
}
