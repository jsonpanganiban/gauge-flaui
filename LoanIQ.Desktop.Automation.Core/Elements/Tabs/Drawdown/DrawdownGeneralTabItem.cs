using DTAF.Core.Desktop.Contracts;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;

namespace LoanIQ.Desktop.Automation.Core.Elements.Tabs.DealNotebook
{
    public class DrawdownGeneralTabItem : TabItemBase, IElement
    {

        public AutomationElement EffectiveDateTextBox
        {
            get
            {
                return this.Context.FindAllDescendants(d => d.ByControlType(ControlType.Edit))[0];
            }
        }

        public AutomationElement MaturityDateTextBox
        {
            get
            {
                return this.Context.FindAllDescendants(d => d.ByControlType(ControlType.Edit))[1];
            }
        }

        public AutomationElement AmountsRequestedTextBox
        {
            get
            {
                return this.Context.FindFirstDescendant(c => c.ByName("Amounts")).FindChildAt(1);
            }
        }

        public AutomationElement RepricingFrequencyComboBox
        {
            get
            {
                return this.Context.FindAllDescendants(d => d.ByControlType(ControlType.ComboBox))[0];
            }
        }

        public AutomationElement RepricingDateTextBox
        {
            get
            {
                return this.Context.FindAllDescendants(d => d.ByControlType(ControlType.Edit))[2];
            }
        }

        public AutomationElement IntCycleFrequencyComboBox
        {
            get
            {
                return this.Context.FindFirstByXPath("//Button[@Name='Risk Type:']/following-sibling::Pane[2]/ComboBox");
            }
        }

        public AutomationElement ActualDueDateTextBox
        {
            get
            {
                return this.Context.FindFirstByXPath("//Button[@Name='Risk Type:']/following-sibling::Pane[2]/Edit");
            }
        }

        public DrawdownGeneralTabItem() : base("General")
        {
        }
    }
}
