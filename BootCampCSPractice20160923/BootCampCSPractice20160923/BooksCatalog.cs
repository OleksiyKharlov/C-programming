using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;


namespace BootCampCSPractice20160923
{
    class BooksCatalog
    {
        public List<Book> books = new List<Book>();

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

            foreach (var book in books)
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

}
