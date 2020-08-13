using DTAF.Core.Desktop.Contracts;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;

namespace LoanIQ.Desktop.Automation.Core.Elements.Tabs.ActiveCustomer
{
    public class ProfileTabItem : ElementBase, IElement
    {
        public AutomationElement AddProfileButton
        {
            get
            {
                return Context.FindFirstDescendant(c => c.ByName("Add Profile").And(c.ByControlType(ControlType.Button)));
            }
        }

        public AutomationElement ContactsButton
        {
            get
            {
                return Context.FindFirstDescendant(c => c.ByName("Contacts").And(c.ByControlType(ControlType.Button)));
            }
        }
    }
}
