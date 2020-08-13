using System;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Tools;
using LoanIQ.Desktop.Automation.Core.Elements.Tabs;
using LoanIQ.Desktop.Automation.Core.Elements.Tabs.ActiveCustomer;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class ActiveCustomerWindow : WindowBase, IWindowElement
    {
        public ActiveCustomerWindow(ApplicationHelper applicationHelper,
                                    GeneralTab generalTab,
                                    CorporateTab corpTab,
                                    RiskTabItem riskTab,
                                    ProfileTabItem profileTab)
            : base(applicationHelper)
        {
            this.GeneralTab = generalTab;
            this.CorporateTab = corpTab;
            this.RiskTab = riskTab;
            this.ProfileTab = profileTab;

            this.GeneralTab.Context = this.Context.FindFirstChild();
            this.CorporateTab.Context = this.Context.FindFirstChild();
            this.RiskTab.Context = this.Context.FindFirstChild();
            this.ProfileTab.Context = this.Context.FindFirstChild();
        }

        public GeneralTab GeneralTab { get; private set; }
        public CorporateTab CorporateTab { get; private set; }
        public RiskTabItem RiskTab { get; private set; }
        public ProfileTabItem ProfileTab { get; set; }
        public RiskTabItem SicTab { get; private set; }

        public AutomationElement GeneralTabItem
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByName("General").And(_.ByControlType(ControlType.TabItem)));
            }
        }

        public AutomationElement RiskTabItem
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByName("Risk"));
            }
        }

        public AutomationElement CorporateTabItem
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByName("Corporate"));
            }
        }

        public AutomationElement SICTabItem
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByName("SIC"));
            }
        }

        public AutomationElement BusTerrTabItem
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByName("Bus Terr"));
            }
        }

        public AutomationElement MISCodesTabItem
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByName("MIS Codes"));
            }
        }

        public AutomationElement PersonnelTabItem
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByName("Personnel"));
            }
        }

        public AutomationElement EventsTabItem
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByName("Events"));
            }
        }

        public AutomationElement PendingTabItem
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByName("Pending"));
            }
        }

        public AutomationElement CommentsTabItem
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByName("Comments"));
            }
        }

        public AutomationElement ProfilesTabItem
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByName("Profiles").And(_.ByControlType(ControlType.TabItem)));
            }
        }

        public AutomationElement WorkflowTabItem
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByName("Workflow"));
            }
        }

        public AutomationElement AdditionalTabItem
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByName("Additional"));
            }
        }



        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = ApplicationHelper.GetWindowWithNameContaining("Active Customer --") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
