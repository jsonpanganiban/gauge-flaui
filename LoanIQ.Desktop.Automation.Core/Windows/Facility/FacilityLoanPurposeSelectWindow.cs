using System;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using FlaUI.UIA3;

namespace LoanIQ.Desktop.Automation.Core.Windows.Facility
{
    public class FacilityLoanPurposeSelectWindow : WindowBase, IWindowElement
    {
        public AutomationElement AvailableList
        {
            get
            {
                return this.Context.FindChildAt(3).FindChildAt(1).FindChildAt(0);
            }
        }

        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("OK"));
            }
        }

        public FacilityLoanPurposeSelectWindow(ApplicationHelper applicationHelper)
            : base(applicationHelper)
        {

        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = this.ApplicationHelper.GetWindowByName("Loan Purpose Types Selection List") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
