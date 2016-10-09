using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatEmulationConsoleApp
{
    public class BaseChatElement : IComparable
    {
        public Guid ID { get; }

        public BaseChatElement()
        {
            ID = Guid.NewGuid();
        }

        public int CompareTo(object obj)
        {
            var other = obj as BaseChatElement;
            if (other != null)
                return ID.CompareTo(other.ID);
            else
                throw new ArgumentException("object not BaseChatElement");
        }
    }
}
