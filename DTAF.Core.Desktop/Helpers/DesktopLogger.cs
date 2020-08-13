using DTAF.Core;
using FlaUI.Core.AutomationElements;

namespace LoanIQ.Desktop.Automation.Core.Helpers
{
    public class DesktopLogger : Logger
    {
        public void Write(AutomationElement element, string message)
        {
            string name = "Name";
            this.Write(new[] { element.Properties.AriaRole.TryGetValue(out name) ? element.Name : string.Empty, element.ControlType.ToString() }, message);
        }

        public void WriteError(string message)
        {
            this.Write(message);
        }
    }
}
