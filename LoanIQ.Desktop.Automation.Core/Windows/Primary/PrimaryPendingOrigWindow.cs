using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Tools;
using LoanIQ.Desktop.Automation.Core.Elements.Tabs.Common;
using LoanIQ.Desktop.Automation.Core.Elements.Tabs.Primary;
using System;

namespace LoanIQ.Desktop.Automation.Core.Windows.Primary
{
    public class PrimaryPendingOrigWindow : TabbedWindowBase, IWindowElement
    {
        protected AutomationElement MenuBar { get { return this.Context.FindFirstChild(c => c.ByControlType(ControlType.MenuBar)); } }

        public AutomationElement Maintenance
        {
            get
            {
                return this.MenuBar.FindFirstChild(c => c.ByName("Maintenance").And(c.ByControlType(ControlType.MenuItem)));
            }
        }

        public AutomationElement PortfolioAllocations
        {
            get
            {
                return this.Context.FindFirstChild(c => c.ByControlType(ControlType.Menu)).FindFirstDescendant(c => c.ByName("Portfolio Allocations"));
            }
        }

        public AutomationElement SellAmount
        {
            get
            {
                return this.Context.FindFirstDescendant(c => c.ByName("Aggregate Amounts")).FindChildAt(0);
            }
        }

        public PendingPrimaryFacilitiesTabItem Facilities
        {
            get
            {
                return this.GetTabContentPane<PendingPrimaryFacilitiesTabItem>();
            }
        }

        public PrimaryAmountsOrDatesTabItem AmountsOrDates
        {
            get
            {
                return this.GetTabContentPane<PrimaryAmountsOrDatesTabItem>();
            }
        }

        public PendingPrimaryContactsTabItem Contacts
        {
            get
            {
                return this.GetTabContentPane<PendingPrimaryContactsTabItem>();
            }
        }

        public PrimaryCodesTabItem Codes
        {
            get
            {
                return this.GetTabContentPane<PrimaryCodesTabItem>();
            }
        }

        public WorkflowTabItem WorkflowTab
        {
            get
            {
                return this.GetTabContentPane<WorkflowTabItem>();
            }
        }

        public PrimaryPendingOrigWindow(ApplicationHelper applicationHelper,
            PendingPrimaryFacilitiesTabItem pendingPrimaryFacilitiesTabItem,
            PrimaryAmountsOrDatesTabItem primaryAmountsOrDatesTabItem,
            PendingPrimaryContactsTabItem pendingPrimaryContactsTabItem,
            PrimaryCodesTabItem primaryCodesTabItem,
            WorkflowTabItem primaryWorkflowTabItem)
            : base(applicationHelper)
        {
            this.AddTab(pendingPrimaryFacilitiesTabItem);
            this.AddTab(primaryAmountsOrDatesTabItem);
            this.AddTab(pendingPrimaryContactsTabItem);
            this.AddTab(primaryCodesTabItem);
            this.AddTab(primaryWorkflowTabItem);
        }

        //protected override AutomationElement TabContentQuery()
        //{
        //    return this.Context.FindChildAt(0);
        //}

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = this.ApplicationHelper.GetWindowWithNameContaining("Pending Orig Primary:") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
