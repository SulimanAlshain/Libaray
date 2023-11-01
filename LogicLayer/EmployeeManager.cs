using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayerInterFace;
namespace LogicLayer
{
    public class EmployeeManager : EmployeeManagerInterface

    {
        public bool VerifyUser(string userName, string password)
        {
            return true;
        }
    }
}
