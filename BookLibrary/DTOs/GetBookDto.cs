using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.DTOs
{
    public class GetBookDto
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string ShortIntro { get; set; }
        public double Price { get; set; }
        public DateTime PublishedAt { get; set; }
        public DateTime Created { get; set; }
    }
}
