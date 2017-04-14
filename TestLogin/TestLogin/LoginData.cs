using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLogin
{
    public class LoginData
    {
        /*public
        string URL;
        public
        string username;
        public
        string password;*/
        public List<string> LdataFromExcel = null;

        public LoginData()
        {

            LdataFromExcel = new List<string>();
        }

        public LoginData(string URL, string Username, string Password)
        {
            LdataFromExcel = new List<string>();
            LdataFromExcel.Add(URL);
            LdataFromExcel.Add(Username);
            LdataFromExcel.Add(Password);
        }
        ~LoginData()
        {
        }
    }
}
