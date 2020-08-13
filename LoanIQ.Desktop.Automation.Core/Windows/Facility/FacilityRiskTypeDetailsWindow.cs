using System;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;

namespace LoanIQ.Desktop.Automation.Core.Windows.Facility
{
    public class FacilityRiskTypeDetailsWindow : WindowBase, IWindowElement
    {
        public AutomationElement RiskType
        {
            get
            {
                return this.Context.FindChildAt(0);
            }
        }

        public AutomationElement Limit
        {
            get
            {
                return this.Context.FindChildAt(1);
            }
        }

        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("OK"));
            }
        }

        public FacilityRiskTypeDetailsWindow(ApplicationHelper applicationHelper)
            : base(applicationHelper)
        {

        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = this.ApplicationHelper.GetWindowByName("Risk Type Details") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
