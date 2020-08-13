using DTAF.Core.Desktop.Contracts;
using FlaUI.Core.AutomationElements;

namespace LoanIQ.Desktop.Automation.Core.Elements.Tabs.DealNotebook
{
    public class DealPricingRulesTabItem : TabItemBase, IElement
    {
        public AutomationElement AddOption
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("Add Option"));
            }
        }

        public DealPricingRulesTabItem()
            : base("Pricing Rules")
        {

        }
    }
}
