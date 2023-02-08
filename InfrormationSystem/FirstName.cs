using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrormationSystem
{
    public class FirstName
    {
        public FirstName(string firstName)
        {


            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("Имя недействительно.");
            }
            FirstNameText = firstName;
        }
        public string FirstNameText;
    }
    public class LastName
    {
        public LastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Фамилия недействительна.");
            }
            LastNameText = lastName;
        }
        public string LastNameText;
    }

    public class IdGenerator
    {
        public int PersonalId = 0;
        public int UserId = 0;

        public int GenerateUserId()
        {
            return ++UserId;
        }

        public int GeneratePersonalId()
        {
            return ++PersonalId;
        }
    }

    public class Login
    {
        public Login(string loginText)
        {
            if (string.IsNullOrWhiteSpace(loginText))
            {
                throw new ArgumentException("Логин недействителен.");
            }

            LoginText = loginText;
        }
        public string LoginText;
    }

    public class Password
    {
        public Password(string passwordText)
        {
            if (string.IsNullOrWhiteSpace(passwordText))
            {
                throw new ArgumentException("Пароль недействителен.");
            }

            PasswordText = passwordText;
        }
        public string PasswordText;
    }
}
