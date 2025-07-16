using TwitterApi.Data.DTOs;
using TwitterApi.Data.Models;

namespace TwitterApi.Contracts
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllAsync();
        Task<UserDTO> GetByIdAsync(string id);
        Task<UserDTO> CreateAsync(UserModel user);
        Task<UserDTO> UpdateAsync(string id, UserModel user);
        Task<bool> DeleteAsync(string id);
    }
}
