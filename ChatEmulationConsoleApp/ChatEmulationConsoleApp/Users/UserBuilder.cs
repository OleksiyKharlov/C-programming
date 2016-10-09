using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatEmulationConsoleApp
{
    class UserBuilder : IUserBuilder
    {
        private User _user;

        public UserBuilder()
        {
            _user = new User();
        }

        public void SetDateOfBirth(DateTime dateOfBirth)
        {
            _user.DateOfBirth = dateOfBirth;
        }

        public void SetFirstName(string firstName)
        {
            _user.FirstName = firstName;
        }

        public void SetGender(GenderName gender)
        {
            _user.Gender = gender;
        }

        public void SetInfo(string info)
        {
            _user.Info = info;
        }

        public void SetLastName(string lastName)
        {
            _user.LastName = lastName;
        }

        public void SetLogin(string login)
        {
            _user.Login = login;
        }

        public void SetPassword(string password)
        {
            _user.Password = password;
        }

        public User GetResult()
        {
            return _user;
        }

        public void SetEmail(string email)
        {
            _user.Email = email;
        }
        
    }
}
