using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using ExcelOperations_Library;
using UIControls_Library;


namespace TestLogin
{
    /// <summary>
    /// Login Test case for MyBank
    /// 
    /// </summary>
    [CodedUITest]
    public class Login
    {
        public Login()
        {
        }
        ~ Login()
        {

        }

        [TestMethod]
        public void login()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            string fileName = @"..\..\..\testdata.xlsx";
            int Sheetindex = 1; //This has to be hard coded for test case
            int rowno = 2;  // First row is column labels and data starts from 2nd row
            ExcelDataHandler xlhandle = new ExcelDataHandler();
            xlhandle.Initialize(fileName);
            LoginData record = new LoginData();
            if (xlhandle.Open())
                xlhandle.ReadOneRow(Sheetindex, rowno, record.LdataFromExcel);
            else
            {
                Console.WriteLine("Unable to open the file");

            }
            for (int i = 0; i < record.LdataFromExcel.Count; i++)
                Console.WriteLine("URL:" + record.LdataFromExcel[i].ToString());

            BrowserWindow browser = BrowserWindow.Launch(record.LdataFromExcel[0].ToString());   //first column from excel
            UITestControl uiEmpId = new UITestControl(browser);
            UITestControl uiPassword = new UITestControl(browser);
            UITestControl uiLogin_btn = new UITestControl(browser);

            LoginControls login = new LoginControls();
            uiEmpId.SearchProperties.Add("Id", login.Username["Id"]);
            uiEmpId.SearchProperties.Add("ControlType", login.Username["ControlType"]);
            uiEmpId.TechnologyName = login.Username["TechnologyName"];

            Keyboard.SendKeys(uiEmpId, record.LdataFromExcel[1].ToString());       //second column from excel

            uiPassword.SearchProperties.Add("Id", login.Password["Id"]);
            uiPassword.SearchProperties.Add("ControlType", login.Password["ControlType"]);
            uiPassword.TechnologyName = login.Password["TechnologyName"];
            // uiPassword.SearchProperties.Add("Type" , login.pw.type);

            Keyboard.SendKeys(uiPassword, record.LdataFromExcel[2].ToString());     //third column from excel

            uiLogin_btn.SearchProperties.Add("Id", login.Login_Button["Id"]);
            uiLogin_btn.SearchProperties.Add("ControlType", login.Login_Button["ControlType"]);
            uiLogin_btn.TechnologyName = login.Login_Button["TechnologyName"];

            Mouse.Click(uiLogin_btn);
            browser.WaitForControlReady(1000);
            Playback.Wait(1000);

        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
    }
}
