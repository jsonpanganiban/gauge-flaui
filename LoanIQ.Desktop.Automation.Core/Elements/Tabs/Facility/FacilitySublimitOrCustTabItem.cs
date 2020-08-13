using DTAF.Core.Desktop.Contracts;
using FlaUI.Core.AutomationElements;
using LoanIQ.Desktop.Automation.Core.Elements.Tabs;

namespace LoanIQ.Desktop.Automation.Core.Windows.Facility
{
    public class SublimitOrCustTabItem : TabItemBase, IElement
    {
        public AutomationElement AddSublimit
        {
            get
            {
                return this.Context.Parent.FindFirstDescendant(d => d.ByName("Add Sublimit..."));
            }
        }

        public AutomationElement AddBorrowerOrDepositor
        {
            get
            {
                return this.Context.Parent.FindFirstDescendant(d => d.ByName("Add Borrower / Depositor"));
            }
        }

        public SublimitOrCustTabItem()
            : base("Sublimit/Cust")
        {

        }
    }
}
