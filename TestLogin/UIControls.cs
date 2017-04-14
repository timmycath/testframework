using System;


namespace PageObjects
{
    public class UIControls
    {
        public UIControls()
        {
        }
        public class LoginControls
        {
            UITestControl uiEmpId;

            LoginControls()
            {
                uiEmpId = newUITestControl(br);
                uiEmpId.TechnologyName = "Web";
                uiEmpId.SearchProperties.Add("ControlType", "Edit");
                uiEmpId.SearchProperties.Add("Id", "EmpId");
                Keyboard.SendKeys(uiEmpId, StuffNo);
            }
        }

    }
}
