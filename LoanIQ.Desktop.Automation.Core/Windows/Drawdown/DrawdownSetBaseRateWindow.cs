using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using System;
using FlaUI.Core.Definitions;
using DTAF.Core.Desktop.Contracts;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class DrawdownSetBaseRateWindow : WindowBase, IWindowElement
    {
        public AutomationElement BorrowerBaseRateTextBox
        {
            get
            {
                return this.Context.FindFirstDescendant(c => c.ByControlType(ControlType.Edit));
            }
        }

        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindFirstDescendant(c => c.ByControlType(ControlType.Button).And(c.ByName("OK")));
            }
        }

        public AutomationElement CancelButton
        {
            get
            {
                return this.Context.FindFirstDescendant(c => c.ByControlType(ControlType.Button).And(c.ByName("Cancel")));
            }
        }

        public DrawdownSetBaseRateWindow(ApplicationHelper applicationHelper) : base(applicationHelper)
        {
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = ApplicationHelper.GetWindowByName("Set Base Rate") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
