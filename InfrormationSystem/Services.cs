using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrormationSystem
{
    public class EmployeeService : IService<Personal>
    {
        private List<Personal> _personals;

        public EmployeeService()
        {
            _personals = GetAll();
        }

        public IReadOnlyCollection<Personal> Personals => _personals;

        public PersonalBuilder CreateBuilder()
        {
            return new PersonalBuilder(MainService.GetIdGeneratorService().GetPersonalId());
        }

        public void Create(Personal product)
        {
            _personals.Add(product);
        }

        public void Delete(Personal product)
        {
            _personals.Remove(product);
        }

        public void Update(Personal product)
        {
            Personal? acc = _personals.FirstOrDefault(user => user.Id.Equals(product.Id));

            if (acc is null)
            {
                Console.WriteLine("Такого аккаунта не существует.");
                return;
            }

            _personals.Remove(acc);
            _personals.Add(product);
        }

        public void Upload()
        {
            JsonStorage.Save(_personals);
        }

        public List<Personal> GetAll()
        {
            Personal[]? personals = JsonStorage.GetPersonals();
            return personals.ToList();
        }

        public Personal? FindById(int id)
        {
            return _personals.FirstOrDefault(user => user.Id.Equals(id));
        }

        public Personal? FindByUserId(int id)
        {
            return _personals.FirstOrDefault(user => user.UserId.Equals(id));
        }

        public List<Personal>? FindByFirstName(string firstName)
        {
            return _personals.Where(user => user.FirstName.Equals(firstName)).ToList();
        }

        public List<Personal>? FindByLastName(string lastName)
        {
            return _personals.Where(user => user.LastName.Equals(lastName)).ToList();
        }

        public List<Personal>? FindByPatronymic(string patronymic)
        {
            return _personals.Where(user => user.Patronymic.Equals(patronymic)).ToList();
        }

        public List<Personal>? FindByBirthDay(DateTime dateTime)
        {
            return _personals.Where(user => user.BirthDay.Equals(dateTime)).ToList();
        }

        public List<Personal>? FindBySalary(int salary)
        {
            return _personals.Where(user => user.Salary.Equals(salary)).ToList();
        }

        public List<Personal>? FindByPassport(long passport)
        {
            return _personals.Where(user => user.Passport.Equals(passport)).ToList();
        }
    }
    public interface IService<T>
    {
        public void Create(T product);
        public void Delete(T product);
        public void Update(T product);
        public void Upload();
        public List<T> GetAll();
        public T? FindById(int id);
    }
    public class IdGeneratorService
    {
        private IdGenerator? _generator;
        public IdGeneratorService()
        {
            _generator = GetAll();
        }

        public int GetPersonalId()
        {
            return _generator.GeneratePersonalId();
        }

        public int GetUserId()
        {
            return _generator.GenerateUserId();
        }

        public void Upload()
        {
            JsonStorage.Save(_generator);
        }

        public IdGenerator GetAll()
        {
            return JsonStorage.GetIdGenerator();
        }
    }

    public static class MainService
    {
        private static EmployeeService? _personalService;
        private static UserService? _userService;
        private static IdGeneratorService? _idGeneratorService;

        public static EmployeeService GetEmployeeService()
        {
            return _personalService ??= new EmployeeService();
        }

        public static UserService GetUserService()
        {
            return _userService ??= new UserService();
        }

        public static IdGeneratorService GetIdGeneratorService()
        {
            return _idGeneratorService ??= new IdGeneratorService();
        }


        public static void UploadAll()
        {
            GetUserService().Upload();
            GetEmployeeService().Upload();
            GetIdGeneratorService().Upload();
        }
    }
    public class UserService : IService<User>
{
    private List<User> _users;
    
    public UserService()
    {
        _users = GetAll();
    }

    public IReadOnlyCollection<User> Users => _users;

    public UserBuilder CreateBuilder(Login login, Password password, RoleType roleType)
    {
        return new UserBuilder(login,password,roleType, MainService.GetIdGeneratorService().GetUserId());
    }
    
    public void Create(User product)
    {
        _users.Add(product);
    }

    public void Delete(User product)
    {
        _users.Remove(product);
    }

    public void Update(User product)
    {
        User? acc = _users.FirstOrDefault(user => user.Id.Equals(product.Id));

        if (acc is null)
        {
            Console.WriteLine("Такого аккаунта не существует.");
            return;
        }
        
        _users.Remove(acc);
        _users.Add(product);
    }

    public void Upload()
    {
        JsonStorage.Save(_users);
    }

    public List<User> GetAll()
    {
        User[]? users = JsonStorage.GetUsers();
        return users.ToList();
    }

    public User? FindById(int id)
    {
        return _users.FirstOrDefault(user => user.Id.Equals(id));
    }

    public User? FindByLoginPassword(string login, string password)
    {
        return _users.FirstOrDefault(user =>
            user.Login.Equals(login) && user.Password.Equals(password));
    }
}
}
