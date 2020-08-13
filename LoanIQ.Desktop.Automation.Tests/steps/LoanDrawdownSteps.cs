using DTAF.Core.Desktop.Actions;
using DTAF.Core.Desktop.Factories;
using Gauge.CSharp.Lib.Attribute;
using LightInject;
using LoanIQ.Desktop.Automation.Core;
using LoanIQ.Desktop.Automation.Core.Elements.ContextMenus;
using LoanIQ.Desktop.Automation.Core.Elements.Tabs.DealNotebook;
using LoanIQ.Desktop.Automation.Core.Elements.Tabs.Facility;
using LoanIQ.Desktop.Automation.Core.Windows;
using LoanIQ.Desktop.Automation.Core.Windows.Deals;
using LoanIQ.Desktop.Automation.Core.Windows.Facility;
using LoaniqDesktopAutomationTests.steps;
using FlaUI.Core.WindowsAPI;
using Gauge.CSharp.Lib;
using DTAF.Core.Desktop.Helpers;

namespace LoaniqDesktopAutomationTests
{
    public class LoanDrawdown : LoanIQStepBase
    {

        [Step("Select Item <item> From Favorites")]
        public void SelectItemFromFavorites(string item)
        {
            var mainWindow = Container.GetInstance<WindowFactory<MainWindow>>().Context;
            Click.On(mainWindow.MenuButtonPane.Favorites);
            RightClick.On(mainWindow.MenuButtonTreePane.FindTreeItem("DEAL_TEST"));
        }

        [Step("Select Context MenuItem <menuItem>")]
        public void SelectContextMenuItem(string menuItem)
        {
            var defaultContextMenu = Container.GetInstance<WindowFactory<DefaultContextMenu>>().Context;
            Click.On(defaultContextMenu.MenuItem(menuItem));
        }

        [Step("Create New Outstanding Select <outstandingTable>")]
        public void CreateNewOutstandingSelect(Table outstandingTable)
        {
            var outstandingWindow = Container.GetInstance<WindowFactory<OutstandingSelectWindow>>().Context;
            Click.On(outstandingWindow.NewRadioButton, true);
            Wait.UntilVisible(outstandingWindow.DealTextBox);
            if (outstandingTable.FindValue("Deal") != null)
            {
                Enter.TextInto(outstandingWindow.DealTextBox, outstandingTable.FindValue("Deal"), VirtualKeyShort.TAB, true);
            }
            if (outstandingTable.FindValue("Pricing Option") != null)
            {
                Select.By(outstandingWindow.PricingOptionComboBox, "Libor Option");
            }
            Click.On(outstandingWindow.OkButton, true);
            this.ConfirmWarningAndQuestionWindow();
        }

        [Step("Close Drawdown Libor Option Initial Window Without Saving")]
        public void CloseDrawdownLiborOptionInitialWindowWithoutSaving()
        {
            var liborOptionWindow = Container.GetInstance<WindowFactory<DrawdownLiborOptionInitialWindow>>().Context;
            Click.On(liborOptionWindow.CloseWindowButton);
            var exitingWindow = Container.GetInstance<WindowFactory<ExitingWindow>>().Context;
            Click.On(exitingWindow.ExitNoSaveButton);
        }

        [Step("Select Existing Deal <deal>")]
        public void SelectExistingDeal(string deal)
        {
            var dealSelectWindow = Container.GetInstance<WindowFactory<DealSelectWindow>>().Context;
            Click.On(dealSelectWindow.ExistingRadioButton);
            Enter.TextInto(dealSelectWindow.NameTextBox, deal);
            Click.On(dealSelectWindow.OkButton, true);
        }

        [Step("Select Outstanding Select From Deal Notebook Window")]
        public void SelectOutstandingSelectFromDealNotebookWindow()
        {
            var dealNotebookWindow = Container.GetInstance<WindowFactory<DealNotebookWindow>>().Context;
            Click.On(dealNotebookWindow.QueriesMenuItem);
            Click.On(dealNotebookWindow.QueriesMenuItems("Outstanding Select..."));
        }

