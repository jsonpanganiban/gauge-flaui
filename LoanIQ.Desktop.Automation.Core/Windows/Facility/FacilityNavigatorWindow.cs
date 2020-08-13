using System;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;

namespace LoanIQ.Desktop.Automation.Core.Windows.Deals
{
    public class FacilityNavigatorWindow : WindowBase, IWindowElement
    {
        public AutomationElement AddButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("Add"));
            }
        }

        public AutomationElement ExitButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("Exit"));
            }
        }

        public FacilityNavigatorWindow(ApplicationHelper applicationHelper)
            : base(applicationHelper)
        {

        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = this.ApplicationHelper.GetWindowWithNameContaining("Facility Navigator") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
