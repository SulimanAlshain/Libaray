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
        public string? AuthorName { get; set; }
        public string? BookType { get; set; }
        public string? publisherName { get; set; }
    }
}
