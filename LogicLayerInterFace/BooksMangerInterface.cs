using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer;

namespace LogicLayerInterFace
{
    public interface BooksMangerInterface
    {
        public int addBook(Book book);
        public List<string> getAuthorsLastName();
        public List<Book> getBooks();
        public List<string> getBooksTypesIds();
        public List<string> getPublishersName();
        public int editBook(Book book);
    }
}
