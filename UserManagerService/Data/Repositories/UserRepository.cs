using Microsoft.AspNetCore.Mvc;
using UserManagerService.Models;

namespace UserManagerService.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManagerDbContext _context;

        public UserRepository(UserManagerDbContext context)
        {
            _context = context;
        }

        public void DeleteUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.Users.Remove(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public bool ExistUserByEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public User GetUserById(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return user;
        }

        public void Login(string email, string password)
        {
            // Validate credentials
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            Console.WriteLine("User logged in successfully");
        }

        public User Register(User user)
        {
            // Verify if the user already exists and Email is unique
            if (ExistUserByEmail(user.Email))
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.Users.Add(user);
            return user;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateUser(int id,User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var userToUpdate = _context.Users.FirstOrDefault(u => u.Id == id);
            if (userToUpdate == null)
            {
                throw new ArgumentNullException(nameof(userToUpdate));
            }
            userToUpdate.Username = user.Username;
            userToUpdate.Email = user.Email;
            userToUpdate.Password = user.Password;
        }

        public object GetUserByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (email == null)
            {
                throw new ArgumentNullException(nameof(email));
            }
            return user;
        }
    }
}
