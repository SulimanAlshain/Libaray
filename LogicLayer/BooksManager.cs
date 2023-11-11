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
        public List<Book> getBooks()
        {
            List<Book> Books = new List<Book>();
            Books = booksAccessor.selectBooks();
            return Books;
        }
    }
}
