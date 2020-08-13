using FlaUI.Core.AutomationElements;

namespace LoanIQ.Desktop.Automation.Core.Elements.Tabs
{
    public class Element: ElementBase
    {
        public AutomationElement GenaralButton(string buttonName)
        {
            return this.Context.FindFirstByXPath($"//Button[@Name='{buttonName}']");
        }
    }
}
