using System;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;

namespace LoanIQ.Desktop.Automation.Core.Windows.Deals
{
    public class DealInterestPricingOptionDetailsWindow : WindowBase, IWindowElement
    {
        public DealInterestPricingOptionDetailsWindow(ApplicationHelper applicationHelper)
            : base(applicationHelper)
        {

        }

        public AutomationElement AutomaticNotices
        {
            get
            {
                return this.Context.FindChildAt(6);
            }
        }

        public AutomationElement CCY
        {
            get
            {
                return this.Context.FindChildAt(7);
            }
        }

        public AutomationElement InitialInfractionRate
        {
            get
            {
                return this.Context.FindChildAt(8);
            }
        }

        public AutomationElement RoundedDecimalPrecision
        {
            get
            {
                return this.Context.FindChildAt(9);
            }
        }

        public AutomationElement NonBusinessDayRule
        {
            get
            {
                return this.Context.FindChildAt(10);
            }
        }

        public AutomationElement UtilizationImpact
        {
            get
            {
                return this.Context.FindChildAt(11);
            }
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
                this.Context = this.ApplicationHelper.GetWindowWithNameContaining("Interest Pricing Option Details") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
