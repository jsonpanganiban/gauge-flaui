using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using System;

namespace LoanIQ.Desktop.Automation.Core.Windows.Facility
{
    public class FacilityInterestPricingAddItemWindow : WindowBase, IWindowElement
    {
        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("OK"));
            }
        }

        public AutomationElement Options
        {
            get
            {
                return this.Context.FindChildAt(0);
            }
        }

        public AutomationElement Type
        {
            get
            {
                return this.Context.FindChildAt(1);
            }
        }

        public FacilityInterestPricingAddItemWindow(ApplicationHelper applicationHelper)
            : base(applicationHelper)
        {

        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = this.ApplicationHelper.GetDialogByName("Add Item") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
