using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using System;
using FlaUI.Core.Definitions;
using DTAF.Core.Desktop.Contracts;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class DrawdownOverrideSpreadWindow : WindowBase, IWindowElement
    {
        public AutomationElement SpreadOverrideTextBox
        {

            get
            {
                return this.Context.FindFirstChild(c => c.ByControlType(ControlType.Edit));
            }
        }

        public AutomationElement OkButton
        {

            get
            {
                return this.Context.FindFirstChild(c => c.ByName("OK").And(c.ByControlType(ControlType.Button)));
            }
        }

        public DrawdownOverrideSpreadWindow(ApplicationHelper applicationHelper) : base(applicationHelper)
        {
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = ApplicationHelper.GetWindowByName("Override Spread") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
