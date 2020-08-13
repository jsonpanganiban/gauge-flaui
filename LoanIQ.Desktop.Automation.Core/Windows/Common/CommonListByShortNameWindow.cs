using System;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class CommonListByShortNameWindow : WindowBase, IWindowElement
    {
        public AutomationElement ShortNameList
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

        public CommonListByShortNameWindow(ApplicationHelper applicationHelper)
            : base(applicationHelper)
        {

        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = this.ApplicationHelper.GetWindowsByNames(new[] { "Borrower Select", "Lender Select" }).FindChildAt(0) ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
