using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatEmulationConsoleApp
{
   

    public enum UserStatus
    {
        Active,
        Inactive
    }

    public enum GenderName
    {
        Male,
        Female,
        Other
    }

    public class User : BaseChatElement
    {

        public UserStatus CurrentStatus { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Info { get; set; }

        public string Email { get; set; }

        public  GenderName Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public IRoomsCollection RoomsList { get; set; }

        public IUsersCollection FriendsList { get; set; }

        public User() : base()
        {
            RoomsList = new RoomsCollection();
            FriendsList = new UsersCollection();
        }
    }


}
