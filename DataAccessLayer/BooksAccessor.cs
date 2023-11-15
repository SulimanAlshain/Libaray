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
        public int insertBook(Book book)
        {
            int result = 0;
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_sp_insert_book", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookName", book.BookName);
            cmd.Parameters.AddWithValue("@AuthorName", book.AuthorName);
            cmd.Parameters.AddWithValue("@BookType", book.BookType);
            cmd.Parameters.AddWithValue("@publisherName", book.publisherName);
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
                        book.BookType = reader.GetString(2);
                        book.AuthorName = reader.GetString(3);                        
                        book.publisherName = reader.GetString(4);
                        book.Active = reader.GetBoolean(5);
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

        public int updateBook(Book book)
        {
            int result = 0;
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_update_book", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookID", book.BookID);
            cmd.Parameters.AddWithValue("@BookName", book.BookName);
            cmd.Parameters.AddWithValue("@AuthorName", book.AuthorName);
            cmd.Parameters.AddWithValue("@BookType", book.BookType);
            cmd.Parameters.AddWithValue("@publisherName", book.publisherName);
            cmd.Parameters.AddWithValue("@Active", book.Active);
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
    }
}
