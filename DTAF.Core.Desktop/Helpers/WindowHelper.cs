using DTAF.Core.Desktop.Actions;
using DTAF.Core.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using LoanIQ.Desktop.Automation.Core.Helpers;

namespace DTAF.Core.Desktop.Helpers
{
    public static class WindowHelper
    {
        public static void MaximizeWindow(this Window window)
        {
            if (window.Patterns.Window.Pattern.CanMaximize.Value && window.Patterns.Window.Pattern.WindowVisualState.Value != WindowVisualState.Maximized)
            {
                DoubleClick.On(window.TitleBar);

                var logger = InjectionHelper.GetInstance<DesktopLogger>();
                logger.Write(window, "has been maximized");
            }
        }

        public static void Dispose(this Window window)
        {
            // TEMP: Make some checking here
            Click.On(window.TitleBar.CloseButton);
        }
    }
}
