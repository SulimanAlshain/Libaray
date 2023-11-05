using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer;

namespace LogicLayerInterFace
{
    public interface EmployeeManagerInterface
    {
        public int addEmployee(Employee employee);
        public string GetEmployeeRole();
        public List<Employee> getEmployees();
        public bool VerifyUser(String userName, String password);
    }
}
