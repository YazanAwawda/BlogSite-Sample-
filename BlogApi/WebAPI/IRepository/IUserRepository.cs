

using WebAPI.Models.Entities;

namespace WebAPI.IRepository
{
    public interface IUserRepository
    {

        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetByIdAsync(int id);    
        void AddUser(User user);
        void DeleteUser(int UserId);
        Task<bool> SaveAsync();

    }
}
