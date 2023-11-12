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
        int addBook(Book book);
        List<string> getAuthorsLastName();
        public List<Book> getBooks();
        List<string> getBooksTypesIds();
        List<string> getPublishersName();
    }
}
