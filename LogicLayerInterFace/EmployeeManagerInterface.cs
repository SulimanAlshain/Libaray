using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterFace
{
    public interface EmployeeManagerInterface
    {
        public bool VerifyUser(String userName, String password);
    }
}
