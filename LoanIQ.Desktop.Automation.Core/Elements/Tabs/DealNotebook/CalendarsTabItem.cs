using DTAF.Core.Desktop.Contracts;
using FlaUI.Core.AutomationElements;

namespace LoanIQ.Desktop.Automation.Core.Elements.Tabs.DealNotebook
{
    public class CalendarsTabItem : TabItemBase, IElement
    {
        public AutomationElement AddButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("Add"));
            }
        }

        public CalendarsTabItem()
            : base("Calendars")
        {

        }
    }
}
