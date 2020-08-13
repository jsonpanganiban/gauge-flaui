using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using DTAF.Core.Helpers;
using FlaUI.Core.Tools;
using LoanIQ.Desktop.Automation.Core.Helpers;
using System;

namespace DTAF.Core.Desktop.Actions
{
    public static class Close
    {
        

        public static void This<T>(T window)
            where T : IWindowElement
        {
            window.Close();
            
            Retry.WhileTrue(() => window != null && window.Context.IsOffscreen == false, TimeSpan.FromSeconds(250),
                TimeSpan.FromMilliseconds(250), false);
        }

        public static void AllAndReset()
        {
            try
            {
                var appHelper = InjectionHelper.GetInstance<ApplicationHelper>();
                var windows = appHelper.GetAllWindows();

                foreach (var window in windows)
                {
                    if (!window.Name.Contains("Fusion Loan IQ - "))
                        window.Close();
                }

            }
            catch (Exception ex)
            {
                var logger = InjectionHelper.GetInstance<DesktopLogger>();
                logger.WriteError("Failed to close all: " + ex.Message);
                throw;
            }
            
        }

        public static void App()
        {

        }
    }
}
