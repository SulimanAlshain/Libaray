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
        public List<Employee> selectBooks();
    }
}
