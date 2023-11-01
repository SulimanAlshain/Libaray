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
namespace LogicLayer
{
    public class EmployeeManager : EmployeeManagerInterface
    {
        private EmployeeAccessorInterface empAccessor = new EmployeeAccessor();
        private Employee employee;

        public string GetEmployeeRole()
        {
            employee.Role = empAccessor.selectEmployeeRole(employee.EmployeeID);
            return employee.Role;
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
