using System;

namespace BootCampCSPractice20160923
{

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
}
