using System.Collections.Generic;
using System.Linq;

namespace BMS.Data.Services
{
    public class BookService : IBookService
    {
        public void AddBook(Book newbook)
        {
            Data.Books.Add(newbook);
        }

        public void DeleteBook(int id)
        {
            var book = Data.Books.FirstOrDefault(x => x.Id == id);
            Data.Books.Remove(book);
        }

        public List<Book> GetAllBooks()
        {
            return Data.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return Data.Books.FirstOrDefault(n => n.Id == id);
        }

        public void UpdateBook(int id, Book newbook)
        {
            var oldBook = Data.Books.FirstOrDefault(x => x.Id == id);
            if (oldBook != null)
            {
                oldBook.Title = newbook.Title;
                oldBook.Author = newbook.Author;
                oldBook.Description = newbook.Description;
                oldBook.Rate = newbook.Rate;
                oldBook.DateStart = newbook.DateStart;
                oldBook.DateRead = newbook.DateRead;
            }
        }
    }
}
