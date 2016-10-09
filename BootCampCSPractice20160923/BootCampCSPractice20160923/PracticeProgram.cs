using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace BootCampCSPractice20160923
{


    
    class PracticeProgram
    {
        static void EditXml(string xmlFilename)
        {
            var newXdoc = new XDocument(xmlFilename);
            if (newXdoc != null && newXdoc.Root.HasElements)
            {
                var xmlCatalog = new XElement(newXdoc.Element("catalog"));
                if (xmlCatalog != null && xmlCatalog.HasElements)
                {
                    var query1 = xmlCatalog.Elements().Where(n => n.Name == "Genre" && n.Value == "Fantasy");
                    foreach (var el in query1)
                    {
                            el.Value += " Fiction";
                    }
                    newXdoc.Save(xmlFilename);
                }
            }
        }


        static void Main(string[] args)
        {
            var o = new object();

            Console.WriteLine("XML Parser task");
            var MyBooksCatalog = new BooksCatalog("SampleXMLBooks.xml");

            foreach (var el in MyBooksCatalog.books)
            {
                Console.WriteLine(el.ToString());
            }

            MyBooksCatalog.savetoXML("BooksCatalog.xml");

            Console.WriteLine("And now object LINQ, used with my custom generic collection.");
            Console.ReadKey(true);

            var Customers = new MyCollection<MyCustomer>();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Filling customer #{0}:", i + 1);
                Console.Write("Enter name: ");
                var name = Console.ReadLine();
                Console.Write("Enter info: ");
                var someCustomerInfo = Console.ReadLine();
                Console.Write("Enter sales: ");
                int sales;
                try
                {
                    sales = Convert.ToInt32(Console.ReadLine());
                } catch (FormatException)
                {
                    Console.WriteLine("Input error! Sales set to 0!");
                    sales = default(int);
                }
                Customers.Add(new MyCustomer(name, someCustomerInfo, sales));
            }
            Console.WriteLine("Shows all:");
            foreach (MyCustomer i in Customers)
            {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine();
            Console.ReadKey(true);

            var rbc = (IEnumerable<MyCustomer>)Customers;
            if (rbc == null) throw new NullReferenceException();

            Console.WriteLine("Shows all with name \"Steve\"");
            var result0 = Customers.Where(n => n.Name.StartsWith("Steve")).ToList();
            foreach (var i in result0)
            {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine("");
            Console.ReadKey(true);
            Console.WriteLine("Sorted by Name Ascending using LINQ");
            var CustList = Customers.ToList();
            var result = CustList.OrderBy(n => n.Name)
                .ThenByDescending(n => n.Sales).ToArray();
            try
            {
                foreach (var i in result)
                {
                    Console.WriteLine(i.ToString());
                }
                Console.WriteLine();
                Console.ReadKey(true);
            }
            catch {
                Console.WriteLine("Error!");
            }


            var result1 = Customers.AsQueryable().OrderByDescending(n => n.Name).ThenBy(n => n.Sales);

            Console.WriteLine("Sorted by name Descending using LINQ");
            foreach (var i in result1)
            {
                Console.Write("* ");
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine();
            Console.ReadKey(true);
        }
    }
}