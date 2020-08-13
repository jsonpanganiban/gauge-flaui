using DTAF.Core;
using DTAF.Core.Desktop;
using DTAF.Core.Desktop.Factories;
using LightInject;
using LoanIQ.Desktop.Automation.Core;
using LoanIQ.Desktop.Automation.Core.Elements;
using LoanIQ.Desktop.Automation.Core.Elements.ContextMenus;
using LoanIQ.Desktop.Automation.Core.Elements.Tabs.Common;
using LoanIQ.Desktop.Automation.Core.Elements.Tabs.DealNotebook;
using LoanIQ.Desktop.Automation.Core.Windows;
using LoanIQ.Desktop.Automation.Core.Windows.Deals;
using LoanIQ.Desktop.Automation.Core.Windows.Facility;
using LoanIQ.Desktop.Automation.Core.Windows.Primary;

namespace LoaniqDesktopAutomationTests.steps
{
    public enum DependencyGroup
    {
        Core,
        Deal,
        Facility
    }

    public class LoanIQStepBase : DesktopStepBase
    {
        public LoanIQStepBase()
            : base(new Config("LoanIQJ", @"C:\LIQ747\Client\LoanIQJ.exe", string.Empty, 500))
        {

        }

        protected override void Register()
        {
            base.Register();

            this.Container.Register<WorkflowTabItem>();

            this.Container.Register<CommonSelectCodeWindow>();
            this.Container.Register<WindowFactory<CommonSelectCodeWindow>>();


            this.LoadDependencyGroup(DependencyGroup.Core);
        }

        protected void LoadDependencyGroup(DependencyGroup core)
        {
            switch (core)
            {
                case DependencyGroup.Core:
                    this.LoadCoreDependencies();
                    break;
                case DependencyGroup.Deal:
                    this.LoadDealDependencies();
                    break;
                case DependencyGroup.Facility:
                    this.LoadFacilityDependencies();
                    break;
                default:
                    break;
            }
        }

        private void LoadFacilityDependencies()
        {
            this.Container.Register<FacilityWindow>();
            this.Container.Register<FacilityRiskTypeDetailsWindow>();
            this.Container.Register<FacilityLoanPurposeSelectWindow>();
            this.Container.Register<FacilitySublimitDetailsWindow>();
            this.Container.Register<FacilityModifyRiskTypesSelectionWindow>();
            this.Container.Register<FacilityNavigatorWindow>();
            this.Container.Register<DealFacilitySelectWindow>();
            this.Container.Register<FacilityPenaltySpreadEditorWindow>();
            this.Container.Register<FacilityInterestPricingWindow>();
            this.Container.Register<FacilityInterestPricingAddItemWindow>();
            this.Container.Register<FacilityAmountsWindow>();
            this.Container.Register<FacilityOptionConditionWindow>();
            this.Container.Register<FacilityFormulaCategoryWindow>();
            this.Container.Register<PrimaryListWindow>();
            this.Container.Register<PrimaryCreateWindow>();

            this.Container.Register<WindowFactory<FacilityWindow>>();
            this.Container.Register<WindowFactory<FacilityRiskTypeDetailsWindow>>();
            this.Container.Register<WindowFactory<FacilityLoanPurposeSelectWindow>>();
            this.Container.Register<WindowFactory<FacilitySublimitDetailsWindow>>();
            this.Container.Register<WindowFactory<FacilityModifyRiskTypesSelectionWindow>>();
            this.Container.Register<WindowFactory<FacilityNavigatorWindow>>();
            this.Container.Register<WindowFactory<DealFacilitySelectWindow>>();
            this.Container.Register<WindowFactory<FacilityPenaltySpreadEditorWindow>>();
            this.Container.Register<WindowFactory<FacilityInterestPricingWindow>>();
            this.Container.Register<WindowFactory<FacilityInterestPricingAddItemWindow>>();
            this.Container.Register<WindowFactory<FacilityAmountsWindow>>();
            this.Container.Register<WindowFactory<FacilityOptionConditionWindow>>();
            this.Container.Register<WindowFactory<FacilityFormulaCategoryWindow>>();
            this.Container.Register<WindowFactory<PrimaryListWindow>>();
            this.Container.Register<WindowFactory<PrimaryCreateWindow>>();
        }

        private void LoadCoreDependencies()
        {
            this.Container.Register<WarningWindow>();
            this.Container.Register<DefaultContextMenu>(new PerContainerLifetime());
            this.Container.Register<MenuButtonPane>(new PerContainerLifetime());
            this.Container.Register<MenuButtonTreePane>(new PerContainerLifetime());

            this.Container.Register<LoginWindow>(new PerContainerLifetime());
            this.Container.Register<MainWindow>(new PerContainerLifetime());
            this.Container.Register<DisclaimerWindow>(new PerContainerLifetime());
            this.Container.Register<QuestionWindow>();
            this.Container.Register<ExitingWindow>();

            this.Container.Register<WindowFactory<LoginWindow>>(new PerContainerLifetime());
            this.Container.Register<WindowFactory<MainWindow>>(new PerContainerLifetime());
            this.Container.Register<WindowFactory<DisclaimerWindow>>(new PerContainerLifetime());
            this.Container.Register<WindowFactory<WarningWindow>>();
            this.Container.Register<WindowFactory<DefaultContextMenu>>(new PerContainerLifetime());
            this.Container.Register<WindowFactory<QuestionWindow>>();
            this.Container.Register<WindowFactory<ExitingWindow>>();

        }

        private void LoadDealDependencies()
        {
            this.Container.Register<DealBorrowerOrDepositorSelectWindow>(new PerContainerLifetime());
            this.Container.Register<WindowFactory<DealBorrowerOrDepositorSelectWindow>>(new PerContainerLifetime());

        }
    }
}
