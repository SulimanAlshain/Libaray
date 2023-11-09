using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayerInterFace;
using DataAccessInterface;
using DataAccessLayer;
using System.Security.Cryptography;
using DataObjectLayer;
using System.Collections;
namespace LogicLayer
{
    public class EmployeeManager : EmployeeManagerInterface
    {
        private EmployeeAccessorInterface empAccessor = new EmployeeAccessor();
        private Employee employee = new Employee();

        public int addEmployee(Employee employee)
        {
            int result = 0;
            employee.password = hashSHA256(employee.password);
            result = empAccessor.insertEmployee(employee);
            return result;
        }

        public int editEmployee(Employee employee)
        {
            int reult = 0;
            employee.password = hashSHA256(employee.password);
            reult = empAccessor.updateEmployee(employee);
            return reult;
        }

        public string GetEmployeeRole()
        {
            employee.Role = empAccessor.selectEmployeeRole(employee.EmployeeID);
            return employee.Role;
        }

        public List<Employee> getEmployees()
        {
            List<Employee> employees = empAccessor.selectEmployees();
            return employees;
        }

        public List<Employee> getEmployees(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool VerifyUser(string userName, string password)
        {
            bool result = false;
            int value = empAccessor.verifyUser(userName, hashSHA256(password));
            if (value > 0) { 
                result = true; 
                employee = new Employee();
                employee.EmployeeID = value;
            }
            return result;
        }
        private string hashSHA256(string source)
        {
            string result = "";
            byte[] data;
            using (SHA256 sha256sha = SHA256.Create())
            {
                data = sha256sha.ComputeHash(Encoding.UTF8.GetBytes(source));
            }
            var s = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }
            result = s.ToString();
            return result;
        }
    }
}
