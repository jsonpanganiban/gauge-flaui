using DTAF.Core.Desktop.Contracts;
using FlaUI.Core.AutomationElements;

namespace LoanIQ.Desktop.Automation.Core.Elements.Tabs.DealNotebook
{
    public class DealRestrictionsTabItem : TabItemBase, IElement
    {
        public DealRestrictionsTabItem()
            : base("Restrictions")
        {

        }

        public AutomationElement MaxNumberOfLoans
        {
            get
            {
                return this.Context.FindChildAt(0).FindChildAt(0).FindChildAt(0);
            }
        }
    }
}
