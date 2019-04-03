using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using RestAPI.Models;

namespace RestAPI.Context
{
    public class UserContext : BaseContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public User Retrieve(string username)
        {
            return Users.Find(username);
        }

        public bool Change(User user)
        {
            if(ModelIsNotNull(user))
            {
                if(PasswordIsValid(user.Password) && Users.Where(x => x.Username == user.Username).Count() == 1)
                {
                    Users.Find(user.Username).Password = user.Password;
                    SaveChanges();

                    return true;
                }
            }
            return false;
        }

        public bool Create(User user)
        {
            if (ModelIsNotNull(user))
            {
                if(UsernameIsValid(user.Username) && PasswordIsValid(user.Password))
                {
                    Users.Add(user);
                    SaveChanges();

                    return true;
                }
            }
            return false;
        }

        public bool Delete(User user)
        {
            if (ModelIsNotNull(user))
            {
                Users.RemoveRange(Users.Where(x => x.Username == user.Username));
                SaveChanges();

                return true;
            }
            return false;
        }

        private bool ModelIsNotNull(User user)
        {
            return user != null && user.Username != null && user.Password != null;
        }

        private bool PasswordIsValid(string password)
        {
            return (password.Length >= 3) && (password.Length <= 32);
        }

        private bool UsernameIsValid(string username)
        {
            return (username.Length >= 2) && (username.Length <= 16);
        }
    }
}
