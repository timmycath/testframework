using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UIControls_Library
{
    
    public class LoginControls
    {
        public Dictionary<string, string> Username = null;
        public Dictionary<string, string> Password = null;
        public Dictionary<string, string> Login_Button = null;
        public Dictionary<string, string> Hide_Checkbox = null;
        public LoginControls()
        {
            Username = new Dictionary<string, string>();
            Password = new Dictionary<string, string>();
            Login_Button = new Dictionary<string, string>();
            Hide_Checkbox = new Dictionary<string, string>();

            Username.Add("Id", "USER");
            Username.Add("TechnologyName", "Web");
            Username.Add("ControlType", "Edit");

            Password.Add("Id", "PASSWORD");
            Password.Add("TechnologyName", "Web");
            Password.Add("ControlType", "Edit");

            Login_Button.Add("Id", "login_button");
            Login_Button.Add("TechnologyName", "Web");
            Login_Button.Add("ControlType", "Button");

            Hide_Checkbox.Add("Id", "ALIAS_CHECK");
            Hide_Checkbox.Add("TechnologyName", "Web");
            Hide_Checkbox.Add("ControlType", "Checkbox");
        }
        ~LoginControls()
        {

        }
    }
    public class TransferControls
    {
        //Declate the controls for Transfer Page
        //Initialize the controls in Constructor
        //Release memory allocated in Destructor
    }

}
