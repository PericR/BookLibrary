using BookLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Interfaces
{
    public interface IInvoiceService
    {
        Task AddInvoice(AddInvoiceDto addInvoiceDto);
        IEnumerable<GetInvoiceDto> GetInvoicesByUserId(Guid userId);
        IEnumerable<GetInvoiceDto> GetInvoiceByBookId(int bookId);
        Task<GetInvoiceDto> GetInvoiceById(int id); 
    }
}
