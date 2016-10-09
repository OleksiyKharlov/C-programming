using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatEmulationConsoleApp
{
    public interface IUsersCollection
    {
        IDictionary<Guid, User> Users { get; }

        void AddUser(User newUser);

        bool ReplaceUser(Guid id, User raplacement);

        bool DeleteUser(Guid id);
    }

    class UsersCollection : IUsersCollection
    {
        public IDictionary<Guid, User> Users { get; }

        public UsersCollection()
        {
            Users = new Dictionary<Guid, User>();
        }

        public void AddUser(User newUser)
        {
            Users.Add(newUser.ID, newUser);
        }

        public bool DeleteUser(Guid id)
        {
            if (Users.ContainsKey(id))
            {
                Users.Remove(id);
                return true;
            }
            return false;
        }

        public bool ReplaceUser(Guid id, User replacementUser)
        {
            if (Users.ContainsKey(id))
            {
                replacementUser.ID = id;
                Users.Remove(id);
                Users.Add(id, replacementUser);
                return true;
            }
            return false;
        }

    }
}
