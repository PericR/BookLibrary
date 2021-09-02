using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public Book BookId { get; set; }
        public User UserId { get; set; }
    }
}
