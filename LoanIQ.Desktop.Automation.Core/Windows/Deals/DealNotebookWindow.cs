using System;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Tools;
using LoanIQ.Desktop.Automation.Core.Elements.Tabs.Common;
using LoanIQ.Desktop.Automation.Core.Elements.Tabs.DealNotebook;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class DealNotebookWindow : TabbedWindowBase, IWindowElement
    {
        #region Menus
        protected AutomationElement MenuBar { get; private set; }

        public AutomationElement FileMenuItem
        {
            get
            {
                return this.MenuBar.FindFirstChild(c => c.ByName("File").And(c.ByControlType(ControlType.MenuItem)));
            }
        }

        public AutomationElement QueriesMenuItem
        {
            get
            {
                return this.MenuBar.FindFirstChild(c => c.ByName("Queries").And(c.ByControlType(ControlType.MenuItem)));
            }
        }

        public AutomationElement QueriesMenuItems(string menuItem)
        {
            return this.Context.FindFirstDescendant(c => c.ByName(menuItem).And(c.ByControlType(ControlType.MenuItem)));
        }

        public AutomationElement DistributionMenuItem
        {
            get
            {
                return this.MenuBar.FindFirstChild(c => c.ByName("Distribution").And(c.ByControlType(ControlType.MenuItem)));
            }
        }


        public AutomationElement OptionMenuItem
        {
            get
            {
                return this.MenuBar.FindFirstChild(c => c.ByName("Options").And(c.ByControlType(ControlType.MenuItem)));
            }
        }

        public AutomationElement UnrestrictDealMenuItem
        {
            get
            {
                return this.Context.FindFirstChild(c => c.ByName("Distribution").And(c.ByControlType(ControlType.Menu))).FindFirstChild(c => c.ByName("Unrestrict Deal"));
            }
        }

        public AutomationElement PrimariesMenuItem
        {
            get
            {
                return this.Context.FindFirstChild(c => c.ByName("Distribution").And(c.ByControlType(ControlType.Menu))).FindFirstChild(c => c.ByName("Primaries..."));
            }
        }

        public AutomationElement Save
        {
            get
            {
                var fileMenu = this.Context.FindFirstChild(c => c.ByControlType(ControlType.Menu));

                return fileMenu.FindFirstDescendant(c => c.ByName("Save"));
            }
        }

        public AutomationElement Exit
        {
            get
            {
                var fileMenu = this.Context.FindFirstChild(c => c.ByControlType(ControlType.Menu));
                return fileMenu.FindFirstDescendant(c => c.ByName("Exit"));
            }
        }

        public AutomationElement Facilities
        {
            get
            {
                return this.Context.FindFirstChild(c => c.ByName("Options").And(c.ByControlType(ControlType.Menu))).FindFirstChild(c => c.ByName("Facilities..."));
            }
        }
        #endregion

        #region Tabs
        public DealSummaryTabItem SummaryTab
        {
            get
            {
                return this.GetTabContentPane<DealSummaryTabItem>();
            }
        }

        public DealPersonnelTabItem PersonnelTab
        {
            get
            {
                return this.GetTabContentPane<DealPersonnelTabItem>();
            }
        }

        public DealRiskOrRegulatoryTabItem RiskOrRegulatoryTab
        {
            get
            {
                return this.GetTabContentPane<DealRiskOrRegulatoryTabItem>();
            }
        }

        public DealCommentsTabItem CommentsTab
        {
            get
            {
                return this.GetTabContentPane<DealCommentsTabItem>();
            }
        }

        public DealRestrictionsTabItem RestrictionsTab
        {
            get
            {
                return this.GetTabContentPane<DealRestrictionsTabItem>();
            }
        }

        public DealMISCodesTabItem MISCodesTab
        {
            get
            {
                return this.GetTabContentPane<DealMISCodesTabItem>();
            }
        }

        public DealAdditionalTabItem AdditionalTab
        {
            get
            {
                return this.GetTabContentPane<DealAdditionalTabItem>();
            }
        }

        public CalendarsTabItem CalendarsTab
        {
            get
            {
                return this.GetTabContentPane<CalendarsTabItem>();
            }
        }

        public DealRatiosOrConditionsTabItem RatiosOrConditionsTab
        {
            get
            {
                return this.GetTabContentPane<DealRatiosOrConditionsTabItem>();
            }
        }

        public DealPricingRulesTabItem PricingRulesTab
        {
            get
            {
                return this.GetTabContentPane<DealPricingRulesTabItem>();
            }
        }

        public WorkflowTabItem WorkflowTab
        {
            get
            {
                return this.GetTabContentPane<WorkflowTabItem>();
            }
        }
        #endregion

        public AutomationElement CloseWindowButton
        {
            get
            {
                return this.Context.FindFirstDescendant(x => x.ByName("Close").And(x.ByControlType(ControlType.Button)));
            }
        }

        

        public bool IsRestricted
        {
            get
            {
                try
                {
                    var control = this.Context.FindFirstDescendant(d => d.ByName("Restricted Deal"));

                    return control != null;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public DealNotebookWindow(ApplicationHelper applicationHelper,
            DealSummaryTabItem summaryTab,
            DealPersonnelTabItem dealPersonnelTabItem,
            DealRiskOrRegulatoryTabItem dealRiskOrRegulatoryTabItem,
            DealCommentsTabItem dealCommentsTabItem,
            DealRestrictionsTabItem dealRestrictionsTabItem,
            DealMISCodesTabItem dealMISCodesTabItem,
            DealAdditionalTabItem dealAdditionalTabItem,
            CalendarsTabItem calendarsTabItem,
            DealRatiosOrConditionsTabItem dealRatiosOrConditionsTabItem,
            DealPricingRulesTabItem dealPricingRulesTabItem,
            WorkflowTabItem workflowTabItem)
            : base(applicationHelper)
        {
            this.MenuBar = this.Context.FindFirstChild(c => c.ByControlType(ControlType.MenuBar));

            this.AddTab(summaryTab);
            this.AddTab(dealPersonnelTabItem);
            this.AddTab(dealRiskOrRegulatoryTabItem);
            this.AddTab(dealCommentsTabItem);
            this.AddTab(dealRestrictionsTabItem);
            this.AddTab(dealMISCodesTabItem);
            this.AddTab(dealAdditionalTabItem);
            this.AddTab(calendarsTabItem);
            this.AddTab(dealRatiosOrConditionsTabItem);
            this.AddTab(dealPricingRulesTabItem);
            this.AddTab(workflowTabItem);
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = this.ApplicationHelper.GetWindowWithNameContaining("Deal Notebook") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
