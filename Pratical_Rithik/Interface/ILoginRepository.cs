using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pratical_Rithik.Models;

namespace Pratical_Rithik.Interface
{
    interface ILoginRepository
    {
        bool Login(LoginModel login);
        void LogOut();
    }
}
