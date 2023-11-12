using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer;

namespace DataAccessInterface
{
    public interface BooksAccessorInterface
    {
        int insertBook(Book book);
        List<string> selectAuthorsLastName();
        public List<Book> selectBooks();
        List<string> selectPublishersName();
        List<string> selectTypesIDs();
    }
}
