using DTAF.Core.Desktop.Contracts;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;

namespace LoanIQ.Desktop.Automation.Core.Elements.Tabs.DealNotebook
{
    public class DealRiskOrRegulatoryTabItem : TabItemBase, IElement
    {
        public DealRiskOrRegulatoryTabItem()
            : base("Risk/Regulatory")
        {

        }

        public AutomationElement AddButton
        {
            get
            {
                return this.Context.FindFirstDescendant(c => c.ByName("Add").And(c.ByControlType(ControlType.Button)));
            }
        }
    }
}
