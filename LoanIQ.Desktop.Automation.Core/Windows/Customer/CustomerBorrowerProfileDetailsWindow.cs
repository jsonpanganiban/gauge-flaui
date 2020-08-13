using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.Tools;
using System;

namespace LoanIQ.Desktop.Automation.Core.Windows.Customer
{
    public class CustomerBorrowerProfileDetailsWindow : WindowBase, IWindowElement
    {
        public CustomerBorrowerProfileDetailsWindow(ApplicationHelper applicationHelper) : base(applicationHelper)
        {
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                Context = ApplicationHelper.GetWindowByName("Borrower Profile Details") ?? throw new Exception();
            }, ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
