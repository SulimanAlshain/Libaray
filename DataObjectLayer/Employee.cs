using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectLayer
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Phone {  get; set; }
        public string Email { get; set; }
        public string password {  get; set; }
        public bool Active { get; set; }
        public string Role { get; set; }
    }
}
