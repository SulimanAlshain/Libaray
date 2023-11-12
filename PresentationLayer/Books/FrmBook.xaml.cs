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
        public FrmBook()
        {
            InitializeComponent();
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

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
           Book book = new Book();
            if (!validateForm()) {
                return;
            }
            book.BookName = txtBookName.Text;
            book.AuthorName = cmbAuthorName.SelectedItem.ToString();
            book.BookType = cmbBookType.SelectedItem.ToString();
            book.publisherName = cmbPublisherName.SelectedItem.ToString();
            int result = bookManager.addBook(book);
            if (result != 0)
            {
                lblFormMessage.Content = "new book added";
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
