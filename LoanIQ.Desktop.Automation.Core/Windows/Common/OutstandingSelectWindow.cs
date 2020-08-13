using System;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using FlaUI.Core.Definitions;
using DTAF.Core.Desktop.Contracts;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class OutstandingSelectWindow : WindowBase, IWindowElement
    {

        public AutomationElement NewRadioButton
        {
            get
            {
                return this.Context.FindFirstDescendant(x => x.ByName("New")
                    .And(x.ByControlType(ControlType.RadioButton)));
            }
        }

        public AutomationElement ExistingRadioButton
        {
            get
            {
                return this.Context.FindFirstDescendant(x => x.ByName("Existing")
                        .And(x.ByControlType(ControlType.RadioButton)));
            }
        }

        public AutomationElement PendingRadioButton
        {
            get
            {
                return this.Context.FindFirstDescendant(x => x.ByName("Pending")
                .And(x.ByControlType(ControlType.RadioButton)));
            }
        }

        public AutomationElement CancelledRadioButton
        {
            get
            {
                return this.Context.FindFirstDescendant(x => x.ByName("Cancelled")
                .And(x.ByControlType(ControlType.RadioButton)));
            }
        }

        public AutomationElement BorrowerComboBox
        {
            get
            {
                return this.Context.FindAllChildren(x => x.ByControlType(ControlType.ComboBox))[1];
            }
        }

        public AutomationElement PricingOptionComboBox
        {
            get
            {
                return this.Context.FindAllChildren(x => x.ByControlType(ControlType.ComboBox))[2];
            }
        }

        public AutomationElement CurrencyComboBox
        {
            get
            {
                return this.Context.FindAllChildren(x => x.ByControlType(ControlType.ComboBox))[3];
            }
        }

        public AutomationElement DealTextBox
        {
            get
            {
                return this.Context.FindAllChildren(x => x.ByControlType(ControlType.Edit))[0];
            }
        }

        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindFirstChild(x => x.ByName("OK").And(x.ByControlType(ControlType.Button)));
            }
        }

        public AutomationElement CancelButton
        {
            get
            {
                return this.Context.FindFirstChild(x => x.ByName("Cancel").And(x.ByControlType(ControlType.Button)));
            }
        }

        public OutstandingSelectWindow(ApplicationHelper applicationHelper) : base(applicationHelper)
        {
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = ApplicationHelper.GetWindowByName("Outstanding Select") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
