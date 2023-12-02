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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LogicLayerInterFace;
using LogicLayer;
using DataObjectLayer;
using System.Data;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
     private EmployeeManagerInterface employeeManager;
        private BooksMangerInterface booksManager;
        private ReceiptionManagerInterface receiptionManager;
        public MainWindow()
        {
            InitializeComponent();
            employeeManager = new EmployeeManager();
            booksManager = new BooksManager();
            receiptionManager = new RecieptionManager();
            showTab();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (BtnLogin.Content.ToString() == "login")
            {
                string username = TxtUsername.Text;
                string password = TxtPassword.Password.ToString();
                bool isUserNameValid = ValidateUserName(username);
                bool isPasswordValid = ValidatePassword(password);
                if (isUserNameValid && isPasswordValid)
                {
                    bool isEmployeeVerify = employeeManager.VerifyUser(username, password);
                    if (isEmployeeVerify)
                    {
                        string role = employeeManager.GetEmployeeRole();
                        LblLoginMessages.Content = role;
                        showTab(role);
                        clearAndHidLogin();
                        BtnLogin.Content = "logout";
                    }
                    else
                    {
                        LblLoginMessages.Content = "Username and Password are Valid but Not Verified";
                        return;
                    }
                }
            }
            else
            {
                showLogin();
                BtnLogin.Content = "login";
                showTab("");
            }
            

        }

        private void showLogin()
        {
            LblUsername.Visibility = Visibility.Visible;
            LblPassword.Visibility = Visibility.Visible;
            TxtUsername.Visibility = Visibility.Visible;
            TxtPassword.Visibility = Visibility.Visible;
            TxtUsername.Text = "";
            TxtPassword.Password = "";
        }

        private void clearAndHidLogin()
        {
            LblUsername.Visibility = Visibility.Hidden;
            LblPassword.Visibility = Visibility.Hidden;
            TxtUsername.Visibility = Visibility.Hidden;
            TxtPassword.Visibility = Visibility.Hidden;
            TxtUsername.Text = "";
            TxtPassword.Password = "";
        }

        private void showTab(string role = "")
        {
            if (role == "")
            {
                tabAdmin.Visibility = Visibility.Hidden;
                tabManager.Visibility = Visibility.Hidden;
                tabProcess.Visibility = Visibility.Hidden;
                return;
            }
            if (role == "Admin")
            {
                tabAdmin.Visibility = Visibility.Visible;
                tabManager.Visibility = Visibility.Hidden;
                tabProcess.Visibility = Visibility.Hidden;
                List<Employee> employees = new List<Employee>();
                employees = employeeManager.getEmployees();
                dgEmployees.ItemsSource = employees;
                return;
            }
            if (role == "Manager")
            {
                tabAdmin.Visibility = Visibility.Hidden;
                tabManager.Visibility = Visibility.Visible;
                tabProcess.Visibility = Visibility.Hidden;
                List<DataObjectLayer.Book> books = new List<DataObjectLayer.Book>();
                books = booksManager.getBooks();
                dgBooks.ItemsSource = books;
                return;
            }
            if (role == "Process")
            {
                tabAdmin.Visibility = Visibility.Hidden;
                tabManager.Visibility = Visibility.Hidden;
                tabProcess.Visibility = Visibility.Visible;
                List<BookRent> booksRent = new List<BookRent>();
                booksRent = receiptionManager.getAll();
                dataGridBooksRent.ItemsSource = booksRent;
                return;
            }
        }

        private bool ValidatePassword(string password)
        {
            bool result = true;
            if (password.Length < 6)
            {
                LblLoginMessages.Content = "minimum length of password is 6";
                result = false;
            }
            return result;
        }

        private bool ValidateUserName(string username)
        {
            bool result = true;
            if (username.Length < 8)
            {
                LblLoginMessages.Content = "minimum length of username is 8";
                result = false;
            }
            return result;
        }

        private void newEmployee_Click(object sender, RoutedEventArgs e)
        {
            Admin.EmployeeForm  employeeForm = new Admin.EmployeeForm();
            employeeForm.ShowDialog();
            List<Employee> employees = new List<Employee>();
            employees = employeeManager.getEmployees();
            dgEmployees.ItemsSource = employees;
        }

        private void dgEmployees_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Employee employee = (Employee)dgEmployees.SelectedItem;
            Admin.EmployeeForm employeeForm = new Admin.EmployeeForm(employee);
            employeeForm.ShowDialog();
            List<Employee> employees = new List<Employee>();
            employees = employeeManager.getEmployees();
            dgEmployees.ItemsSource = employees;
        }

        private void btnNewBook_Click(object sender, RoutedEventArgs e)
        {
            Books.FrmBook frmBook = new Books.FrmBook();
            frmBook.ShowDialog();
            List<DataObjectLayer.Book> books = new List<DataObjectLayer.Book>();
            books = booksManager.getBooks();
            dgBooks.ItemsSource = books;

        }

        private void dgBooks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Book book = new Book();
            book = (Book)dgBooks.SelectedItem;
            Books.FrmBook frmBook= new Books.FrmBook(book);
            frmBook.ShowDialog();
            List<DataObjectLayer.Book> books = new List<DataObjectLayer.Book>();
            books = booksManager.getBooks();
            dgBooks.ItemsSource = books;
        }

        private void btnNewRent_Click(object sender, RoutedEventArgs e)
        {
            FrmRent frmRent = new FrmRent();
            frmRent.ShowDialog();
            List<BookRent> booksRent = new List<BookRent>();
            booksRent = receiptionManager.getAll();
            dataGridBooksRent.ItemsSource = booksRent;

        }

        private void dataGridBooksRent_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BookRent bookRent = new BookRent();
            bookRent = (BookRent)dataGridBooksRent.SelectedItem;
            FrmRent frmRent = new FrmRent(bookRent); 
            frmRent.ShowDialog();
            List<BookRent> booksRent = new List<BookRent>();
            booksRent = receiptionManager.getAll();
            dataGridBooksRent.ItemsSource = booksRent;
        }
    }
}
