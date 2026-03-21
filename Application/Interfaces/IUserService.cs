using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<string> Login(LoginDTO loginDto);
        Task<UserDTO> GetUserByIdAsync(string UserId);
        Task Register(RegisterUserDTO register);
    }
}
