using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrormationSystem
{
    public static class BirthDayEnter
    {
        public static DateTime Enter()
        {
            Console.WriteLine("Введите дату рождения: {dd.MM.yyyy}");
            var input = Console.ReadLine() ?? "";
            try
            {
                if (!DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out var dob))
                {
                    throw new ArgumentException("Дата рождения недействительна.");
                }
                return dob;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return Enter();
            }
        }
    }
    public static class EmployeeIdEnter
    {
        public static int Enter()
        {
            Console.WriteLine("Введите ID сотрудника.");
            try
            {
                if (!int.TryParse(Console.ReadLine(), out var id))
                {
                    throw new ArgumentException("Данный ID сотрудника недействителен.");
                }
                return id;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return Enter();
            }
        }
    }
    public static class FirstNameEnter
    {
        public static FirstName Enter()
        {
            Console.WriteLine("Введите имя: ");
            var firstNameText = Console.ReadLine() ?? "";
            try
            {
                var firstName = new FirstName(firstNameText);
                return firstName;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return Enter();
            }
        }
    }
    public static class LastNameEnter
    {
        public static LastName Enter()
        {
            Console.WriteLine("Введите фамилию: ");
            var lastNameText = Console.ReadLine() ?? "";
            try
            {
                var lastName = new LastName(lastNameText);
                return lastName;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return Enter();
            }
        }
    }
    public static class PassportEnter
    {
        public static long Enter()
        {
            Console.WriteLine("Введите данные паспорта: ");
            try
            {
                string passportText = Console.ReadLine() ?? "";
                if (!long.TryParse(passportText, out var passport) || passportText.Length != 10)
                {
                    throw new ArgumentException("Данные паспорта недействительны.");
                }

                return passport;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return Enter();
            }
        }
    }
    public static class PatronymicEnter
    {
        public static string Enter()
        {
            Console.WriteLine("Введите отчество: ");
            string patronymic = Console.ReadLine() ?? "";

            return patronymic;
        }
    }

    public static class SalaryEnter
    {
        public static int Enter()
        {
            Console.WriteLine("Введите зарплату: ");
            try
            {
                if (!int.TryParse(Console.ReadLine(), out var salary))
                {
                    throw new ArgumentException("Данная зарплатная плата недействительна.");
                }

                return salary;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return Enter();
            }
        }
    }
}
