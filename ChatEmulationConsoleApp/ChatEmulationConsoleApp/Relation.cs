using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatEmulationConsoleApp
{
    public class UserRelations
    {
        HashSet<Friendship> Friendships { get; set; }
        public UserRelations()
        {
            Friendships = new HashSet<Friendship>();
        }

        bool Add(Friendship friendship)
        {
            return Friendships.Add(friendship);
        }
    }
    public class Friendship
    {
        HashSet<User> pair = new HashSet<User>();
        
        public User First { get { return pair.First(); } }

        public User Second { get { return pair.Last(); } }

        public Friendship(User user1, User user2)
        {
            pair.Add(user1);
            pair.Add(user2);
        }
    
    }
}
