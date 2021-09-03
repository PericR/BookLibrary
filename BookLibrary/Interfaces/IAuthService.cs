using BookLibrary.DTOs;
using BookLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Interfaces
{
    public interface IAuthService
    {
        Task<bool> ValidateUser(UserLoginDto userLoginDto, User user);
        Task<string> CreateToken(User user);
    }
}
