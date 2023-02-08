using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrormationSystem
{
    public class UserBuilder : IBuilder<User>
    {
        private readonly User _user;
        public UserBuilder(Login login, Password password, RoleType roleType, int userId)
        {
            _user = new User
            {
                Login = login.LoginText,
                Password = password.PasswordText,
                Id = userId,
                RoleType = (int)roleType
            };
        }

        public User GetResult()
        {
            return _user;
        }
    }
}
