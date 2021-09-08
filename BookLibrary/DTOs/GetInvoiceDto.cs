using BookLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.DTOs
{
    public class GetInvoiceDto
    {
        public int BookId{ get; set; }
        public Guid UserId { get; set; }
        public DateTime Created { get; set; }
    }
}
