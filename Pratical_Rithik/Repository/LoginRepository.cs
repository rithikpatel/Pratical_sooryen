using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Pratical_Rithik.Interface;
using Pratical_Rithik.Models;

namespace Pratical_Rithik.Repository
{
    public class LoginRepository : ILoginRepository
    {
        PracticalEntities _db = new PracticalEntities();

        public bool Login(LoginModel login)
        {
            var IsValid = _db.Logins.Any(p => p.name == login.name && p.passowrd == login.passowrd);
            if (IsValid)
            {
                FormsAuthentication.SetAuthCookie(login.name, false);
                return true;
            }
            return false;
        }

        public void LogOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}