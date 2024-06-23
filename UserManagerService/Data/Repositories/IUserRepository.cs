using Microsoft.AspNetCore.Mvc;
using UserManagerService.Models;

namespace UserManagerService.Data.Repositories
{
    public interface IUserRepository
    {
        bool SaveChanges();
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        bool ExistUserByEmail(string email);
        void UpdateUser(int id ,User user); 
        void DeleteUser(User user);
        // Access Control
        void Login(string email, string password);
        User Register(User user);
    }
}
