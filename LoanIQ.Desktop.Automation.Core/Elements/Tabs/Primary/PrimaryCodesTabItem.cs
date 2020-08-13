using DTAF.Core.Desktop.Contracts;
using FlaUI.Core.AutomationElements;

namespace LoanIQ.Desktop.Automation.Core.Elements.Tabs.Primary
{
    public class PrimaryCodesTabItem : TabItemBase, IElement
    {
        public  AutomationElement AddButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("Add"));
            }
        }

        public AutomationElement DeleteButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("Delete"));
            }
        }

        public PrimaryCodesTabItem()
            : base("Codes")
        {

        }
    }
}
