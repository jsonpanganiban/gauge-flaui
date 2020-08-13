using System;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Tools;
using LoanIQ.Desktop.Automation.Core.Windows.Deals;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class BorrowerSelectWindow : WindowBase
    {
        public BorrowerSelectWindow(ApplicationHelper applicationHelper)
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
                this.Context = this.ApplicationHelper.GetDialogByName("Borrower Select") ?? throw new Exception();
                this.Context.SetForeground();
            }, this.ApplicationHelper.Config.WaitTimeout);
        }
    }
}
