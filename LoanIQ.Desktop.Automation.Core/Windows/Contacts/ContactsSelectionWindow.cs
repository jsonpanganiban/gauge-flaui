using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using System;

namespace LoanIQ.Desktop.Automation.Core.Windows.Contacts
{
    public class ContactsSelectionWindow : WindowBase, IWindowElement
    {
        public AutomationElement ExitButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("Exit"));
            }
        }

        public ContactsSelectionWindow(ApplicationHelper applicationHelper)
            : base(applicationHelper)
        {

        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = this.ApplicationHelper.GetWindowByName("Contact Selection") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
