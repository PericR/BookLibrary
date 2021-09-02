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
        Task<IEnumerable<GetInvoiceDto>> GetInvoicesByUser(int userId);
    }
}
