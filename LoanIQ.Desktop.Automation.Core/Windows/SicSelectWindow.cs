using System;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class SicSelectWindow : WindowBase, IWindowElement
    {
        public SicSelectWindow(ApplicationHelper applicationHelper)
            : base(applicationHelper)
        {

        }

        public AutomationElement CodeTextBox
        {
            get
            {
                return this.Context.FindFirstDescendant(x => x.ByControlType(FlaUI.Core.Definitions.ControlType.Edit));
            }
        }

        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindFirstDescendant(x => x.ByName("OK"));
            }
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = this.ApplicationHelper.GetWindowByName("SIC Select") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
