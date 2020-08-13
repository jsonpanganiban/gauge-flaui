using DTAF.Core.Helpers;
using FlaUI.Core.AutomationElements;
using LoanIQ.Desktop.Automation.Core.Helpers;
using System;

namespace DTAF.Core.Desktop.Actions
{
    public static class RightClick
    {
        public static void On(AutomationElement element, int timeout = 30)
        {
            try
            {
                Wait.UntilVisible(element, timeout);
                element.Focus();
                element.RightClick();

                var logger = InjectionHelper.GetInstance<DesktopLogger>();
                logger.Write(element, "has been right clicked");
            }

            catch (Exception ex)
            {
                var logger = InjectionHelper.GetInstance<DesktopLogger>();
                logger.WriteError(ex.Message);
                throw ex;
            }
           
        }
    }
}