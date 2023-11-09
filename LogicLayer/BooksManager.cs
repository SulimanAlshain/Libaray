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
        public List<Employee> getBooks()
        {
            List<Employee> employees = new List<Employee>();
            employees = booksAccessor.selectBooks();
            return employees;
        }
    }
}
