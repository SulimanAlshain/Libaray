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
    public class BooksAccessor : BooksAccessorInterface
    {
        public List<string> selectAuthorsLastName()
        {
            List<string> authors = new List<string>();
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_select_all_authors_lastName", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        authors.Add(reader.GetString(0));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return authors;
        }

        public List<Book> selectBooks()
        {
            List<Book> books = new List<Book>();
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_select_all_books", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Book book = new Book();
                        book.BookID = reader.GetInt32(0);
                        book.BookName = reader.GetString(1);
                        book.AuthorName = reader.GetString(2);
                        book.BookType = reader.GetString(3);
                        book.publisherName = reader.GetString(4);
                        books.Add(book);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return books;
        }

        public List<string> selectPublishersName()
        {
            List<String> publishers = new List<String>();
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_select_all_publishers_name", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        publishers.Add(reader.GetString(0));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return publishers;
        }

        public List<string> selectTypesIDs()
        {
            List<String> types = new List<String>();
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_select_all_books_Types_Id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        types.Add(reader.GetString(0));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return types;
        }
    }
}