        [Step("Populate Facility Select <facilityTable>")]
        public void PopulateFacilitySelect(Table facilityTable)
        {
            var facilitySelectWindow = Container.GetInstance<WindowFactory<FacilitySelectWindow>>().Context;
            Enter.TextInto(facilitySelectWindow.DealTextBox, facilityTable.FindValue("Deal"));
            Enter.TextInto(facilitySelectWindow.NameTextBox, facilityTable.FindValue("Name"));
            Click.On(facilitySelectWindow.OkButton, true);
        }

        [Step("Create Outstanding Select From Facility Window")]
        public void CreateOutstandingSelectFromFacilityWindow()
        {
            var facilityWindow = Container.GetInstance<WindowFactory<FacilityWindow>>().Context;
            Click.On(facilityWindow.MenuBarItem("Queries"));
            Click.On(facilityWindow.MenuItem("Outstanding Select..."));

            var outstandingWindow = Container.GetInstance<WindowFactory<OutstandingSelectWindow>>().Context;
            Click.On(outstandingWindow.NewRadioButton, true);
            Click.On(outstandingWindow.OkButton, true);
            this.ConfirmWarningAndQuestionWindow();
        }

        [Step("Populate General Tab In Libor Option Initial Drawdown Window <generalTabTable>")]
        public void PopulateGeneralTabInLiborOptionInitialDrawdownWindow(Table generalTabTable)
        {
            var liborOptionWindow = Container.GetInstance<WindowFactory<DrawdownLiborOptionInitialWindow>>().Context;
            Click.On(liborOptionWindow.GeneralTabItem);
            Enter.TextInto(liborOptionWindow.GeneralTab.EffectiveDateTextBox, generalTabTable.FindValue("Effective Date"));
            Enter.TextInto(liborOptionWindow.GeneralTab.MaturityDateTextBox, generalTabTable.FindValue("Maturity Date"));
            Enter.TextInto(liborOptionWindow.GeneralTab.AmountsRequestedTextBox, generalTabTable.FindValue("Amounts Requested"));
            Enter.TextInto(liborOptionWindow.GeneralTab.RepricingDateTextBox, generalTabTable.FindValue("Repricing Date"));
            Select.ByAndWait(liborOptionWindow.GeneralTab.RepricingFrequencyComboBox, generalTabTable.FindValue("Repricing Frequency"),
                    liborOptionWindow.GeneralTab.IntCycleFrequencyComboBox, generalTabTable.FindValue("Int Cycle Frequency"));
            Click.On(liborOptionWindow.RatesTabItem);
            Click.On(liborOptionWindow.RatesTab.BaseRateButton);
            var warningWindow = Container.GetInstance<WindowFactory<WarningWindow>>().Context;
            Click.On(warningWindow.YesButton);
        }

        [Step("Set Base Rate With <baseRate> And Ovveride Spread With <overrideSpread>")]
        public void SetBaseRateAndOvverideSpread(string baseRate, string overrideSpread)
        {
            var setBaseRate = Container.GetInstance<WindowFactory<DrawdownSetBaseRateWindow>>().Context;
            Enter.TextInto(setBaseRate.BorrowerBaseRateTextBox, baseRate);
            Click.On(setBaseRate.OkButton, true);

            var liborOptionWindow = Container.GetInstance<WindowFactory<DrawdownLiborOptionInitialWindow>>().Context;
            Click.On(liborOptionWindow.RatesTab.SpreadButton);
            var overrideSpreadWindow = Container.GetInstance<WindowFactory<DrawdownOverrideSpreadWindow>>().Context;
            Enter.TextInto(overrideSpreadWindow.SpreadOverrideTextBox, overrideSpread);
            Click.On(overrideSpreadWindow.OkButton, true);
            var warn = Container.GetInstance<WindowFactory<WarningWindow>>().Context;
            Click.On(warn.YesButton, true);
        }

