using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrormationSystem
{
    public class Personal
    {
        public int Id;
        public int UserId;
        public string FirstName;
        public string LastName;
        public string Patronymic;
        public DateTime BirthDay;
        public long Passport;
        public int Salary;


        public void ConsoleOutput()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"ID пользователя: {UserId}");
            Console.WriteLine($"Имя: {FirstName}");
            Console.WriteLine($"Фамилия: {LastName}");
            Console.WriteLine($"Отчество: {Patronymic}");
            Console.WriteLine($"День рождения: {BirthDay}");
            Console.WriteLine($"Данные паспорта: {Passport}");
            Console.WriteLine($"Зарплатная плата: {Salary}");
        }
    }
    public class User
    {
        public int Id;
        public string Login;
        public string Password;
        public int RoleType;
    }
}
