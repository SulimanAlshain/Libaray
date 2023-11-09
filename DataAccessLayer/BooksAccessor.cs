using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterface;
using DataObjectLayer;
namespace DataAccessLayer
{
    public class BooksAccessor : BooksAccessorInterface
    {
        public List<Employee> selectBooks()
        {
            List<Employee> result = new List<Employee>();
            return result;
        }
    }
}
