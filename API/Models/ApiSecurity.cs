using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class ApiSecurity
    {
        public static bool VaidateUser(string username, string password)
        {
            // Check if it is valid credential  
            if (username=="a" && password=="a")//CheckUserInDB(username, password))  
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}