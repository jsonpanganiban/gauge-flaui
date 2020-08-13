using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using System;

namespace LoanIQ.Desktop.Automation.Core.Windows.Contacts
{
    public class ContactsCircleWindow : WindowBase, IWindowElement
    {
        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("OK"));
            }
        }

        public AutomationElement AvailableList
        {
            get
            {
                return this.Context.FindChildAt(3).FindChildAt(1).FindChildAt(0);
            }
        }

        public ContactsCircleWindow(ApplicationHelper applicationHelper)
            :base(applicationHelper)
        {
            
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = this.ApplicationHelper.GetWindowWithNameContaining("Circle Contacts For") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
