using DTAF.Core.Desktop.Contracts;
using FlaUI.Core.AutomationElements;

namespace LoanIQ.Desktop.Automation.Core.Elements.Tabs.Primary
{
    public class PendingPrimaryContactsTabItem : TabItemBase, IElement
    {
        public AutomationElement AddContactsButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("Add Contacts"));
            }
        }

        public AutomationElement ServicingGroupsButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("Servicing Groups"));
            }
        }

        public PendingPrimaryContactsTabItem()
            : base("Contacts")
        {

        }
    }
}
