using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer;
using DataAccessLayer;
using DataAccessInterface;
using LogicLayerInterFace;

namespace LogicLayer
{
    public class RecieptionManager : ReceiptionManagerInterface
    {
        private RecieptionAccessorInterface recieptionAccessor;
        public RecieptionManager()
        {
            recieptionAccessor = new RecieptionAccessor();
        }

        public int addRent(BookRent bookRent)
        {
            int result = 0;
            result = recieptionAccessor.InsertRent(bookRent);
            return result;
        }

        public List<BookRent> getAll()
        {
            List<BookRent> booksRents = new List<BookRent>();
            booksRents = recieptionAccessor.selectAll();
            return booksRents;
        }
    }
}
