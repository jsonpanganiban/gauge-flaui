using DTAF.Core.Desktop.Contracts;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;

namespace LoanIQ.Desktop.Automation.Core.Elements.Tabs.DealNotebook
{
    public class DealPersonnelTabItem : TabItemBase, IElement
    {
        public DealPersonnelTabItem()
            :base("Personnel")
        {

        }

        public AutomationElement ExpenseCodeButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("Expense Code").And(d.ByControlType(ControlType.Button)));
            }
        }

        public AutomationElement SaleGroupsButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("Sales Groups").And(d.ByControlType(ControlType.Button)));
            }
        }
    }
}
