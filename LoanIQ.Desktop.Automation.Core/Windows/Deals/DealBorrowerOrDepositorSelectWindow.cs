using System;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;

namespace LoanIQ.Desktop.Automation.Core.Windows.Deals
{
    public class DealBorrowerOrDepositorSelectWindow : WindowBase, IWindowElement
    {
        public AutomationElement AddAllButton
        {
            get
            {
                return this.Context.FindChildAt(4);
            }
        }

        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindFirstChild(c => c.ByName("OK"));
            }
        }

        public DealBorrowerOrDepositorSelectWindow(ApplicationHelper applicationHelper)
            : base(applicationHelper)
        {

        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = this.ApplicationHelper.GetDialogByName("Borrower/Depositor Select") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
