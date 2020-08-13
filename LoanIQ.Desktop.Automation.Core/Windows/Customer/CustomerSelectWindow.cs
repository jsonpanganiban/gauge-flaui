using System;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class CustomerSelectWindow : WindowBase, IWindowElement
    {
        private const int _customerShortNameTextBoxIndex = 8;
        private const int _customerLegalNameDocumentBoxIndex = 1;

        public AutomationElement NewCustomerComboBox
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByClassName("Button")
                                                              .And(_.ByName("New")
                                                              .And(_.ByLocalizedControlType("radio button"))));
            }
        }

        public AutomationElement CustomerShortNameTextBox
        {
            get
            {
                return this.Context.FindChildAt(_customerShortNameTextBoxIndex);
            }
        }

        public AutomationElement LegalNameDocumentBox
        {
            get
            {
                return this.Context.FindChildAt(_customerLegalNameDocumentBoxIndex);
            }
        }

        public AutomationElement OKButton
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByName("OK").And(_.ByClassName("Button")));
            }
        }

        public CustomerSelectWindow(ApplicationHelper applicationHelper) : base(applicationHelper)
        { }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = ApplicationHelper.GetWindowByName("Customer Select") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
