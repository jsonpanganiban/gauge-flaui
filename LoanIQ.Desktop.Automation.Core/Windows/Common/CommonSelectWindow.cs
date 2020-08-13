using System;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Tools;

namespace LoanIQ.Desktop.Automation.Core.Windows.Common
{
    public class CommonSelectWindow : WindowBase, IWindowElement
    {
        public CommonSelectWindow(ApplicationHelper applicationHelper)
            : base(applicationHelper)
        {
            
        }

        public AutomationElement SearchButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("Search").And(d.ByControlType(ControlType.Button)));
            }
        }

        public AutomationElement IdentifyBy
        {
            get
            {
                return this.Context.FindChildAt(0);
            }
        }

        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("OK").And(d.ByControlType(ControlType.Button)));
            }
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = this.ApplicationHelper.GetWindowsByNames(new[] { "Borrower Select", "Lender Select" }) ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
