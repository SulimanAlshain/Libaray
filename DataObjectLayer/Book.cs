using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectLayer
{
    public class Book
    {
        public int BookID { get; set; }
        public string? BookName { get; set; }
        public int AuthorID { get; set; }
        public string? BookType { get; set; }
        public int publisher { get; set; }
    }
}
