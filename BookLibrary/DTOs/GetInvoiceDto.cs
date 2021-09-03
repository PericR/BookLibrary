﻿using BookLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.DTOs
{
    public class GetInvoiceDto
    {
        public Book Book{ get; set; }
        public User User { get; set; }
        public DateTime Created { get; set; }
    }
}