        [Step("Populate Code And Calendars Tab <tableCodeCalendars>")]
        public void PopulateCodeAndCalendarsTab(Table tableCodeCalendars)
        {
            var liborOptionWindow = Container.GetInstance<WindowFactory<DrawdownLiborOptionInitialWindow>>().Context;
            Click.On(liborOptionWindow.EventsTabItem);

            Click.On(liborOptionWindow.CodesTabItem, true);
            Select.By(liborOptionWindow.CodesTab.TreasuryReportingAreaComboBox, tableCodeCalendars.FindValue("Treasury Reporting Area"));

            Click.On(liborOptionWindow.CalendarsTabItem);
            Click.On(liborOptionWindow.CalendarTab.AddButton);

            var holidayWindow = Container.GetInstance<WindowFactory<DrawdownHolidayCalendarWindow>>().Context;
            Select.By(holidayWindow.CalendarComboBox, tableCodeCalendars.FindValue("Calendar"), VirtualKeyShort.ENTER);
            Click.On(holidayWindow.CalendarComboBox);
            Click.On(holidayWindow.OkButton, true);
        }

        [Step("Create Cash Flow")]
        public void CreateCashFlow()
        {
            Wait.For(GetWindow<DrawdownLiborOptionInitialWindow>(), liborOptionWindow =>
            {
                Click.On(liborOptionWindow.OptionsMenu);
                Click.On(liborOptionWindow.OptionsMenuItems("Cashflow"));
                var warning = Container.GetInstance<WindowFactory<WarningWindow>>().Context;
                Click.On(warning.YesButton);
            }
            );

            var cashflowWindow = Container.GetInstance<WindowFactory<DrawdownCashflowForLiborOptionInitialWindow>>().Context;
            DoubleClick.On(cashflowWindow.RowItem(1));

            var detailsWindow = Container.GetInstance<WindowFactory<DrawdownDetailsForCashflowWindow>>().Context;
            Click.On(detailsWindow.SelectRemittanceInstructions);

            var remittancewWindow = Container.GetInstance<WindowFactory<DrawdownChooseRemittanceInstructionsWindow>>().Context;
            Click.On(remittancewWindow.OkButton, true);

            Click.On(detailsWindow.OkButton, true);
            Click.On(cashflowWindow.OkButton, true);

            Wait.For(GetWindow<DrawdownLiborOptionInitialWindow>(), window =>
            {
                Click.On(window.WorkflowTabItem, true);
                Click.On(window.OptionsMenu);
                Click.On(window.OptionsMenuItems("View/Update Match Funded Cost of Funds"));
            });

            var costOfFundsLiborOptionwWindow = Container.GetInstance<WindowFactory<DrawdownCostOfFundsInUSDForLiborOptionInitialWindow>>().Context;
            DoubleClick.On(costOfFundsLiborOptionwWindow.RowItem(1));

            var costOfFundsInUSDwWindow = Container.GetInstance<WindowFactory<DrawdownCostOfFundsInUSDWindow>>().Context;
            Enter.TextInto(costOfFundsInUSDwWindow.RateTextBox, "0.11", true);
            Click.On(costOfFundsInUSDwWindow.OkButton, true);
            Click.On(costOfFundsLiborOptionwWindow.OkButton, true);
        }

        [Step("Select Action <actionItem>")]
        public void SelectAction(string actionItem)
        {
            var mainWindow = Container.GetInstance<WindowFactory<MainWindow>>().Context;
            Click.On(mainWindow.MenuButtonPane.Actions);
            DoubleClick.On(mainWindow.MenuButtonTreePane.FindTreeItem(actionItem));
        }

        private void ConfirmWarningAndQuestionWindow()
        {
            var warningWindow = Container.GetInstance<WindowFactory<WarningWindow>>().Context;
            Click.On(warningWindow.YesButton);

            var questionWindow = Container.GetInstance<WindowFactory<QuestionWindow>>().Context;
            Click.On(questionWindow.YesButton, true);
        }

