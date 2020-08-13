using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using System;

namespace LoanIQ.Desktop.Automation.Core.Windows.Facility
{
    public class FacilityPenaltySpreadEditorWindow : WindowBase, IWindowElement
    {
        public AutomationElement PenaltySpread
        {
            get
            {
                return this.Context.FindChildAt(1);
            }
        }

        public AutomationElement PenaltyStatus
        {
            get
            {
                return this.Context.FindChildAt(0);
            }
        }

        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("OK"));
            }
        }

        public FacilityPenaltySpreadEditorWindow(ApplicationHelper applicationHelper)
            : base(applicationHelper)
        {

        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = this.ApplicationHelper.GetDialogByName("Penalty Spread Editor") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
