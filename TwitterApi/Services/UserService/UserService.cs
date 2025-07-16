using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TwitterApi.Contracts;
using TwitterApi.Data.DTOs;
using TwitterApi.Data.Entities;
using TwitterApi.Data.Models;
using TwitterApi.Data.UnitOfWork;

namespace TwitterApi.Services.UserService
{
    public class UserService : BaseService, IUserService
    {
        private readonly UserManager<User> _userManager;
        public UserService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<User> userManager)
            : base(unitOfWork, mapper)
        {
            _userManager = userManager;
        }

        public async Task<UserDTO> CreateAsync(UserModel userModel)
        {
            var user = new User()
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                UserName = userModel.UserName,
                Email = userModel.Email,
                PhoneNumber = userModel.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                return new UserDTO
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    IsConfirmed = user.EmailConfirmed
                };
            }

            throw new AccessViolationException();
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var user = await _unitOfWork.GetByIdAsync<User>(id);
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<List<UserDTO>> GetAllAsync()
        {
            return await _unitOfWork
                .Get<User>()
                .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<UserDTO> GetByIdAsync(string id)
        {
            var result = await _unitOfWork.GetByIdAsync<User>(id);
            return new UserDTO
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
                UserName = result.UserName,
                Email = result.Email,
                PhoneNumber = result.PhoneNumber,
                IsConfirmed = result.EmailConfirmed
            };
        }

        public async Task<UserDTO> UpdateAsync(string id, UserModel userModel)
        {
            var user = await _unitOfWork
                .GetByIdAsync<User>(id) ?? throw new EntryPointNotFoundException();

            user.FirstName = userModel.FirstName;
            user.LastName = userModel.LastName;
            user.UserName = userModel.UserName;
            user.Email = userModel.Email;
            user.PhoneNumber = userModel.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return new UserDTO
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    IsConfirmed = user.EmailConfirmed
                };
            }

            throw new EntryPointNotFoundException();

        }
    }
}
