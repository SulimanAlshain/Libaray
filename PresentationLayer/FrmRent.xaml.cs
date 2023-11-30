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
using LogicLayer;
using LogicLayerInterFace;
using DataObjectLayer;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for FrmRent.xaml
    /// </summary>
    public partial class FrmRent : Window
    {
        private ReceiptionManagerInterface receiptionManager;
        private BookRent bookRent;
        private BooksMangerInterface booksManager;
        private List<Book> books;
        private bool update;
        public FrmRent()
        {
            InitializeComponent();
            receiptionManager = new RecieptionManager();
            bookRent = new BookRent();
            booksManager = new BooksManager();
            books = new List<Book>();
            books = booksManager.getBooks();
            fillCombos();
            update = false;
        }

        public FrmRent(BookRent bookRent)
        {
            InitializeComponent();
            receiptionManager = new RecieptionManager();
            booksManager = new BooksManager();
            books = new List<Book>();
            books = booksManager.getBooks();
            fillCombos();
            this.bookRent = bookRent;
            fillForm();
            update = true;
        }

        private void fillForm()
        {
            comboBookName.SelectedItem = bookRent.BookName;
            txtCustomerName.Text = bookRent.CustomerName;
            txtCustomerEmail.Text = bookRent.CustomerEmail;
            txtRentDate.Text = bookRent.RentDate;
            txtRentType.Text = bookRent.RentType;
            txtReturnDate.Text = bookRent.ReturnDate;
            txtPrice.Text = bookRent.Price;
            
        }

        private void fillCombos()
        {
            List<string> booksNames = new List<string>();
            foreach (Book book in books)
            {
                if (book.BookName != null)
                {
                    booksNames.Add(book.BookName);
                }                
            }
            comboBookName.ItemsSource = booksNames; 
            comboBookName.SelectedIndex = 0;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!validateData())
            {
                return;
            }
            int result = 0;
            bookRent.BookName = comboBookName.SelectedItem.ToString();
            bookRent.CustomerName = txtCustomerName.Text;
            bookRent.CustomerEmail = txtCustomerEmail.Text;
            bookRent.RentDate = txtRentDate.Text;
            bookRent.RentType = txtRentType.Text;
            bookRent.ReturnDate = txtReturnDate.Text;
            bookRent.Price = txtPrice.Text;
            if (update)
            {
                result = receiptionManager.updateRent(bookRent);
            }
            else
            {
                result = receiptionManager.addRent(bookRent);
            }
            
            if (result == 0)
            {
                lblFormError.Content = "Book did not rented!";
                return;
            }
            lblFormError.Content = "Book rented!";
        }

        private bool validateData()
        {
            if (comboBookName.SelectedItem == null)
            {
                lblFormError.Content = "Book name require!";
                return false;
            }
            if (txtCustomerName.Text.Length == 0)
            {
                lblFormError.Content = "Customer name require!";
                return false;
            }
            if (txtCustomerEmail.Text.Length == 0)
            {
                lblFormError.Content = "Customer Email require!";
                return false;
            }
            if (txtRentDate.Text.Length == 0)
            {
                lblFormError.Content = "Rent date require!";
                return false;
            }
            if (txtRentType.Text.Length == 0)
            {
                lblFormError.Content = "Rent Type require!";
                return false;
            }
            if (txtReturnDate.Text.Length == 0)
            {
                lblFormError.Content = "Return Date require!";
                return false;
            }
            if (txtPrice.Text.Length == 0)
            {
                lblFormError.Content = "Price require!";
                return false;
            }
            lblFormError.Content = "";
            return true;
        }
    }
}
