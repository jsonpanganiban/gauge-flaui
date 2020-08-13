using DTAF.Core.Desktop.Contracts;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;

namespace LoanIQ.Desktop.Automation.Core.Elements.Tabs.DealNotebook
{
    public class DrawdownRatesTabItem : TabItemBase, IElement
    {

        public AutomationElement BaseRateButton
        {
            get
            {
                return this.Context.FindFirstDescendant(c => c.ByName("Base Rate:").And(c.ByControlType(ControlType.Button)));
            }
        }

        public AutomationElement SpreadButton
        {
            get
            {
                return this.Context.FindFirstDescendant(c => c.ByName("Spread:").And(c.ByControlType(ControlType.Button)));
            }
        }

        public AutomationElement AdditionalSpreadsButton
        {
            get
            {
                return this.Context.FindFirstDescendant(c => c.ByName("Additional Spreads:").And(c.ByControlType(ControlType.Button)));
            }
        }

        public AutomationElement PenaltySpreadRateButton
        {
            get
            {
                return this.Context.FindFirstDescendant(c => c.ByName("Rate:").And(c.ByControlType(ControlType.Button)));
            }
        }

        public DrawdownRatesTabItem() : base("Rates")
        {
        }
    }
}
