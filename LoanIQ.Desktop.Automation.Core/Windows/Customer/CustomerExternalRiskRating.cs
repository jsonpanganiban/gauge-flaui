using System;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class CustomerExternalRiskRating : WindowBase, IWindowElement
    {
        const int _ratingIndex = 1;

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

        public AutomationElement StartDateTextBox
        {
            get
            {
                return this.Context.FindFirstByXPath("//Pane//Edit");
            }
        }

        public CustomerExternalRiskRating(ApplicationHelper applicationHelper) : base(applicationHelper)
        {
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = this.ApplicationHelper.GetWindowWithNameContaining("Add External Risk Rating") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
