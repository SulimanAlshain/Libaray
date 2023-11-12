using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayerInterFace;
using DataObjectLayer;
using DataAccessInterface;
using DataAccessLayer;

namespace LogicLayer
{
    public class BooksManager : BooksMangerInterface
    {
        private BooksAccessorInterface booksAccessor = new BooksAccessor();

        public List<string> getAuthorsLastName()
        {
           List<string> authors = new List<string>();
            authors = booksAccessor.selectAuthorsLastName();
            return authors;
        }

        public List<Book> getBooks()
        {
            List<Book> Books = new List<Book>();
            Books = booksAccessor.selectBooks();
            return Books;
        }

        public List<string> getBooksTypesIds()
        {
            List<String> types = new List<String>();
            types = booksAccessor.selectTypesIDs();
            return types;
        }

        public List<string> getPublishersName()
        {
            List <String> publishers = new List<String>();
            publishers = booksAccessor.selectPublishersName();
            return publishers;
        }
    }
}
