using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatEmulationConsoleApp
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            #region User Creation and testing
            var userBuilder = new UserBuilder();
            var Users = new UsersCollection();

            userBuilder.SetFirstName("Oleksiy");
            userBuilder.SetLastName("Kharlov");
            userBuilder.SetGender(GenderName.Male);
            userBuilder.SetInfo("");
            userBuilder.SetEmail("alex.harlov@gmail.com");
            userBuilder.SetLogin("alex");
            userBuilder.SetPassword("2112");
            userBuilder.SetDateOfBirth(new DateTime(1982, 8, 1));
            Users.AddUser(userBuilder.GetResult());

            IEnumerable<User> userQuery = from n in Users.Users.Values where (n.FirstName == "Oleksiy" && n.LastName == "Kharlov") select n;
            var me = userQuery.First();
            //Console.WriteLine($"{me.FirstName} {me.LastName}");
            //Console.WriteLine($"login: {me.Login}, password: {me.Password}");
            //Console.WriteLine($"{me.Gender}");
            #endregion

            IMessageContainer testMessageCollection = new AllMessages();

            
           
           
            Console.ReadKey(true);
        }
    }
}
