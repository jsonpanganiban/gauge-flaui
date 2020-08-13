using System;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class BorrowerListWindow : WindowBase, IWindowElement
    {
        public BorrowerListWindow(ApplicationHelper applicationHelper)
            : base(applicationHelper)
        {

        }

        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("OK"));
            }
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = this.ApplicationHelper.GetWindowWithNameContaining("Borrower List By") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
