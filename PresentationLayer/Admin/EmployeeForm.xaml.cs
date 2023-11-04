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

namespace PresentationLayer.Admin
{
    /// <summary>
    /// Interaction logic for EmployeeForm.xaml
    /// </summary>
    public partial class EmployeeForm : Window
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            bool isFormDataValid = validateForm();
            if (!isFormDataValid) {
                lblFormMessage.Content = "لسه الشغل دا ما فاليد";
                return;
            }
            lblFormMessage.Content = "كدا نقدر نفول فاليد :)";
        }

        private bool validateForm()
        {
            if (txtGivenName.Text.Length == 0) {
                lblErrorGivenName.Content = "Given Name Require";
                return false; 
            }
            if (txtFamilyName.Text.Length == 0) {
                lblErrorFamilyName.Content = "Family Name Require";
                return false; 
            }
            if (txtPhoneName.Text.Length == 0) {
                lblErrorPhone.Content = "Phone Require";
                return false; 
            }
            if (txtEmail.Text.Length == 0) {
                lblErrorEmail.Content = "Email Require";
                return false; 
            }
            if (txtPassword.Text.Length == 0) {
                lblErrorPassword.Content = "Password Require";
                return false; 
            }
            if (txtRole.Text.Length == 0) {
                lblErrorRole.Content = "Role Require";
                return false; 
            }
            lblErrorGivenName.Content = "";
            lblErrorFamilyName.Content = "";
            lblErrorPhone.Content = "";
            lblErrorEmail.Content = "";
            lblErrorPassword.Content = "";
            lblErrorRole.Content = "";
            return true;

        }
    }
}
