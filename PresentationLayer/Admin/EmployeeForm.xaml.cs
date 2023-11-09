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
using DataObjectLayer;

namespace PresentationLayer.Admin
{
    /// <summary>
    /// Interaction logic for EmployeeForm.xaml
    /// </summary>
    public partial class EmployeeForm : Window
    {
        EmployeeManagerInterface employeeManager = null;
        private Employee oldEmployeeData = null;
        public EmployeeForm()
        {
            InitializeComponent();
            employeeManager = new EmployeeManager();
        }
        public EmployeeForm(Employee employee)
        {
            InitializeComponent();
            employeeManager = new EmployeeManager();
            this.oldEmployeeData = employee;
            lblFormTitle.Content = "Edit";
            putEmployeeDataInForm();
        }

        private void putEmployeeDataInForm()
        {
            txtGivenName.Text = oldEmployeeData.GivenName;
            txtFamilyName.Text = oldEmployeeData.FamilyName;
            txtEmail.Text = oldEmployeeData.Email;
            txtPassword.Text = oldEmployeeData.password;
            txtRole.Text = oldEmployeeData.Role;
            txtPhoneName.Text = oldEmployeeData.Phone;
            cbActive.IsChecked = oldEmployeeData.Active;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            bool isFormDataValid = validateForm();
            if (!isFormDataValid) {
                lblFormMessage.Content = "Data not valid";
                return;
            }
            Employee employee = new Employee();
            employee.GivenName = txtGivenName.Text;
            employee.FamilyName = txtFamilyName.Text;
            employee.Phone = txtPhoneName.Text;
            employee.Email = txtEmail.Text;
            employee.Role = txtRole.Text;
            employee.password = txtPassword.Text;
            if (cbActive.IsChecked == true)
            {
                employee.Active = true;
            }
            else
            {
                employee.Active = false;
            }

            if (lblFormTitle.Content.ToString() == "New")
            {
                int result = employeeManager.addEmployee(employee);
                lblFormMessage.Content = "Employee added correctly";
            }
            else
            {
                employee.EmployeeID = oldEmployeeData.EmployeeID;
                int result = employeeManager.editEmployee(employee);
            }
            
            clearForm();
            
        }

        private void clearForm()
        {
            txtGivenName.Text = "";
            txtFamilyName.Text = "";
            txtEmail.Text = "";
            txtPhoneName.Text = "";
            txtRole.Text = "";
            txtPassword.Text = "";
            cbActive.IsChecked = false;
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
            if (txtPassword.Text.Length < 6)
            {
                lblErrorPassword.Content = "minimum length of password is 6";
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
