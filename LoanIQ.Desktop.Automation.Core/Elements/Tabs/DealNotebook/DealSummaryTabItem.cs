using DTAF.Core.Desktop.Contracts;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;

namespace LoanIQ.Desktop.Automation.Core.Elements.Tabs.DealNotebook
{
    public class DealSummaryTabItem : TabItemBase, IElement
    {
        public DealSummaryTabItem()
             : base("Summary")
        {

        }

        public AutomationElement AddButton
        {
            get
            {
                return this.Context.FindFirstDescendant(c => c.ByName("Add..."));
            }
        }

        public AutomationElement DealClassificationButton
        {
            get
            {
                return this.Context.FindFirstDescendant(c => c.ByName("Deal Classification"));
            }
        }


        public AutomationElement AdminAgentButton
        {
            get
            {
                return this.Context.FindFirstDescendant(c => c.ByName("Admin Agent"));
            }
        }

        public AutomationElement ProposedCmt
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("Global Deal Amounts")
                    .And(d.ByControlType(ControlType.Group)))
                    .FindFirstChild(c => c.ByControlType(ControlType.Edit));
            }
        }
    }
}
