﻿using BookLibrary.Data;
using BookLibrary.Entities;
using BookLibrary.Interfaces;
using BookLibrary.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Extensions
{
    public static class ApplicationsServiceExtensions
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<DataContext>();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IBookService, BookService>();
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("sqlConnection"));
            });

            return services;
        }
    }
}