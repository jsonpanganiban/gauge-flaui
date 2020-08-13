using System;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using FlaUI.UIA3;
using LoanIQ.Desktop.Automation.Core.Windows;

namespace LoanIQ.Desktop.Automation.Core.Elements.Tabs.DealNotebook
{
    public class DealFacilitySelectWindow : WindowBase, IWindowElement
    {
        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("OK"));
            }
        }

        public AutomationElement FacilityName
        {
            get
            {
                return this.Context.FindChildAt(4);
            }
        }

        public AutomationElement FacilityType
        {
            get
            {
                return this.Context.FindChildAt(6);
            }
        }

        public AutomationElement AnsiId
        {
            get
            {
                return this.Context.FindChildAt(10);
            }
        }

        public AutomationElement ProposedCmtAmount
        {
            get
            {
                return this.Context.FindChildAt(12);
            }
        }
        public AutomationElement Currency
        {
            get
            {
                return this.Context.FindChildAt(14);
            }
        }


        public DealFacilitySelectWindow(ApplicationHelper applicationHelper)
            : base(applicationHelper)
        {

        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                using (var automation = new UIA3Automation())
                {
                    var expenseWindow = this.ApplicationHelper.GetWindowByName("Facility Select");

                    this.Context = expenseWindow ?? throw new Exception();
                    this.Context.SetForeground();
                }
            }, this.ApplicationHelper.Config.WaitTimeout);
        }
    }
}
