using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer;

namespace DataAccessInterface
{
    public interface RecieptionAccessorInterface
    {
        public List<BookRent> selectAll();
    }
}
