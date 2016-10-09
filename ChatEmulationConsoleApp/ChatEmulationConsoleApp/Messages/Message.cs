using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatEmulationConsoleApp
{
    public interface IMessageContainer
    {
        ICollection<Message> Messages { get; set; }
    }
    public class AllMessages: IMessageContainer
    {
        public ICollection<Message> Messages { get; set; }
    }

    public enum MessageTypes
    {
        HiddenService,
        OpenService,
        Normal
    }
    public class Message : BaseChatElement
    {

        public User Author { get; }

        public Room Room { get; }

        public DateTime TimeStamp { get; set; }

        public string Text { get; set; }

        public Message(User author, Room room, string text): base()
        {
            Author = author;
            Room = room;
            TimeStamp = DateTime.UtcNow;
            Text = text;
        }


        public override string ToString()
        {
            return
                $"In {Room.Name} ({TimeStamp.ToString()}) {Author.FirstName} {Author.LastName} wrote:\n {Text}";
        }
    }
}
