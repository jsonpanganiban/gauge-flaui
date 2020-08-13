using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using System;

namespace LoanIQ.Desktop.Automation.Core.Windows.Deals
{
    public class DealSelectExpenseCodeWindow : WindowBase, IWindowElement
    {
        public AutomationElement AllExpenseCodesButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("All Expense Codes"));
            }
        }

        public DealSelectExpenseCodeWindow(ApplicationHelper applicationHelper)
            : base(applicationHelper)
        {

        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = this.ApplicationHelper.GetWindowByName("Select Expense Codes") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
