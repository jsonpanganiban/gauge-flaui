using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using System;

namespace LoanIQ.Desktop.Automation.Core.Windows.Primary
{
    public class PrimaryCreateWindow : WindowBase, IWindowElement
    {
        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("OK"));
            }
        }

        public AutomationElement LenderButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("Lender:"));
            }
        }

        public AutomationElement BroughtInByButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("Brought In By:"));
            }
        }

        public PrimaryCreateWindow(ApplicationHelper applicationHelper)
            : base(applicationHelper)
        {

        }
        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = this.ApplicationHelper.GetWindowWithNameContaining("Create Primary") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
