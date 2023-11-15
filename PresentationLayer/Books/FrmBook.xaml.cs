using DataObjectLayer;
using LogicLayer;
using LogicLayerInterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PresentationLayer.Books
{
    /// <summary>
    /// Interaction logic for FrmBooks.xaml
    /// </summary>
    public partial class FrmBook : Window
    {
        private BooksMangerInterface bookManager = new BooksManager();
        private Book book = null;
        public FrmBook()
        {
            InitializeComponent();
            book = new Book();
            lblTitle.Content = "New Book";
            List<string> authorsNames = new List<string>();
            authorsNames = bookManager.getAuthorsLastName();
            cmbAuthorName.ItemsSource = authorsNames;
            List<string> bookTypes = new List<string>();
            bookTypes = bookManager.getBooksTypesIds();
            cmbBookType.ItemsSource = bookTypes;
            List<string> publishersNames = new List<string>();
            publishersNames = bookManager.getPublishersName();
            cmbPublisherName.ItemsSource = publishersNames;
        }

        public FrmBook(Book book)
        {
            InitializeComponent();
            lblTitle.Content = "Update Book";
            this.book = book;

            txtBookName.Text = book.BookName;

            List<string> authorsNames = new List<string>();
            authorsNames = bookManager.getAuthorsLastName();
            cmbAuthorName.ItemsSource = authorsNames;
            cmbAuthorName.SelectedItem = book.AuthorName;

            List<string> bookTypes = new List<string>();
            bookTypes = bookManager.getBooksTypesIds();
            cmbBookType.ItemsSource = bookTypes;
            cmbBookType.SelectedItem = book.BookType;

            List<string> publishersNames = new List<string>();
            publishersNames = bookManager.getPublishersName();
            cmbPublisherName.ItemsSource = publishersNames;
            cmbPublisherName.SelectedItem = book.publisherName;

            cbActive.IsChecked = book.Active;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!validateForm()) {
                return;
            }
            book.BookName = txtBookName.Text;
            book.AuthorName = cmbAuthorName.SelectedItem.ToString();
            book.BookType = cmbBookType.SelectedItem.ToString();
            book.publisherName = cmbPublisherName.SelectedItem.ToString();
            book.Active = cbActive.IsChecked == true;
            int result = 0;
            if (lblTitle.Content.ToString() == "New Book")
            {
                result = bookManager.addBook(book);
            }
            else {
                result = bookManager.editBook(book);
            }
            
            if (result != 0)
            {
                lblFormMessage.Content = "book added";
            }
            else {
                lblFormMessage.Content = "this book did not added, please contact admin";
            }
        }

        private bool validateForm()
        {
            if (txtBookName.Text.Length == 0)
            {
                lblNameError.Content = "Book Name is require";
                return false;
            }
            if (cmbAuthorName.SelectedItem == null)
            {
                lblAuthorError.Content = "Author name require";
                return false;
            }
            if (cmbBookType.SelectedItem == null)
            {
                lblTypeError.Content = "book type is require";
                return false;
            }
            if (cmbPublisherName.SelectedItem == null) {
                lblPublisherError.Content = "publisher name is require";
                return false;
            }
            lblNameError.Content = "";
            lblAuthorError.Content = "";
            lblTypeError.Content = "";
            lblPublisherError.Content = "";
            return true;
        }
    }
}
