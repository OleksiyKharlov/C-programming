using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatEmulationConsoleApp
{
    public enum UserRoomRole
    {
        // A person who creates a room
        Owner,

        // A person who entered a room
        Participant
    }
    public enum RoomType
    {
        // Only owner can write - all can see.
        PersonalWall,

        // Personal one to one conversation.
        Conversation,

        // Closed group chat. Only owner can invite new paeople.
        OwnerChat,

        // Closed group chat. Only participants can invite new people.
        PrivateChat,

        // Open discussion/chat group. All can enter by themselves.
        PublicChat
    }
    public class Room : IChatElemant
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public Guid OwnerID { get; set; }

        public RoomType Type { get; set; }

        public IDictionary<Guid, UserRoomRole>

        

    }
}
