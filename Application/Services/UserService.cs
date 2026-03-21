using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _iMapper;
        public UserService(IUserRepository iUserRepository, JwtService jwtService, IUnitOfWork iUnitOfWork, IMapper iMapper)
        {
            _userRepository = iUserRepository;
            _jwtService = jwtService;
            _unitOfWork = iUnitOfWork;
            _iMapper = iMapper;
        }
        public async Task<UserDTO> GetUserByIdAsync(string userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null) return null;
            return new UserDTO
            {
                Email = user.Email,
                Name = user.UserName,
            };
        }
        public async Task<string> Login(LoginDTO loginDto)
        {
            var user = await _userRepository.GetUserByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return null;
            }
            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                return null;
            }
            return _jwtService.GenerateToken(user);
        }

        public async Task Register(RegisterUserDTO register)
        {
            var user = await _userRepository.GetUserByEmailAsync(register.Email);

            if (user != null) throw new Exception("Email is already registered!");
            if (string.IsNullOrEmpty(register.Password)) throw new Exception("Password required");
            var newUser = _iMapper.Map<User>(register);
            newUser.SetRole(UserRole.User);
            newUser.SetIsActive(true);
            var hash = BCrypt.Net.BCrypt.HashPassword(register.Password);
            newUser.UpdatePasswords(hash);
            await _userRepository.AddUserAsync(newUser);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
