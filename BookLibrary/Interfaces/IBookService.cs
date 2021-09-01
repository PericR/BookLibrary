using BookLibrary.DTOs;
using BookLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Interfaces
{
    public interface IBookService
    {
        void Update(Book book);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<BookDto>> GetBooksAsync();
        Task<Book> GetBookByIdAsync();
    }
}
