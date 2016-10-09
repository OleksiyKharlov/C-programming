using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatEmulationConsoleApp
{
    interface IUserBuilder
    {

        void SetLogin(string login);

        void SetPassword(string password);

        void SetFirstName(string firstName);

        void SetLastName(string lastName);

        void SetInfo(string info);

        void SetGender(GenderName gender);

        void SetDateOfBirth(DateTime dateOfBirth);

        void SetEmail(string email);

        User GetResult();

    }
}
