using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrormationSystem
{
    public static class ChooseEmployee
    {
        public static void Start(Personal personal)
        {
            personal.ConsoleOutput();
            Console.WriteLine();
            string[] adminMenuItems = {
            "0 - Изменить сотрудника",
            "1 - Удалить сотрудника",
            "2 - Выход" };
            int result = Menu.GenerateMenu(adminMenuItems);

            switch (result)
            {
                case 0:
                    EditPersonal.Start(personal);
                    break;
                case 1:
                    MainService.GetEmployeeService().Delete(personal);
                    Console.WriteLine("Авторизация прошла успешно!");
                    return;
                case 2:
                    return;
            }
            Start(personal);
        }
    }
    public class ChooseUser
    {
        public static User Start(IReadOnlyCollection<User> users)
        {
            Console.WriteLine("Выберите пользователя");
            Console.WriteLine($"{"ID",5}|{"Login",15}|");
            List<string> res = new List<string>();
            foreach (User user in users)
            {
                res.Add($"{user.Id,5}|{user.Login,15}|");
            }

            int choose = Menu.GenerateMenu(res.ToArray());

            return users.ElementAt(choose);
        }
    }
    public static class CreateEmployee
    {
        public static void Start()
        {
            FirstName firstName = FirstNameEnter.Enter();
            LastName lastName = LastNameEnter.Enter();
            string patronymic = PatronymicEnter.Enter();
            long passport = PassportEnter.Enter();
            int salary = SalaryEnter.Enter();
            DateTime birthDay = BirthDayEnter.Enter();
            User user = ChooseUser.Start(MainService.GetUserService().Users);

            Personal personal = MainService.GetEmployeeService().CreateBuilder()
                .SetPatronymic(patronymic)
                .SetBirthDay(birthDay)
                .SetFirstName(firstName)
                .SetLastName(lastName)
                .SetUser(user)
                .SetPassport(passport)
                .SetSalary(salary).GetResult();

            MainService.GetEmployeeService().Create(personal);

            Console.WriteLine("Авторизация прошла успешно.");
        }
    }

    public static class CreateUser
    {
        public static void Start(RoleType roleType)
        {
            Console.WriteLine("Введите логин: ");
            string loginText = Console.ReadLine() ?? "";
            Login login = new Login(loginText);

            Console.WriteLine("Введите пароль: ");
            string passwordText = Console.ReadLine() ?? "";
            Password password = new Password(passwordText);


            User user = MainService.GetUserService()
                .CreateBuilder(login, password, roleType).GetResult();

            MainService.GetUserService().Create(user);
            Console.WriteLine("Авторизация прошла успешно!");
        }
    }

    public static class EditPersonal
    {
        public static void Start(Personal personal)
        {
            string[] adminMenuItems = {
            "1 - Изменить дату рождения",
            "2 - Изменить имя",
            "3 - Изменить фамилию",
            "4 - Изменить данные паспорта",
            "5 - Изменить отчество",
            "6 - Изменить зарлпату",
            "7 - Изменить ID пользователя",
            "Exit" };
            int result = Menu.GenerateMenu(adminMenuItems);

            switch (result)
            {
                case 0:
                    DateTime dateTime = BirthDayEnter.Enter();
                    personal.BirthDay = dateTime;
                    break;
                case 1:
                    FirstName firstName = FirstNameEnter.Enter();
                    personal.FirstName = firstName.FirstNameText;
                    break;
                case 2:
                    LastName lastName = LastNameEnter.Enter();
                    personal.LastName = lastName.LastNameText;
                    break;
                case 3:
                    long passport = PassportEnter.Enter();
                    personal.Passport = passport;
                    break;
                case 4:
                    string patronymic = PatronymicEnter.Enter();
                    personal.Patronymic = patronymic;
                    break;
                case 5:
                    int salary = SalaryEnter.Enter();
                    personal.Salary = salary;
                    break;
                case 6:
                    User user = ChooseUser.Start(MainService.GetUserService().Users);
                    personal.UserId = user.Id;
                    break;
                case 7:
                    return;
            }
            Start(personal);
        }
    }
    public static class GetEmployee
    {
        public static void Start()
        {
            string[] adminMenuItems = { "1- ID сотрудника",
            "2 - ID users",
            "3 - Имя",
            "4 - Фамилия",
            "5 - Отчество",
            "6 - Дата рождения",
            "7 - Данные паспорта",
            "8 - Зарплатная плата",
            "9 - Вывести список всех сотрудников",
            "10 - Выход" };
            int result = Menu.GenerateMenu(adminMenuItems);

            switch (result)
            {
                case 0:
                    GetByEmployeeId.Start();
                    break;
                case 1:
                    GetByUserId.Start();
                    break;
                case 2:
                    GetByFirstName.Start();
                    break;
                case 3:
                    GetByLastName.Start();
                    break;
                case 4:
                    GetByPatronymic.Start();
                    break;
                case 5:
                    GetByBirthDay.Start();
                    break;
                case 6:
                    GetByPassport.Start();
                    break;
                case 7:
                    GetBySalary.Start();
                    break;
                case 8:
                    GetAllEmployees.Start();
                    break;
                case 9:
                    return;
            }
            Start();
        }
    }
    public static class ShowEmployee
    {
        public static void Start(IReadOnlyCollection<Personal> personals)
        {
            Console.WriteLine($"{"ID персонала",15}|{"Имя",15}|{"Фамилия",25}|{"Отчество",25}|");
            List<string> res = new List<string>();
            foreach (Personal personal in personals)
            {
                res.Add($"{personal.Id,15}|{personal.FirstName,15}|{personal.LastName,25}|{personal.Patronymic,25}|");
            }

            int choose = Menu.GenerateMenu(res.ToArray());

            ChooseEmployee.Start(personals.ElementAt(choose));
        }
    }


}
