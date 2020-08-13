using System;
using System.Linq;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Tools;
using LoanIQ.Desktop.Automation.Core.Elements.Tabs.Facility;
using LoanIQ.Desktop.Automation.Core.Windows.Facility;

namespace LoanIQ.Desktop.Automation.Core.Windows.Deals
{
    public class FacilityWindow : TabbedWindowBase, IWindowElement
    {
        public FacilitySummaryTabItem SummaryTab
        {
            get
            {
                return this.GetTabContentPane<FacilitySummaryTabItem>();
            }
        }

        public FacilityTypesOrPurposeTabItem TypesOrPurposesTab
        {
            get
            {
                return this.GetTabContentPane<FacilityTypesOrPurposeTabItem>();
            }
        }

        public SublimitOrCustTabItem SublimitOrCustTab
        {
            get
            {
                return this.GetTabContentPane<SublimitOrCustTabItem>();
            }
        }

        public FacilityRiskTabItem RiskTab
        {
            get
            {
                return this.GetTabContentPane<FacilityRiskTabItem>();
            }
        }

        public FacilityPricingTabItem PricingTab
        {
            get
            {
                return this.GetTabContentPane<FacilityPricingTabItem>();
            }
        }

        protected AutomationElement MenuBar { get; private set; }

        public FacilityWindow(ApplicationHelper applicationHelper,
            FacilitySummaryTabItem facilitySummaryTabItem,
            FacilityTypesOrPurposeTabItem facilityTypesOrPurposeTabItem,
            SublimitOrCustTabItem sublimitOrCustTabItem,
            FacilityRiskTabItem facilityRiskTabItem,
            FacilityPricingTabItem facilityPricingTabItem)
            : base(applicationHelper)
        {
            this.AddTab(facilitySummaryTabItem);
            this.AddTab(facilityTypesOrPurposeTabItem);
            this.AddTab(sublimitOrCustTabItem);
            this.AddTab(facilityRiskTabItem);
            this.AddTab(facilityPricingTabItem);
        }

        public AutomationElement CloseWindowButton
        {
            get
            {
                return this.Context.FindFirstDescendant(x => x.ByName("Close").And(x.ByControlType(ControlType.Button)));
            }
        }

        public AutomationElement MenuBarItem(string menuBarItem)
        {
            return Context.FindAllChildren(x => x.ByControlType(ControlType.MenuBar)).Select(c => c.FindFirstChild(cx =>
                            cx.ByName(menuBarItem).And(cx.ByControlType(ControlType.MenuItem)))).First();
        }

        public AutomationElement MenuItem(string menuItem)
        {
            return this.Context.FindFirstDescendant(c => c.ByName(menuItem).And(c.ByControlType(ControlType.MenuItem)));
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = this.ApplicationHelper.GetWindowWithNameContaining("Facility -") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
