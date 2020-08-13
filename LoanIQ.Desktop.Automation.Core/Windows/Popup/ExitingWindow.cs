using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using System;
using FlaUI.Core.Definitions;
using DTAF.Core.Desktop.Contracts;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class ExitingWindow : WindowBase, IWindowElement
    {

        public AutomationElement SaveAndExitButton
        {
            get
            {
                return this.Context.FindFirstChild(x => x.ByName("Save & Exit").And(x.ByControlType(ControlType.Button)));
            }
        }

        public AutomationElement ExitNoSaveButton
        {
            get
            {
                return this.Context.FindFirstChild(x => x.ByName("Exit - No Save").And(x.ByControlType(ControlType.Button)));
            }
        }

        public AutomationElement CancelButton
        {
            get
            {
                return this.Context.FindFirstChild(x => x.ByName("Cancel").And(x.ByControlType(ControlType.Button)));
            }
        }

        public ExitingWindow(ApplicationHelper applicationHelper) : base(applicationHelper)
        {

        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = ApplicationHelper.GetDialogByName("Exiting") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
