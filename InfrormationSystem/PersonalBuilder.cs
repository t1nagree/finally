using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrormationSystem
{
    public class PersonalBuilder : IBuilder<Personal>
    {
        private Personal _personal;
        public PersonalBuilder(int personalId)
        {
            _personal = new Personal();
            _personal.Id = personalId;
        }

        public Personal GetResult()
        {
            return _personal;
        }

        public PersonalBuilder SetUser(User user)
        {
            _personal.UserId = user.Id;
            return this;
        }

        public PersonalBuilder SetFirstName(FirstName firstName)
        {
            _personal.FirstName = firstName.FirstNameText;
            return this;
        }

        public PersonalBuilder SetLastName(LastName lastName)
        {
            _personal.LastName = lastName.LastNameText;
            return this;
        }

        public PersonalBuilder SetPatronymic(string patronymic)
        {
            _personal.Patronymic = patronymic;
            return this;
        }

        public PersonalBuilder SetBirthDay(DateTime birthDay)
        {
            _personal.BirthDay = birthDay;
            return this;
        }

        public PersonalBuilder SetPassport(long passport)
        {
            _personal.Passport = passport;
            return this;
        }

        public PersonalBuilder SetSalary(int salary)
        {
            _personal.Salary = salary;
            return this;
        }
    }
}
