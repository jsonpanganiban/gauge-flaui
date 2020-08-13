using DTAF.Core.Desktop.Contracts;
using FlaUI.Core.AutomationElements;

namespace LoanIQ.Desktop.Automation.Core.Elements.Tabs.ContactDetails
{
    public class ContactDetailGeneralTabItem : Element, IElement
    {
        private const int _firstNameTextBoxIndex = 6;
        private const int _lastNameTextBoxIndex = 8;
        private const int _preferredLanguageComboBoxIndex = 10;
        private const int _primaryPhoneTextBox = 12;
        private const int _departmentTextBox = 17;

        private const string _addNotificationMethodButtonName = "Add";
        private const string _addPurposeButtonName = "Purposes:";

        public AutomationElement DepartmentTextBox
        {
            get
            {
                return this.Context.FindChildAt(_departmentTextBox);
            }
        }

        public AutomationElement FirstNameTextBox
        {
            get
            {
                return this.Context.FindChildAt(_firstNameTextBoxIndex);
            }
        }

        public AutomationElement LastNameTextBox
        {
            get
            {
                return this.Context.FindChildAt(_lastNameTextBoxIndex);
            }
        }

        public AutomationElement PreferredLanguageComboBox
        {
            get
            {
                return this.Context.FindChildAt(_preferredLanguageComboBoxIndex);
            }
        }

        public AutomationElement PrimaryPhoneTextBox
        {
            get
            {
                return this.Context.FindChildAt(_primaryPhoneTextBox);
            }
        }

        public AutomationElement AddPurposesButton
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByName(_addPurposeButtonName)
                                                        .And(_.ByControlType(FlaUI.Core.Definitions.ControlType.Button)));
            }
        }

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
