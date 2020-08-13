using System;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class CustomerInternalRiskRating : WindowBase, IWindowElement
    {
        const int _ratingIndex = 13;
        const int _percentIndex = 3;
        const int _effectiveDateIndex = 4;
        const int _expiryDateIndex = 5;

        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByName("OK"));
            }
        }

        public AutomationElement CancelButton
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByName("Cancel"));
            }
        }
        public AutomationElement RatingTypeComboBox
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByClassName("ComboBox").And(_.ByLocalizedControlType("combo box")));
            }
        }

        public AutomationElement RatingTextBox
        {
            get
            {
                return this.Context.FindChildAt(_ratingIndex);
            }
        }

        public AutomationElement PercentTextbox
        {
            get
            {
                return this.Context.FindChildAt(_percentIndex);
            }
        }

        public AutomationElement EffectiveDateTextBox
        {
            get
            {
                return this.Context.FindChildAt(_effectiveDateIndex);
            }
        }

        public AutomationElement ExpiryDateTextBox
        {
            get
            {
                return this.Context.FindChildAt(_expiryDateIndex);
            }
        }

        public CustomerInternalRiskRating(ApplicationHelper applicationHelper) : base(applicationHelper)
        {

        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = this.ApplicationHelper.GetWindowWithNameContaining("Internal Risk Rating") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
