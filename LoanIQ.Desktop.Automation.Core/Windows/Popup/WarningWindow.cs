using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using System;
using FlaUI.Core.Definitions;
using DTAF.Core.Desktop.Contracts;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class WarningWindow : WindowBase, IWindowElement
    {

        public AutomationElement YesButton
        {
            get
            {
                return this.Context.FindFirstChild(x => x.ByName("Yes").And(x.ByControlType(ControlType.Button)));
            }
        }

        public AutomationElement NoButton
        {
            get
            {
                return this.Context.FindFirstChild(x => x.ByName("No").And(x.ByControlType(ControlType.Button)));
            }
        }

        public WarningWindow(ApplicationHelper applicationHelper) : base(applicationHelper)
        {
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = ApplicationHelper.GetDialogByName("Warning") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
