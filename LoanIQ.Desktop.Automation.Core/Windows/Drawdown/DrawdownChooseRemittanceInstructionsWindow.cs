using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using System;
using FlaUI.Core.Definitions;
using DTAF.Core.Desktop.Contracts;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class DrawdownChooseRemittanceInstructionsWindow : WindowBase, IWindowElement
    {

        public AutomationElement RowItem(int rowNumber)
        {
            return this.Context.FindFirstDescendant(d => d.ByControlType(ControlType.Tree)).FindChildAt(rowNumber - 1);
        }

        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByControlType(ControlType.Button).And(d.ByName("OK")));
            }
        }

        public AutomationElement CancelButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByControlType(ControlType.Button).And(d.ByName("Cancel")));
            }
        }

        public DrawdownChooseRemittanceInstructionsWindow(ApplicationHelper applicationHelper) : base(applicationHelper)
        {
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                var window = ApplicationHelper.GetWindowWithNameContaining("Choose Remittance Instructions");
                this.Context = window ?? throw new Exception();
                this.Context.SetForeground();
            }, this.ApplicationHelper.Config.WaitTimeout);
        }
    }
}
