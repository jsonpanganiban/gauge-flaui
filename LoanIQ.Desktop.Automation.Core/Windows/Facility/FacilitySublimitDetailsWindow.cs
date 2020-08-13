using System;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using FlaUI.UIA3;

namespace LoanIQ.Desktop.Automation.Core.Windows.Facility
{
    public class FacilitySublimitDetailsWindow : WindowBase, IWindowElement
    {
        protected AutomationElement RiskGroup
        {
            get
            {
                return this.Context.FindChildAt(1);
            }
        }

        public AutomationElement ModifyRisk
        {
            get
            {
                return this.RiskGroup.FindChildAt(0);
            }
        }

        public AutomationElement Name
        {
            get
            {
                return this.Context.FindChildAt(6);
            }
        }

        public AutomationElement GlobalAmount
        {
            get
            {
                return this.Context.FindChildAt(8);
            }
        }

        public AutomationElement Currency
        {
            get
            {
                return this.Context.FindChildAt(15);
            }
        }

        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("OK"));
            }
        }

        public FacilitySublimitDetailsWindow(ApplicationHelper applicationHelper)
            : base(applicationHelper)
        {

        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = this.ApplicationHelper.GetWindowWithNameContaining("Sublimit Details") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
