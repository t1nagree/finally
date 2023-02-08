using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrormationSystem
{
    public class AuthenticationException : Exception
    {
        public AuthenticationException()
            : base("Аутенфикация не прошла")
        {

        }
    }

    public class NotExistAccountException : Exception
    {
        public NotExistAccountException()
            : base("Не существует аккаунта")
        {

        }
    }
}
