using System;
using System.Threading.Tasks;

using DesktopApplication.Models;

namespace DesktopApplication.Context
{
    class UserContext
    {
        public async Task<bool> Create(User account)
        {
            if(ModelIsValid(account))
            {
                string path = "users/";

                if (await APIConnection.Instance.Post(account, path))
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> Login(User account)
        {
            if (ModelIsValid(account))
            {
                string path = String.Format("users/{0}/{1}", account.Username, account.Password);

                if (await APIConnection.Instance.Get<bool>(path))
                {
                    APIConnection.Instance.Auth = account;

                    return true;
                }
            }
            return false;
        }

        public async Task<bool> Change(string password)
        {
            User account = new User();

            account.Username = APIConnection.Instance.Auth.Username;
            account.Password = password;

            //Only allow the logged in person to change their own password (this checked here and the server)
            if(ModelIsValid(account))
            {
                if (account.Username == APIConnection.Instance.Auth.Username)
                {
                    string path = String.Format("users/{0}/{1}", APIConnection.Instance.Auth.Username, APIConnection.Instance.Auth.Password);

                    if (await APIConnection.Instance.Put(account, path))
                    {
                        //Update the authentication login details on the client
                        APIConnection.Instance.Auth = account;

                        return true;
                    }
                }
            }
            return false;
        }

        private bool ModelIsValid(User account)
        {
            return ((account != null && account.Username != null && account.Password != null) &&
                    (UsernameIsValid(account.Username) && (PasswordIsValid(account.Password))));
        }

        private bool UsernameIsValid(string username)
        {
            return (username != null) && (username.Length >= 2) && (username.Length <= 16);
        }

        private bool PasswordIsValid(string password)
        {
            return (password != null) && (password.Length >= 3) && (password.Length <= 32);
        }
    }
}
