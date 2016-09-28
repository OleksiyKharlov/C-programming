using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampCSPractice20160923
{
    class BooksCatalog
    {
        public List<Book> books = new List<Book>();

        
        public class Book
        {
            public string Id { get; set; }
            public string Author { get; set; }
            public string Title { get; set; }
            public string Genre { get; set; }
            public double Price { get; set; }
            public DateTime PublishDate { get; set; }
            public string Description { get; set; }

            public Book(
                string id,
                string author,
                string title,
                string genre,
                double price,
                DateTime publishdate,
                string desc)
            {
                Id = id;
                Author = author;
                Title = title;
                Genre = genre;
                Price = price;
                PublishDate = publishdate;
                Description = desc;
            }
            public override string ToString()
            {   
                return string.Format("ID: {0}\nAuthor: {1}\nTitle: {2}\nGenre: {3}\nPrice: {4}\nPublish date: {5}\nDescription: {6}",
                    Id, Author, Title, Genre, Price, PublishDate.ToLongDateString(), Description);
            }
        }
        public BooksCatalog(string xmlFilename)
        {
            XDocument xmlDoc = XDocument.Load(xmlFilename);
            if (xmlDoc != null && xmlDoc.Root.Name == "catalog")
            {
                XElement xmlElmCatalog = xmlDoc.Element("catalog");
                if (xmlElmCatalog != null && xmlElmCatalog.HasElements)
                {
                    foreach (var xmlElmBook in xmlElmCatalog.Elements())
                    {
                        var Id = xmlElmBook.Attributes().FirstOrDefault(n => n.Name == "id").Value;
                        var Author = xmlElmBook.Elements().FirstOrDefault(n => n.Name == "author").Value;
                        var Title = xmlElmBook.Elements().FirstOrDefault(n => n.Name == "title").Value;
                        var Genre = xmlElmBook.Elements().FirstOrDefault(n => n.Name == "genre").Value;
                        var Price = double.Parse(xmlElmBook.Elements().FirstOrDefault(n => n.Name == "price").Value);
                        var PublDate = DateTime.Parse(xmlElmBook.Elements().FirstOrDefault(n => n.Name == "publish_date").Value);
                        var Description = xmlElmBook.Elements().FirstOrDefault(n => n.Name == "description").Value;
                        books.Add(new Book(Id, Author, Title, Genre, Price, PublDate, Description));
                    }
                }
            }
        }

        public void savetoXML(string xmlFilename)
        {
            var xmlCatalog = new XElement("catalog");

            foreach(var book in books)
            {
                var xmlBook = new XElement("book");
                xmlBook.SetAttributeValue("id", book.Id);
                var xmlAuthor = new XElement("author");
                xmlAuthor.Value = book.Author;
                var xmlTitle = new XElement("title");
                xmlTitle.Value = book.Title;
                var xmlGenre = new XElement("genre");
                xmlGenre.Value = book.Genre;
                var xmlPrice = new XElement("price");
                xmlPrice.Value = book.Price.ToString();
                var xmlPublDate = new XElement("publish_date");
                xmlPublDate.Value = book.PublishDate.ToLongDateString();
                var xmlDesc = new XElement("description");
                xmlDesc.Value = book.Description;

                xmlBook.Add(xmlAuthor);
                xmlBook.Add(xmlTitle);
                xmlBook.Add(xmlGenre);
                xmlBook.Add(xmlPrice);
                xmlBook.Add(xmlPublDate);
                xmlBook.Add(xmlDesc);
                xmlCatalog.Add(xmlBook);
            }

            var newXmlDoc = new XDocument(xmlCatalog);
            newXmlDoc.Save(xmlFilename);
        }
    }


    
    class PracticeProgram
    {
        static void EditXml(string xmlFilename)
        {
            var newXdoc = new XDocument(xmlFilename);
            if (newXdoc != null && newXdoc.Root.HasElements) // спосіб перевірки
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

            //var rand = new Random((int)DateTime.Now.Ticks);
            //var Customers = new List<MyCustomer>();
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
            // This works fine here with both MyCollection<> and List<>
            //var result0 = from n in Customers where n.Name.StartsWith("Steve") select n;
            var result0 = Customers.Where(n => n.Name.StartsWith("Steve")).ToList();
            foreach (var i in result0)
            {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine("");
            Console.ReadKey(true);
            // tryparse.
            // When using MyCollection<> (MyCollection is IEnumerable<T>) throws NullReferenceException here.
            // When using List<> here works fine.
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




            //for (int i = 0; i < IntCollection.Length; i++)
            //{
            //    Console.WriteLine("{0}. {1}", i, IntCollection[i]);
            //}
            //Console.ReadKey(true);
        }
    }
}