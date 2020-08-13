using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.Tools;
using System;

namespace LoanIQ.Desktop.Automation.Core.Windows.Customer
{
    public class CustomerContactAddressListForWindow : WindowBase, IWindowElement
    {
        public CustomerContactAddressListForWindow(ApplicationHelper applicationHelper) : base(applicationHelper)
        {
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                var customerSelect = ApplicationHelper.GetWindowWithNameContaining("Address List for");
                Context = customerSelect ?? throw new Exception();
            }, ApplicationHelper.Config.WaitTimeout);
        }
    }
}
