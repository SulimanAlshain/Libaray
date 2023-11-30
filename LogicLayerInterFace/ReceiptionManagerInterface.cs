using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer;

namespace LogicLayerInterFace
{
    public interface ReceiptionManagerInterface
    {
        public int addRent(BookRent bookRent);
        public List<BookRent> getAll();
        public int updateRent(BookRent bookRent);
    }
}
