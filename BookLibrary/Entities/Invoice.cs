using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        
        public Book Book { get; set; }
        [ForeignKey(nameof(BookId))]
        public int BookId { get; set; }

        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }
    }
}
