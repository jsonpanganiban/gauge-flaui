using DTAF.Core.Desktop.Contracts;
using FlaUI.Core.AutomationElements;

namespace LoanIQ.Desktop.Automation.Core.Elements.Tabs.Facility
{
    public class FacilityPricingTabItem : TabItemBase, IElement
    {
        public AutomationElement ModifyInterestPricingButton
        {
            get
            {
                return this.Context.Parent.FindFirstDescendant(d => d.ByName("Modify Interest Pricing..."));
            }
        }

        public AutomationElement ModifyButton
        {
            get
            {
                return this.Context.Parent.FindFirstDescendant(d => d.ByName("Modify"));
            }
        }

        public AutomationElement PastDueGraceDays
        {
            get
            {
                return this.Context.Parent.FindFirstDescendant(d => d.ByName("Penalty Spread")).FindChildAt(5);
            }
        }

        public FacilityPricingTabItem()
            : base("Pricing")
        {

        }
    }
}
