using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using System;
using FlaUI.Core.Definitions;
using LoanIQ.Desktop.Automation.Core.Elements.Tabs.DealNotebook;
using DTAF.Core.Desktop.Contracts;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class DrawdownLiborOptionInitialWindow : WindowBase, IWindowElement
    {
        public DrawdownGeneralTabItem GeneralTab { get; private set; }
        public DrawdownRatesTabItem RatesTab { get; private set; }
        public DrawdownEventsTabItem EventsTab { get; private set; }
        public DrawdownWorkflowTabItem WorkflowTab { get; private set; }
        public DrawdownCodesTabItem CodesTab { get; private set; }
        public DrawdownAdditionalTabItem AdditionalTab { get; private set; }
        public DrawdownCalendarTabItem CalendarTab { get; private set; }
        protected AutomationElement MenuBar { get; private set; }

        public AutomationElement FileMenu
        {
            get
            {
                return this.MenuBar.FindFirstChild(c => c.ByName("File").And(c.ByControlType(ControlType.MenuItem)));
            }
        }

        public AutomationElement OptionsMenu
        {
            get
            {
                return this.MenuBar.FindFirstChild(c => c.ByName("Options").And(c.ByControlType(ControlType.MenuItem)));
            }
        }

        public AutomationElement QueriesMenu
        {
            get
            {
                return this.MenuBar.FindFirstChild(c => c.ByName("Queries").And(c.ByControlType(ControlType.MenuItem)));
            }
        }

        public AutomationElement AccountingMenu
        {
            get
            {
                return this.MenuBar.FindFirstChild(c => c.ByName("Accounting").And(c.ByControlType(ControlType.MenuItem)));
            }
        }

        public AutomationElement InstantMessageMenu
        {
            get
            {
                return this.MenuBar.FindFirstChild(c => c.ByName("InstantMessage").And(c.ByControlType(ControlType.MenuItem)));
            }
        }

        public AutomationElement FileMenuItems(string menuItem)
        {
            return this.MenuBar.FindFirstChild(c => c.ByName("File")).FindFirstChild(k => k.ByName(menuItem)
                .And(k.ByControlType(ControlType.MenuItem)));
        }

        public AutomationElement OptionsMenuItems(string menuItem)
        {
            return this.Context.FindFirstChild(c => c.ByName("Options")).FindFirstChild(k => k.ByName(menuItem)
                .And(k.ByControlType(ControlType.MenuItem)));
        }

        public AutomationElement AccountingMenuItems(string menuItem)
        {
            return this.Context.FindFirstChild(c => c.ByName("Accounting")).FindFirstChild(k => k.ByName(menuItem)
                .And(k.ByControlType(ControlType.MenuItem)));
        }

        public AutomationElement QueriesMenuItems(string menuItem)
        {
            return this.Context.FindFirstChild(c => c.ByName("Queries")).FindFirstChild(k => k.ByName(menuItem)
                .And(k.ByControlType(ControlType.MenuItem)));
        }

        public AutomationElement InstantMessageMenuItems(string menuItem)
        {
            return this.Context.FindFirstChild(c => c.ByName("Instant Message")).FindFirstChild(k => k.ByName(menuItem)
                .And(k.ByControlType(ControlType.MenuItem)));
        }

        public AutomationElement GeneralTabItem
        {
            get
            {
                return this.Context.FindFirstDescendant(c => c.ByName("General").And(c.ByControlType(ControlType.TabItem)));
            }
        }

        public AutomationElement RatesTabItem
        {
            get
            {
                return this.Context.FindFirstDescendant(c => c.ByName("Rates").And(c.ByControlType(ControlType.TabItem)));
            }
        }

        public AutomationElement EventsTabItem
        {
            get
            {
                return this.Context.FindFirstDescendant(c => c.ByName("Events").And(c.ByControlType(ControlType.TabItem)));
            }
        }

        public AutomationElement WorkflowTabItem
        {
            get
            {
                return this.Context.FindFirstDescendant(c => c.ByName("Workflow").And(c.ByControlType(ControlType.TabItem)));
            }
        }

        public AutomationElement CodesTabItem
        {
            get
            {
                return this.Context.FindFirstDescendant(c => c.ByName("Codes").And(c.ByControlType(ControlType.TabItem)));
            }
        }

        public AutomationElement AdditionalTabItem
        {
            get
            {
                return this.Context.FindFirstDescendant(c => c.ByName("Additional").And(c.ByControlType(ControlType.TabItem)));
            }
        }

        public AutomationElement CommentsTabItem
        {
            get
            {
                return this.Context.FindFirstDescendant(c => c.ByName("Comments").And(c.ByControlType(ControlType.TabItem)));
            }
        }

        public AutomationElement CalendarsTabItem
        {
            get
            {
                return this.Context.FindFirstDescendant(c => c.ByName("Calendars").And(c.ByControlType(ControlType.TabItem)));
            }
        }

        public AutomationElement FeePricingTabItem
        {
            get
            {
                return this.Context.FindFirstDescendant(c => c.ByName("Fee Pricing").And(c.ByControlType(ControlType.TabItem)));
            }
        }

        public AutomationElement PastDuePricingTabItem
        {
            get
            {
                return this.Context.FindFirstDescendant(c => c.ByName("Past Due Pricing").And(c.ByControlType(ControlType.TabItem)));
            }
        }

        public AutomationElement CloseWindowButton
        {
            get
            {
                return this.Context.FindFirstDescendant(x => x.ByName("Close"));
            }
        }

        public DrawdownLiborOptionInitialWindow(ApplicationHelper applicationHelper,
                        DrawdownGeneralTabItem drawdownGeneralTabItem,
                        DrawdownRatesTabItem drawdownRatesTabItem,
                        DrawdownEventsTabItem drawdownEventsTabItem,
                        DrawdownWorkflowTabItem drawdownWorkflowTabItem,
                        DrawdownCodesTabItem drawdownCodesTabItem,
                        DrawdownAdditionalTabItem drawdownAdditionalTabItem,
                        DrawdownCalendarTabItem drawdownCalendarTabItem)
                        : base(applicationHelper)
        {

            this.GeneralTab = drawdownGeneralTabItem;
            this.RatesTab = drawdownRatesTabItem;
            this.EventsTab = drawdownEventsTabItem;
            this.WorkflowTab = drawdownWorkflowTabItem;
            this.CodesTab = drawdownCodesTabItem;
            this.AdditionalTab = drawdownAdditionalTabItem;
            this.CalendarTab = drawdownCalendarTabItem;

            this.GeneralTab.Context = this.Context.FindFirstChild();
            this.RatesTab.Context = this.Context.FindFirstChild();
            this.EventsTab.Context = this.Context.FindFirstChild();
            this.WorkflowTab.Context = this.Context.FindFirstChild();
            this.CodesTab.Context = this.Context.FindFirstChild();
            this.AdditionalTab.Context = this.Context.FindFirstChild();
            this.CalendarTab.Context = this.Context.FindFirstChild();
            this.MenuBar = this.Context.FindFirstChild(c => c.ByControlType(ControlType.MenuBar));

        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = ApplicationHelper.GetWindowWithNameContaining("Libor Option Initial Drawdown") ??
                                throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
