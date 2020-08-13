using DTAF.Core.Desktop.Contracts;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;

namespace LoanIQ.Desktop.Automation.Core.Elements.Tabs.DealNotebook
{
    public class DrawdownCalendarTabItem : TabItemBase, IElement
    {
        public AutomationElement AddButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("Add").And(d.ByControlType(ControlType.Button)));
            }
        }

        public DrawdownCalendarTabItem()
            : base("Calendars")
        {
        }
    }
}
