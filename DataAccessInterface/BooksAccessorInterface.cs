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
        public int insertBook(Book book);
        public List<string> selectAuthorsLastName();
        public List<Book> selectBooks();
        public List<string> selectPublishersName();
        public List<string> selectTypesIDs();
        public int updateBook(Book book);
    }
}
