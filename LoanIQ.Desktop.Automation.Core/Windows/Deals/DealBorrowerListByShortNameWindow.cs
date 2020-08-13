using System;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;

namespace LoanIQ.Desktop.Automation.Core.Windows.Deals
{
    public class DealBorrowerListByShortNameWindow : WindowBase
    {
        public AutomationElement BorrowerList
        {
            get
            {
                return this.Context.FindChildAt(2).FindChildAt(1).FindChildAt(0);
            }
        }

        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindChildAt(3).FindChildAt(1);
            }
        }

        public DealBorrowerListByShortNameWindow(ApplicationHelper applicationHelper)
            : base(applicationHelper)
        {

        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = this.ApplicationHelper.GetDialogByName("Borrower Select").FindChildAt(0) ?? throw new Exception();
                this.Context.SetForeground();
            }, this.ApplicationHelper.Config.WaitTimeout);
        }
    }
}
