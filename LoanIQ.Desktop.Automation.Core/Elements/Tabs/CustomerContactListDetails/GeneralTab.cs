using FlaUI.Core.AutomationElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanIQ.Desktop.Automation.Core.Elements.Tabs.CustomerContactListDetails
{
    public class GeneralTab : Element
    {
        private const int _firstNameTextBoxIndex = 6;
        private const int _lastNameTextBoxIndex = 8;
        private const int _preferredLanguageComboBoxIndex = 10;
        private const int _primaryPhoneTextBox = 12;
        private const int _departmentTextBox = 17;

        private const string _addNotificationMethodButtonName = "Add";
        private const string _addPurposeButtonName = "Purposes:";

        public AutomationElement SBCLCheckBox
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByName("SBLC")
                                   .And(_.ByControlType(FlaUI.Core.Definitions.ControlType.CheckBox)));
            }
        }

        public AutomationElement LoanCheckBox
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByName("Loan")
                                   .And(_.ByControlType(FlaUI.Core.Definitions.ControlType.CheckBox)));
            }
        }

        public AutomationElement PrincipalCheckBox
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByName("Principal")
                                   .And(_.ByControlType(FlaUI.Core.Definitions.ControlType.CheckBox)));
            }
        }

        public AutomationElement InterestCheckBox
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByName("Interest")
                                   .And(_.ByControlType(FlaUI.Core.Definitions.ControlType.CheckBox)));
            }
        }

        public AutomationElement FeesCheckBox
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByName("Fees")
                                   .And(_.ByControlType(FlaUI.Core.Definitions.ControlType.CheckBox)));
            }
        }
    }
}
