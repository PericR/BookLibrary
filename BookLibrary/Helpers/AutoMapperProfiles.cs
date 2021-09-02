using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookLibrary.DTOs;
using BookLibrary.Entities;

namespace BookLibrary.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Book, GetBookDto>();
            CreateMap<AddBookDto, Book>();
            CreateMap<UserRegistrationDto, User>();
            CreateMap<AddInvoiceDto, Invoice>();
        }
    }
}
