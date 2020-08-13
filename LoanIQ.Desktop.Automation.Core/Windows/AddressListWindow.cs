using System;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class AddressListWindow : WindowBase, IWindowElement
    {
        public AddressListWindow(ApplicationHelper applicationHelper) : base(applicationHelper)
        {
        }

        public AutomationElement AddButton
        {
            get
            {
                return this.Context.FindFirstDescendant(x => x.ByName("Add"));
            }
        }

        public AutomationElement DeleteButton
        {
            get
            {
                return this.Context.FindFirstDescendant(x => x.ByName("Delete"));
            }
        }

        public AutomationElement ExitButton
        {
            get
            {
                return this.Context.FindFirstDescendant(x => x.ByName("Exit"));
            }
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = this.ApplicationHelper.GetWindowNameByRegex(@"Address List for \w+(,\s)\w*") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
