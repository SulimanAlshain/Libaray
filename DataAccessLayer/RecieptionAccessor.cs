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
        public int InsertRent(BookRent bookRent)
        {
            int result = 0;
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_insert_book_rent", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookName", bookRent.BookName);
            cmd.Parameters.AddWithValue("@CustomerName", bookRent.CustomerName);
            cmd.Parameters.AddWithValue("@CustomerEmail", bookRent.CustomerEmail);
            cmd.Parameters.AddWithValue("@RentDate", bookRent.RentDate);
            cmd.Parameters.AddWithValue("@RentType", bookRent.RentType);
            cmd.Parameters.AddWithValue("@ReturnDate", bookRent.ReturnDate);
            cmd.Parameters.AddWithValue("@Price", bookRent.Price);
            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return result;
        }

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
