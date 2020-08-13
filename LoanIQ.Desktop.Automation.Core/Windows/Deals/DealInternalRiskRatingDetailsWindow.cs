using System;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class DealInternalRiskRatingDetailsWindow : WindowBase, IWindowElement
    {
        public AutomationElement RatingComboBox
        {
            get
            {
                return this.Context.FindChildAt(2);
            }
        }

        public AutomationElement ValueComboBox
        {
            get
            {
                return this.Context.FindChildAt(3);
            }
        }

        public AutomationElement EffectiveDatePicker
        {
            get
            {
                return this.Context.FindChildAt(4);
            }
        }

        public AutomationElement ExpirationDatePicker
        {
            get
            {
                return this.Context.FindChildAt(5);
            }
        }

        public AutomationElement PercentageTextBox
        {
            get
            {
                return this.Context.FindChildAt(6);
            }
        }

        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d=> d.ByName("OK"));
            }
        }

        public DealInternalRiskRatingDetailsWindow(ApplicationHelper applicationHelper)
            :base(applicationHelper)
        {

        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = ApplicationHelper.GetDialogByName("Deal Internal Risk Rating Details") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
