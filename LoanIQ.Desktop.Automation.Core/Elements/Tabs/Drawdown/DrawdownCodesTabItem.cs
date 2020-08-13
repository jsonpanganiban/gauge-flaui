using DTAF.Core.Desktop.Contracts;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;

namespace LoanIQ.Desktop.Automation.Core.Elements.Tabs.DealNotebook
{
    public class DrawdownCodesTabItem : TabItemBase, IElement
    {
        public AutomationElement TreasuryReportingAreaComboBox
        {
            get
            {
                return this.Context.FindAllDescendants(d => d.ByControlType(ControlType.ComboBox))[0];
            }
        }

        public DrawdownCodesTabItem()
            : base("Codes")
        {
        }
    }
}
