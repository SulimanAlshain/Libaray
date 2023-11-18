using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectLayer
{
    public class BookRent
    {
        public int Id { get; set; }
        public string? BookName { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerEmail {  get; set; }
        public string? RentDate { get; set;}
        public string? RentType { get; set; }
        public string? ReturnDate { get; set; }
        public string? Price { get; set; }

    }
}
