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
        List<string> getAuthorsLastName();
        public List<Book> getBooks();
        List<string> getBooksTypesIds();
        List<string> getPublishersName();
    }
}
