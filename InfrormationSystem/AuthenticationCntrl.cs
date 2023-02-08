using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrormationSystem
{
    public class AuthenticationCntrl
    {
        public User StartAuthentication()
        {
            Console.WriteLine("Введите логин: ");
            var login = Console.ReadLine() ?? "";
            Console.WriteLine("Введите пароль: ");
            var password = Console.ReadLine() ?? "";
            try
            {
                User? account = MainService.GetUserService().FindByLoginPassword(login, password);

                if (account is null)
                {
                    throw new ArgumentException("Авторизация не удалась. Попробуйте снова!");
                }

                return account;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return StartAuthentication();
            }
        }
    }
}
