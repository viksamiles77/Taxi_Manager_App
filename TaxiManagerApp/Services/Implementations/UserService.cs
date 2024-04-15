using DataAccess;
using Models;
using Models.Enums;
using Services.Interfaces;
using System.Data;

namespace Services.Implementations
{
    public class UserService : IUserService
    {

        public void Login(string username, string password)
        {
            var loginUser = Storage.Users.GetAll().FirstOrDefault(x => x.UserName == username);
            if (loginUser == null)
                throw new Exception("Non existing user!");

            if (!loginUser.CheckPassword(password))
                throw new Exception("Wrong password!");

            CurrentSession.CurrentUser = loginUser;
        }
        public void LogOut()
        {
            CurrentSession.CurrentUser = null;
        }

        public void CreateUser(string firstName, string lastName, string username, string password, RoleEnum role)
        {
            if (Storage.Users.GetAll().Any(x => x.UserName == username))
            {
                throw new Exception($"User with username {username} already exists!");

            }
            var newUser = new User(0, firstName, lastName, username, password, role);
            Storage.Users.Add(newUser);
        }

        public void CreateUser(string firstName, string lastName, string username, string password, string licenseNumber, DateTime licenseExpiryDate)
        {
            if (Storage.Users.GetAll().Any(x => x.UserName == username))
            {
                throw new Exception($"User with username {username} already exists!");

            }
            var newUser = new Driver(0, firstName, lastName, username, password, licenseNumber, licenseExpiryDate);
            Storage.Users.Add(newUser);
        }

    }
}
