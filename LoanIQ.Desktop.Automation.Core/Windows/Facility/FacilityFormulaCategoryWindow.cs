using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using System;

namespace LoanIQ.Desktop.Automation.Core.Windows.Facility
{
    public class FacilityFormulaCategoryWindow : WindowBase, IWindowElement
    {
        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("OK"));
            }
        }

        public AutomationElement Code
        {
            get
            {
                return this.Context.FindChildAt(0).FindChildAt(0).FindChildAt(1);
            }
        }

        public AutomationElement SpreadValue
        {
            get
            {
                return this.Context.FindChildAt(6).FindChildAt(0).FindChildAt(0).FindChildAt(0).FindChildAt(0);
            }
        }

        public FacilityFormulaCategoryWindow(ApplicationHelper applicationHelper)
            : base(applicationHelper)
        {

        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = this.ApplicationHelper.GetDialogByName("Formula Category") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
