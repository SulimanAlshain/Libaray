﻿using System;
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
    }
}
