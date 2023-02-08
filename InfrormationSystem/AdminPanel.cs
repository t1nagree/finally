using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrormationSystem
{
    public class AdminPanel : IPanel
    {
        public void StartPanel(User user)
        {
            Console.WriteLine($"Ваш логин: \n{user.Login}\n");
            string[] adminMenuItems = { "0 - Создать админа", "1 - Создать менеджера", "2 - Создать сотрудника", "3 - Показать всех сотрудников", "4 - Выход" };
            int result = Menu.GenerateMenu(adminMenuItems);

            switch (result)
            {
                case 0:
                    CreateUser.Start(RoleType.AdminManager);
                    break;
                case 1:
                    CreateUser.Start(RoleType.EmployeeManager);
                    break;
                case 2:
                    CreateUser.Start(RoleType.Employee);
                    CreateEmployee.Start();
                    break;
                case 3:
                    GetAllEmployees.Start();
                    break;
                case 4:
                    MainService.UploadAll();
                    return;
            }
            StartPanel(user);
        }
    }
    public class EmployeeManagerPanel : IPanel
    {
        public void StartPanel(User user)
        {
            Console.WriteLine($"Ваш логин: \n{user.Login}\n");
            string[] adminMenuItems = { "0 - Создать нового сотрудника.", "1 - Получить список сотрудников.", "2 - Выход" };
            int result = Menu.GenerateMenu(adminMenuItems);

            switch (result)
            {
                case 0:
                    CreateEmployee.Start();
                    break;
                case 1:
                    GetEmployee.Start();
                    break;
                case 2:
                    MainService.UploadAll();
                    return;
            }
            StartPanel(user);
        }
    }
    public interface IPanel
    {
        public void StartPanel(User user);
    }
}
