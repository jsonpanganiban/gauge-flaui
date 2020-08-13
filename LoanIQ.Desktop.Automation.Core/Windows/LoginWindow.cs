using System;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class LoginWindow : WindowBase, IWindowElement
    {
        public LoginWindow(ApplicationHelper applicationHelper) : base(applicationHelper)
        {
        }

        public AutomationElement UserNameTextBox
        {
            get
            {
                return this.Context.FindAllDescendants(x => x.ByControlType(FlaUI.Core.Definitions.ControlType.Edit))[0];
            }
        }

        public AutomationElement PasswordTextBox
        {
            get
            {
                return this.Context.FindAllDescendants(x => x.ByControlType(FlaUI.Core.Definitions.ControlType.Edit))[1];
            }
        }

        public AutomationElement SignInButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("Sign in"));
            }
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = ApplicationHelper.GetWindowByName("Fusion Loan IQ - Login") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
