using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using System;

namespace LoanIQ.Desktop.Automation.Core.Windows.Facility
{
    public class FacilityAmountsWindow : WindowBase, IWindowElement
    {
        public AutomationElement Type
        {
            get
            {
                return this.Context.FindChildAt(7);
            }
        }

        public AutomationElement From
        {
            get
            {
                return this.Context.FindChildAt(0);
            }
        }

        public AutomationElement To
        {
            get
            {
                return this.Context.FindChildAt(2);
            }
        }

        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("OK"));
            }
        }

        public FacilityAmountsWindow(ApplicationHelper applicationHelper)
            : base(applicationHelper)
        {

        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = this.ApplicationHelper.GetDialogByName("Amounts") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
