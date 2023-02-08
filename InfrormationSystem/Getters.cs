using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrormationSystem
{
    public static class GetAllEmployees
    {
        public static void Start()
        {
            ShowEmployee.Start(MainService.GetEmployeeService().Personals);
        }
    }

    public static class GetByBirthDay
    {
        public static void Start()
        {

            DateTime dob = BirthDayEnter.Enter();

            List<Personal>? personal = MainService.GetEmployeeService().FindByBirthDay(dob);

            if (personal is null)
            {
                throw new ArgumentException("Такого сотрудника не существует.");
            }

            ShowEmployee.Start(personal);
        }
    }

    public static class GetByEmployeeId
    {
        public static void Start()
        {
            int id = EmployeeIdEnter.Enter();

            Personal? personal = MainService.GetEmployeeService().FindById(id);

            if (personal is null)
            {
                throw new ArgumentException("Сотрудник отсутсвует");
            }

            ShowEmployee.Start(new List<Personal> { personal });
        }
    }
    public static class GetByFirstName
    {
        public static void Start()
        {
            FirstName firstName = FirstNameEnter.Enter();

            List<Personal>? personal = MainService.GetEmployeeService().FindByFirstName(firstName.FirstNameText);

            if (personal is null)
            {
                throw new ArgumentException("Сотрудник отсутствует.");
            }

            ShowEmployee.Start(personal);
        }
    }
    public static class GetByLastName
    {
        public static void Start()
        {
            LastName lastName = LastNameEnter.Enter();

            List<Personal>? personal = MainService.GetEmployeeService().FindByLastName(lastName.LastNameText);

            if (personal is null)
            {
                throw new ArgumentException("Сотрудник не существует.");
            }

            ShowEmployee.Start(personal);
        }
    }
    public class GetByPassport
    {
        public static void Start()
        {
            long passport = PassportEnter.Enter();

            List<Personal>? personal = MainService.GetEmployeeService().FindByPassport(passport);

            if (personal is null)
            {
                throw new ArgumentException("Сотрудник не сущетсвует.");
            }

            ShowEmployee.Start(personal);
        }
    }

    public class GetByPatronymic
    {
        public static void Start()
        {
            string patronymic = PatronymicEnter.Enter();

            List<Personal>? personal = MainService.GetEmployeeService().FindByPatronymic(patronymic);

            if (personal is null)
            {
                throw new ArgumentException("Сотрудник не сущестсвует.");
            }

            ShowEmployee.Start(personal);
        }
    }
    public static class GetBySalary
    {
        public static void Start()
        {
            int salary = SalaryEnter.Enter();

            List<Personal>? personal = MainService.GetEmployeeService().FindBySalary(salary);

            if (personal is null)
            {
                throw new ArgumentException("Сотрудник не существует.");
            }

            ShowEmployee.Start(personal);
        }
    }
    public static class GetByUserId
    {
        public static void Start()
        {
            Console.WriteLine("Введите ID пользователя.");
            int id = -1;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                throw new ArgumentException("Данный ID недействителен.");
            }

            Personal? personal = MainService.GetEmployeeService().FindByUserId(id);

            if (personal is null)
            {
                throw new ArgumentException("Такого сотрудника не существует.");
            }

            ShowEmployee.Start(new List<Personal> { personal });
        }
    }


}
