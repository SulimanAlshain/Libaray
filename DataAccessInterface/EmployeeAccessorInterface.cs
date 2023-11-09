using DataObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterface
{
    public interface EmployeeAccessorInterface
    {
        string selectEmployeeRole(int employeeID);
        public int verifyUser(string userName, string password);
        public  List<Employee> selectEmployees();
        int insertEmployee(Employee employee);
        int updateEmployee(Employee employee);
    }
}
