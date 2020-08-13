using DTAF.Core.Desktop.Contracts;
using FlaUI.Core.AutomationElements;

namespace LoanIQ.Desktop.Automation.Core.Elements.Tabs
{

    public class CorporateTab : ElementBase, IElement
    {

        private const int _immediateParentIndex = 1;
        private const int _ultimateParentIndex = 0;

        public const string IMMEDIATEPARENTBUTTON_NAME = "Immediate Parent";

        public AutomationElement ImmediateParentTextBox
        {
            get
            {
                return Context.FindChildAt(_immediateParentIndex);
            }
        }

        public AutomationElement UltimateParentTextBox
        {
            get
            {
                return Context.FindChildAt(_ultimateParentIndex);
            }
        }

        public bool UltimateParentHasValue
        {
            get
            {
                return !string.IsNullOrEmpty(this.UltimateParentTextBox.AsTextBox().Text);
            }
        }

        public bool ImmediateParentHasValue
        {
            get
            {
                return !string.IsNullOrEmpty(this.ImmediateParentTextBox.AsTextBox().Text);
            }
        }

        public CorporateTab()
        {

        }
    }
}
