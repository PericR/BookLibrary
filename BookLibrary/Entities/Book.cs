using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Entities
{
    public class Book
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Author { get; set; }
        
        [Required]
        public string Genre { get; set; }
        public string Description { get; set; }
        public string ShortIntro { get; set; }
        
        [Required]
        public double Price { get; set; }
        public DateTime PublishedAt { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public ICollection<Invoice> Invoices{ get; set; }
    }
}
