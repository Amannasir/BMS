using System.Collections.Generic;

namespace BMS.Data
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        void UpdateBook(int id ,Book newbook);
        void DeleteBook(int id);
        void AddBook(Book newbook);

    }
}
