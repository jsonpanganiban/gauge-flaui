using System;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Tools;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class DealSelectWindow : WindowBase, IWindowElement
    {
        public AutomationElement NewRadioButton
        {
            get
            {
                return this.Context.FindChildAt(5).FindChildAt(0);
            }
        }

        public AutomationElement ExistingRadioButton
        {
            get
            {
                return this.Context.FindFirstDescendant(x => x.ByName("Existing").And(x.ByControlType(ControlType.RadioButton)));
            }
        }

        public AutomationElement NameTextBox
        {
            get
            {
                return this.Context.FindChildAt(0);
            }
        }

        public AutomationElement AliasTextBox
        {
            get
            {
                return this.Context.FindChildAt(1);
            }
        }

        public AutomationElement CurrencyComboBox
        {
            get
            {
                return this.Context.FindChildAt(13);
            }
        }

        public AutomationElement DepartmentComboBox
        {
            get
            {
                return this.Context.FindChildAt(14);
            }
        }

        public AutomationElement SaleGroupsButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("Sales Groups..."));
            }
        }

        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindFirstDescendant(c => c.ByName("OK").And(c.ByControlType(ControlType.Button)));
            }
        }

        public DealSelectWindow(ApplicationHelper applicationHelper) 
            : base(applicationHelper)
        {

        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = ApplicationHelper.GetDialogByName("Deal Select") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
