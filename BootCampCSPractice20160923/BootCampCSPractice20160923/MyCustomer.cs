using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampCSPractice20160923
{
    public class MyCustomer: IComparable, ICloneable
    {
        public string Name { get; set; }
        public string SomeCustomerInfo { get; set; }

        public int Sales { get; set; }

        public MyCustomer(string name, string info, int sales)
        {
            Name = name;
            SomeCustomerInfo = info;
            Sales = sales;
        }

        public int CompareTo(object obj)
        {
            MyCustomer other = obj as MyCustomer;
            if (other != null)
                return Sales.CompareTo(other.Sales);
            else
                throw new ArgumentException("Object not MyCustomer");
        }

        public object Clone()
        {
            return new MyCustomer(Name, SomeCustomerInfo, Sales);
        }
        
        public override string ToString()
        {
            return string.Format("Name: {0}, Info: {1}, Sales: {2}", Name, SomeCustomerInfo, Sales);
        }
    }
}
