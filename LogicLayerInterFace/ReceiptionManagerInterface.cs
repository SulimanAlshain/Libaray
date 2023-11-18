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
        public List<BookRent> getAll();
    }
}
