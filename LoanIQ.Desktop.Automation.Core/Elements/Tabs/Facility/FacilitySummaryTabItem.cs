using DTAF.Core.Desktop.Contracts;
using FlaUI.Core.AutomationElements;

namespace LoanIQ.Desktop.Automation.Core.Elements.Tabs.Facility
{
    public class FacilitySummaryTabItem : TabItemBase, IElement
    {
        public AutomationElement ProposedCmt
        {
            get
            {
                return this.Context.FindChildAt(0).FindChildAt(4).FindChildAt(1);
            }
        }

        public AutomationElement ClosingCmt
        {
            get
            {
                return this.Context.FindChildAt(0).FindChildAt(4).FindChildAt(3);
            }
        }

        public AutomationElement Agreement
        {
            get
            {
                return this.Context.FindChildAt(0).FindChildAt(3).FindChildAt(5);
            }
        }

        public AutomationElement Effective
        {
            get
            {
                return this.Context.FindChildAt(0).FindChildAt(3).FindChildAt(7);
            }
        }

        public AutomationElement Expiry
        {
            get
            {
                return this.Context.FindChildAt(0).FindChildAt(3).FindChildAt(9);
            }
        }

        public AutomationElement FinalMaturity
        {
            get
            {
                return this.Context.FindChildAt(0).FindChildAt(3).FindChildAt(11);
            }
        }

        public FacilitySummaryTabItem()
            : base("Summary")
        {

        }
    }
}