        protected override void Register()
        {
            base.Register();

            // ELEMENTS
            this.Container.Register<DealSummaryTabItem>();
            this.Container.Register<DealPersonnelTabItem>();
            this.Container.Register<DealRiskOrRegulatoryTabItem>();
            this.Container.Register<DealCommentsTabItem>();
            this.Container.Register<DealRestrictionsTabItem>();
            this.Container.Register<DealMISCodesTabItem>();
            this.Container.Register<DealAdditionalTabItem>();
            this.Container.Register<CalendarsTabItem>();
            this.Container.Register<DealRatiosOrConditionsTabItem>();
            this.Container.Register<DealPricingRulesTabItem>();
            this.Container.Register<FacilitySummaryTabItem>();
            this.Container.Register<FacilityTypesOrPurposeTabItem>();
            this.Container.Register<SublimitOrCustTabItem>();
            this.Container.Register<FacilityRiskTabItem>();
            this.Container.Register<FacilityPricingTabItem>();
            this.Container.Register<DrawdownGeneralTabItem>();
            this.Container.Register<DrawdownRatesTabItem>();
            this.Container.Register<DrawdownEventsTabItem>();
            this.Container.Register<DrawdownWorkflowTabItem>();
            this.Container.Register<DrawdownCodesTabItem>();
            this.Container.Register<DrawdownAdditionalTabItem>();
            this.Container.Register<DrawdownCalendarTabItem>();

            this.Container.Register<DrawdownLiborOptionInitialWindow>();
            this.Container.Register<DrawdownSetBaseRateWindow>(new PerContainerLifetime());
            this.Container.Register<DrawdownOverrideSpreadWindow>(new PerContainerLifetime());
            this.Container.Register<DrawdownHolidayCalendarWindow>(new PerContainerLifetime());
            this.Container.Register<OutstandingSelectWindow>();
            this.Container.Register<DealSelectWindow>(new PerContainerLifetime());
            this.Container.Register<DealNotebookWindow>();
            this.Container.Register<FacilitySelectWindow>(new PerContainerLifetime());
            this.Container.Register<FacilityWindow>(new PerContainerLifetime());
            this.Container.Register<DrawdownCashflowForLiborOptionInitialWindow>(new PerContainerLifetime());
            this.Container.Register<DrawdownDetailsForCashflowWindow>(new PerContainerLifetime());
            this.Container.Register<DrawdownChooseRemittanceInstructionsWindow>(new PerContainerLifetime());
            this.Container.Register<DrawdownCostOfFundsInUSDForLiborOptionInitialWindow>(new PerContainerLifetime());
            this.Container.Register<DrawdownCostOfFundsInUSDWindow>(new PerContainerLifetime());

            this.Container.Register<WindowFactory<OutstandingSelectWindow>>();
            this.Container.Register<WindowFactory<DealSelectWindow>>(new PerContainerLifetime());
            this.Container.Register<WindowFactory<DealNotebookWindow>>();
            this.Container.Register<WindowFactory<FacilitySelectWindow>>(new PerContainerLifetime());
            this.Container.Register<WindowFactory<FacilityWindow>>(new PerContainerLifetime());
            this.Container.Register<WindowFactory<DrawdownSetBaseRateWindow>>(new PerContainerLifetime());
            this.Container.Register<WindowFactory<DrawdownOverrideSpreadWindow>>(new PerContainerLifetime());
            this.Container.Register<WindowFactory<DrawdownHolidayCalendarWindow>>(new PerContainerLifetime());
            this.Container.Register<WindowFactory<DrawdownLiborOptionInitialWindow>>();
            this.Container.Register<WindowFactory<DrawdownCashflowForLiborOptionInitialWindow>>();
            this.Container.Register<WindowFactory<DrawdownDetailsForCashflowWindow>>();
            this.Container.Register<WindowFactory<DrawdownChooseRemittanceInstructionsWindow>>();
            this.Container.Register<WindowFactory<DrawdownCostOfFundsInUSDForLiborOptionInitialWindow>>();
            this.Container.Register<WindowFactory<DrawdownCostOfFundsInUSDWindow>>();

        }
    }
}
