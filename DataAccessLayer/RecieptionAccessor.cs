using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterface;
using DataObjectLayer;

namespace DataAccessLayer
{
    public class RecieptionAccessor : RecieptionAccessorInterface
    {
        public List<BookRent> selectAll()
        {
           List<BookRent> bookRents = new List<BookRent>();
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_selectAll_books_rent", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        BookRent bookRent = new BookRent();
                        bookRent.Id = reader.GetInt32(0);
                        bookRent.BookName = reader.GetString(1);
                        bookRent.CustomerName = reader.GetString(2);
                        bookRent.CustomerEmail = reader.GetString(3);
                        bookRent.RentDate = reader.GetString(4);
                        bookRent.RentType = reader.GetString(5);
                        bookRent.ReturnDate = reader.GetString(6);
                        bookRent.Price = reader.GetString(7);
                        bookRents.Add(bookRent);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return bookRents;
        }
    }
}
