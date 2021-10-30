using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food4U_SEP3.Models;
using Food4U_SEP3.Permistences;


namespace Food4U_SEP3.UserServices
{
    public class UserService : IUserService
    {
        public IList<User> Users { get; private set; }
        private readonly FileContext fileContext;

        public UserService()
        {
            fileContext = new FileContext();
            Users = fileContext.Users;
        }

        public async Task<IList<User>> GetUsers()
        {
            return Users;
        }

        public User ValidateLogin(string username, string password)
        {
            User first = Users.FirstOrDefault(x => x.Username.Equals(username));
            if (first == null) throw new Exception("User not found");
            if (!first.Password.Equals(password)) throw new Exception("Invalid password");
            if (first != null) throw new Exception("User already exists");
            return first;
        }
    }
    }

