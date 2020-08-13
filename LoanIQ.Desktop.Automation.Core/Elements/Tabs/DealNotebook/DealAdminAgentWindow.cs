using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using LoanIQ.Desktop.Automation.Core.Windows;
using System;

namespace LoanIQ.Desktop.Automation.Core.Elements.Tabs.DealNotebook
{
    public class DealAdminAgentWindow : WindowBase, IWindowElement
    {
        public AutomationElement CustomerButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("Customer"));
            }
        }

        public AutomationElement ServicingGroupButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("Servicing Group"));
            }
        }

        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("OK"));
            }
        }

        public DealAdminAgentWindow(ApplicationHelper applicationHelper)
            : base(applicationHelper)
        {

        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = this.ApplicationHelper.GetWindowWithNameContaining("Deal Admin Agent for") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
