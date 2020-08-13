using FlaUI.Core.WindowsAPI;
using LightInject;
using Gauge.CSharp.Lib.Attribute;
using Gauge.CSharp.Lib;
using DTAF.Core.Desktop.Factories;
using DTAF.Core.Desktop.Actions;
using DTAF.Core.Desktop.Helpers;
using LoanIQ.Desktop.Automation.Core;
using LoanIQ.Desktop.Automation.Core.Windows;
using LoanIQ.Desktop.Automation.Core.Helpers;
using LoanIQ.Desktop.Automation.Core.Windows.Deals;
using LoanIQ.Desktop.Automation.Core.Elements.Tabs.DealNotebook;
using LoanIQ.Desktop.Automation.Core.Windows.Facility;
using LoanIQ.Desktop.Automation.Core.Elements.Tabs.Facility;
using LoanIQ.Desktop.Automation.Core.Windows.Common;
using LoanIQ.Desktop.Automation.Core.Windows.Primary;
using LoanIQ.Desktop.Automation.Core.Elements.Tabs.Primary;
using LoanIQ.Desktop.Automation.Core.Windows.Contacts;
using LoanIQ.Desktop.Automation.Core.Windows.Portfolio;
using DTAF.Core.Helpers;

namespace LoaniqDesktopAutomationTests.steps
{
    public class DealSteps : LoanIQStepBase
    {
        [Step("Create new <dealName>, <dealAlias>, <currency>")]
        public void CreateDeal(string dealName, string dealAlias, string currency)
        {
            Wait.For(this.GetWindow<MainWindow>(), window =>
            {
                window.Maximize();

                Click.On(window.MenuButtonPane.Actions);
                DoubleClick.On(window.MenuButtonTreePane.FindTreeItem("Deal"));
            });

            Wait.For(this.GetWindow<DealSelectWindow>(), window =>
            {
                Click.On(window.NewRadioButton);
                Enter.TextInto(window.NameTextBox, StringHelpers.GenerateNameWithSuffix(dealName));
                Enter.TextInto(window.AliasTextBox, StringHelpers.GenerateNameWithSuffix(dealAlias));
                Select.By(window.CurrencyComboBox, currency);
                Select.By(window.DepartmentComboBox, 0);
                Click.On(window.OkButton);

                Wait.For(this.GetWindow<WarningWindow>(), dialog =>
                {
                    Click.On(dialog.YesButton);
                });

            }, WaitToFinish.YES);
        }

        [Step("Unrestrict <dealName>")]
        public void UnrestrictDeal(string dealName)
        {
            Wait.For(this.GetWindow<DealNotebookWindow>(), window =>
            {
                Click.On(window.DistributionMenuItem);
                Click.On(window.UnrestrictDealMenuItem);

                Verify.Equals(window.IsRestricted, true);

                Wait.For(this.GetWindow<WarningWindow>(), dialog =>
                {
                    Click.On(dialog.YesButton);
                });

                Verify.Equals(window.IsRestricted, false);
            });
        }

        [Step("Complete summary tab")]
        public void CompleteSummaryTab()
        {
            Wait.For(this.GetWindow<DealNotebookWindow>(), window =>
            {
                Click.On(window.SummaryTab.Header);
                Enter.TextInto(window.SummaryTab.ProposedCmt, "10");
                Click.On(window.SummaryTab.AddButton);

                Wait.For(this.GetWindow<QuestionWindow>(), dialog =>
                {
                    Click.On(dialog.YesButton);
                }, WaitToFinish.YES);

                Wait.For(this.GetWindow<CommonSelectWindow>(), dialog =>
                {
                    Enter.TextInto(dialog.IdentifyBy, "borror2014");
                    Click.On(dialog.SearchButton);
                }, WaitToFinish.YES);

                Wait.For(this.GetWindow<CommonListByShortNameWindow>(), dialog =>
                {
                    Select.By(dialog.ShortNameList, 0);
                    Click.On(dialog.OkButton);
                }, WaitToFinish.YES);

                Wait.For(this.GetWindow<DealBorrowerDetailsWindow>(), dialog =>
                {
                    Click.On(dialog.OkButton);
                }, WaitToFinish.YES);

                Click.On(window.SummaryTab.DealClassificationButton);

                Wait.For(this.GetWindow<CommonSelectCodeWindow>(), dialog =>
                {
                    //Select.By(dialog.ClassificationTree, 1);
                    Enter.TextInto(dialog.SearchByCodeTextBox, "CPF");
                    Click.On(dialog.OkButton);
                }, WaitToFinish.YES);

                Click.On(window.SummaryTab.AdminAgentButton);

                Wait.For(this.GetWindow<QuestionWindow>(), dialog =>
                {
                    Click.On(dialog.YesButton);
                });

                Wait.For(this.GetWindow<DealAdminAgentWindow>(), childDialog =>
                {
                    Click.On(childDialog.CustomerButton);

                    Wait.For(this.GetWindow<CommonSelectWindow>(), dialogTwo =>
                    {
                        Enter.TextInto(dialogTwo.IdentifyBy, "BANK 1");
                        Click.On(dialogTwo.SearchButton);
                    }, WaitToFinish.YES);

                    Wait.For(this.GetWindow<CommonListByShortNameWindow>(), dialogTwo =>
                    {
                        Select.By(dialogTwo.ShortNameList, 0);
                        Click.On(dialogTwo.OkButton);
                    }, WaitToFinish.YES);

                    Click.On(childDialog.OkButton);

                }, WaitToFinish.YES);

                
            });
        }

        [Step("Complete personnel tab")]
        public void CompletePersonalTab()
        {
            Wait.For(this.GetWindow<DealNotebookWindow>(), window =>
            {
                Click.On(window.PersonnelTab.Header);

                Click.On(window.PersonnelTab.ExpenseCodeButton);
                Wait.For(this.GetWindow<DealSelectExpenseCodeWindow>(), dialog =>
                {
                    Click.On(dialog.AllExpenseCodesButton);
                });

                Wait.For(this.GetWindow<CommonSelectCodeWindow>(), dialog =>
                {
                    Enter.TextInto(dialog.SearchByCodeTextBox, "000001");
                    Click.On(dialog.OkButton);
                });

                Click.On(window.PersonnelTab.SaleGroupsButton);
                Wait.For(this.GetWindow<SalesGroupsSelectionListWindow>(), dialog =>
                {
                    Select.By(dialog.AvailableTree, 0);
                    Click.On(dialog.OkButton);
                });


            });

            
        }

        [Step("Add deal internal risk rating <riskRatingTable>")]
        public void AddDealInternalRiskRating(Table riskRatingTable)
        {
            Wait.For(this.GetWindow<DealNotebookWindow>(), window =>
            {
                Click.On(window.RiskOrRegulatoryTab.Header);
                Click.On(window.RiskOrRegulatoryTab.AddButton);

                Wait.For(this.GetWindow<WarningWindow>(), dialog =>
                {
                    Click.On(dialog.YesButton);
                });

            });

            Wait.For(this.GetWindow<DealInternalRiskRatingDetailsWindow>(), window =>
            {
                Select.By(window.RatingComboBox, riskRatingTable.FindValue("Rating"), VirtualKeyShort.ENTER);

                Wait.For(new[] { window.ValueComboBox }, ratings =>
                {
                    Select.By(window.ValueComboBox, riskRatingTable.FindValue("Value"), VirtualKeyShort.ENTER);

                    Enter.TextInto(window.EffectiveDatePicker, riskRatingTable.FindValue("Effective Date"));
                    Enter.TextInto(window.ExpirationDatePicker, riskRatingTable.FindValue("Expiration Date"));
                    Enter.TextInto(window.PercentageTextBox, riskRatingTable.FindValue("Percent"));
                    Click.On(window.OkButton);
                });
            });
        }

        [Step("Add comments")]
        public void AddComments()
        {
            Wait.For(this.GetWindow<DealNotebookWindow>(), window =>
            {
                Click.On(window.CommentsTab.Header);
            });
        }

        [Step("Add restrictions")]
        public void AddRestrictions()
        {
            Wait.For(this.GetWindow<DealNotebookWindow>(), window =>
            {
                Click.On(window.RestrictionsTab.Header);
                Enter.TextInto(window.RestrictionsTab.MaxNumberOfLoans, "3");
            });
        }

        [Step("Add MIS Codes")]
        public void AddMISCodes()
        {
            Wait.For(this.GetWindow<DealNotebookWindow>(), window =>
            {
                Click.On(window.MISCodesTab.Header);
            });
        }

        [Step("Add Additional")]
        public void AddAdditional()
        {
            Wait.For(this.GetWindow<DealNotebookWindow>(), window =>
            {
                Click.On(window.AdditionalTab.Header);
            });
        }

        [Step("Add Calendar <calendarName>")]
        public void AddCalendar(string calendarName)
        {
            Wait.For(this.GetWindow<DealNotebookWindow>(), window =>
            {
                Click.On(window.CalendarsTab.Header);
                Click.On(window.CalendarsTab.AddButton);
            });

            Wait.For(this.GetWindow<DealHolidayWindow>(), window =>
            {
                Select.By(window.CalendarComboBox, calendarName, VirtualKeyShort.ENTER);
                Click.On(window.OkButton);
            });
        }


        [Step("Add Ratios or Conditions")]
        public void AddRatiosOrConditions()
        {
            Wait.For(this.GetWindow<DealNotebookWindow>(), window =>
            {
                Click.On(window.RatiosOrConditionsTab.Header);
            });
        }

        [Step("Add Pricing Rules <pricingOptions>")]
        public void AddPricingRules(Table pricingOptions)
        {
            Wait.For(this.GetWindow<DealNotebookWindow>(), window =>
            {
                Click.On(window.PricingRulesTab.Header);
                Click.On(window.PricingRulesTab.AddOption);
            });

            Wait.For(this.GetWindow<DealInterestPricingOptionDetailsWindow>(), window =>
            {
                Select.By(window.AutomaticNotices, pricingOptions.FindValue("Rule"), VirtualKeyShort.ENTER);
                Select.By(window.CCY, pricingOptions.FindValue("CCY"));
                Select.By(window.InitialInfractionRate, pricingOptions.FindValue("Initial Infraction Rate"));
                Select.By(window.RoundedDecimalPrecision, pricingOptions.FindValue("Round Decimal Precision"));
                Select.By(window.NonBusinessDayRule, pricingOptions.FindValue("Non Business Day Rule"));
                Select.By(window.UtilizationImpact, pricingOptions.FindValue("Utilization Impact"));
                Click.On(window.OkButton);
            });
        }

        [Step("Pending deal <pendingDealTable>")]
        public void PendingDeal(Table pendingDealTable)
        {
            Wait.For(this.GetWindow<DealNotebookWindow>(), window =>
            {
                Click.On(window.OptionMenuItem);
                Click.On(window.Facilities);
            });

            Wait.For(this.GetWindow<FacilityNavigatorWindow>(), window =>
            {
                Click.On(window.AddButton);
            });

            Wait.For(this.GetWindow<DealFacilitySelectWindow>(), window =>
            {
                Enter.TextInto(window.FacilityName, pendingDealTable.FindValue("Facility Name"));
                Select.By(window.FacilityType, pendingDealTable.FindValue("Facility Type Select"));
                Enter.TextInto(window.ProposedCmtAmount, pendingDealTable.FindValue("Proposed Cmd Amount"));
                Enter.TextInto(window.AnsiId, StringHelpers.RandomString(pendingDealTable.FindValue("Ansi Id"), 5));
                Select.By(window.Currency, pendingDealTable.FindValue("Currency"));
                Click.On(window.OkButton);
            }, WaitToFinish.YES);
        }

        [Step("Facility summary <summaryTable>")]
        public void FacilitySummary(Table summaryTable)
        {
            Wait.For(this.GetWindow<FacilityWindow>(), window =>
            {
                Click.On(window.SummaryTab.Header);
                Enter.TextInto(window.SummaryTab.ProposedCmt, summaryTable.FindValue("Proposed Cmt"));
                Enter.TextInto(window.SummaryTab.ClosingCmt, summaryTable.FindValue("Closing Cmt"));
                Enter.TextInto(window.SummaryTab.Agreement, summaryTable.FindValue("Agreement"));
                Enter.TextInto(window.SummaryTab.Effective, summaryTable.FindValue("Effective"));
                Enter.TextInto(window.SummaryTab.Expiry, summaryTable.FindValue("Expiry"));
                Enter.TextInto(window.SummaryTab.FinalMaturity, summaryTable.FindValue("Final Maturity"));
            });
        }

        [Step("Types or Purposes <typesTable>")]
        public void TypesOrPurposes(Table typesTable)
        {
            Wait.For(this.GetWindow<FacilityWindow>(), window =>
            {
                Click.On(window.TypesOrPurposesTab.Header);
                Click.On(window.TypesOrPurposesTab.AddButton);

                Wait.For(this.GetWindow<WarningWindow>(), dialog =>
                {
                    Click.On(dialog.YesButton);
                });

                Wait.For(this.GetWindow<FacilityRiskTypeDetailsWindow>(), dialog =>
                {
                    Select.By(dialog.RiskType, typesTable.FindValue("Risk Type"), VirtualKeyShort.ENTER);
                    Enter.TextInto(dialog.Limit, typesTable.FindValue("Limit"));
                    Click.On(dialog.OkButton);
                });

                Click.On(window.TypesOrPurposesTab.LoanPurposeTypes);
            });

            Wait.For(this.GetWindow<FacilityLoanPurposeSelectWindow>(), window =>
            {
                Select.By(window.AvailableList, 2);
                Click.On(window.OkButton);
            });
        }

        [Step("Sublimit or cust")]
        public void SublimitOrCust()
        {
            Wait.For(this.GetWindow<FacilityWindow>(), window =>
            {
                Click.On(window.SublimitOrCustTab.Header);
                Click.On(window.SublimitOrCustTab.AddSublimit);

                Wait.For(this.GetWindow<FacilitySublimitDetailsWindow>(), dialog =>
                {
                    Enter.TextInto(dialog.Name, "Name");
                    Enter.TextInto(dialog.GlobalAmount, "5");
                    Select.By(dialog.Currency, "USD");
                    Click.On(dialog.ModifyRisk);


                    Wait.For(this.GetWindow<FacilityModifyRiskTypesSelectionWindow>(), childDialog =>
                    {
                        Select.By(childDialog.AvaibleList, "Deposits", VirtualKeyShort.SPACE);
                        Click.On(childDialog.OkButton);
                    });

                    Click.On(dialog.OkButton);
                });

                Click.On(window.SublimitOrCustTab.AddBorrowerOrDepositor);
            });

            Wait.For(this.GetWindow<WarningWindow>(), window =>
            {
                Click.On(window.YesButton);
            });

            Wait.For(this.GetWindow<DealBorrowerOrDepositorSelectWindow>(), window =>
            {
                Click.On(window.AddAllButton);
                Click.On(window.OkButton);
            });

            Wait.For(this.GetWindow<WarningWindow>(), window =>
            {
                Click.On(window.YesButton);
            });
        }

        [Step("Risk")]
        public void Risk()
        {
            Wait.For(this.GetWindow<FacilityWindow>(), window =>
            {
                Click.On(window.RiskTab.Header);
                Click.On(window.PricingTab.Header);
                Enter.TextInto(window.PricingTab.PastDueGraceDays, "6");
                Click.On(window.PricingTab.ModifyButton);

                Wait.For(this.GetWindow<WarningWindow>(), dialog =>
                {
                    Click.On(dialog.YesButton);
                });

                Wait.For(this.GetWindow<FacilityPenaltySpreadEditorWindow>(), dialog =>
                {
                    Enter.TextInto(dialog.PenaltySpread, "15.5");
                    Select.By(dialog.PenaltyStatus, "Waived");
                    Click.On(dialog.OkButton);
                });

                Click.On(window.PricingTab.ModifyInterestPricingButton);
            });

            Wait.For(this.GetWindow<FacilityInterestPricingWindow>(), window =>
            {
                Click.On(window.AddButton);

                Wait.For(this.GetWindow<FacilityInterestPricingAddItemWindow>(), dialog =>
                {
                    Select.By(dialog.Options, "Option", null);
                    Select.By(dialog.Type, "Libor Option");
                    Click.On(dialog.OkButton);
                });

                Wait.For(this.GetWindow<FacilityOptionConditionWindow>(), dialog =>
                {
                    Select.By(dialog.OptionName, "Libor Option");
                    Select.By(dialog.RateBasis, "Actual/360");
                    Click.On(dialog.OkButton);
                });

                Wait.For(this.GetWindow<FacilityFormulaCategoryWindow>(), dialog =>
                {
                    Click.On(dialog.Code);
                    Enter.TextInto(dialog.SpreadValue, "5");
                    Click.On(dialog.OkButton);
                });

                Click.On(window.OkButton);
            });
        }

        [Step("Create Primary")]
        public void CreatePrimary()
        {
            Wait.For(this.GetWindow<DealNotebookWindow>(), window =>
            {
                Click.On(window.DistributionMenuItem);
                Click.On(window.PrimariesMenuItem);
            });

            Close.This(this.GetWindow<DealNotebookWindow>());
            Close.This(this.GetWindow<FacilityWindow>());
            Close.This(this.GetWindow<FacilityNavigatorWindow>());

            Wait.For(this.GetWindow<PrimaryListWindow>(), window =>
            {
                Click.On(window.AddButton);

                Wait.For(this.GetWindow<PrimaryCreateWindow>(), dialog =>
                {
                    Click.On(dialog.LenderButton);

                    Wait.For(this.GetWindow<CommonSelectWindow>(), childDialog =>
                    {
                        Enter.TextInto(childDialog.IdentifyBy, "BANK 1");
                        Click.On(childDialog.SearchButton);
                    }, WaitToFinish.YES);

                    Wait.For(this.GetWindow<CommonListByShortNameWindow>(), childDialog =>
                    {
                        Select.By(childDialog.ShortNameList, 0);
                        Click.On(childDialog.OkButton);
                    }, WaitToFinish.YES);

                    Click.On(dialog.BroughtInByButton);

                    Wait.For(this.GetWindow<CommonSelectWindow>(), childDialog =>
                    {
                        Enter.TextInto(childDialog.IdentifyBy, "BANK 1");
                        Click.On(childDialog.SearchButton);
                    }, WaitToFinish.YES);

                    Wait.For(this.GetWindow<CommonListByShortNameWindow>(), childDialog =>
                    {
                        Select.By(childDialog.ShortNameList, 0);
                        Click.On(childDialog.OkButton);
                    }, WaitToFinish.YES);

                    Click.On(dialog.OkButton);
                });

                Wait.For(this.GetWindow<PrimaryPendingOrigWindow>(), dialog =>
                {
                    Click.On(dialog.Facilities.Header);
                    Enter.TextInto(dialog.SellAmount, "10");

                    //Click.On(dialog.AmountsOrDates.Header);

                    Click.On(dialog.Contacts.Header);
                    Click.On(dialog.Contacts.AddContactsButton);

                    Wait.For(this.GetWindow<ContactsCircleWindow>(), childDialog =>
                    {
                        Select.By(childDialog.AvailableList, 0);
                        Click.On(childDialog.OkButton);
                    });

                    Wait.For(this.GetWindow<ContactsSelectionWindow>(), childDialog =>
                    {
                        Click.On(childDialog.ExitButton);
                    });

                    Click.On(dialog.Codes.Header);
                    //Click.On(dialog.Maintenance);
                    //Click.On(dialog.PortfolioAllocations); // TODO:

                    Click.On(dialog.WorkflowTab.Header);
                    Select.By(dialog.WorkflowTab.WorkflowTree, 0, true);

                    Wait.For(this.GetWindow<WarningWindow>(), childDialog =>
                    {
                        Click.On(childDialog.YesButton);
                    });

                    Wait.For(this.GetWindow<PortfolioSetCircledOrLegalTradeDateWindow>(), childDialog =>
                    {
                        Click.On(childDialog.OkButton);
                    });
                });

                Close.This(this.GetWindow<PrimaryPendingOrigWindow>());

                //Click.On(window.ExitButton);
            });

            Close.This(this.GetWindow<PrimaryListWindow>());

            // OPEN DEAL HERE
            //Wait.For(this.GetWindow<DealNotebookWindow>(), window =>
            //{
            //    Click.On(window.WorkflowTab.Header);
            //    Select.By(window.WorkflowTab.WorkflowTree, 0);
            //});
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


            this.Container.Register<PendingPrimaryFacilitiesTabItem>();
            this.Container.Register<PrimaryAmountsOrDatesTabItem>();
            this.Container.Register<PendingPrimaryContactsTabItem>();
            this.Container.Register<PrimaryCodesTabItem>();

            this.LoadDependencyGroup(DependencyGroup.Deal);
            this.LoadDependencyGroup(DependencyGroup.Facility);

            // WINDOWS
            this.Container.Register<DealSelectWindow>(new PerContainerLifetime());
            this.Container.Register<DealNotebookWindow>();
            this.Container.Register<CommonSelectWindow>();
            this.Container.Register<BorrowerListWindow>(new PerContainerLifetime());
            this.Container.Register<SalesGroupsSelectionListWindow>(new PerContainerLifetime());
            this.Container.Register<DealInternalRiskRatingDetailsWindow>();
            this.Container.Register<DealHolidayWindow>();
            this.Container.Register<DealInterestPricingOptionDetailsWindow>();
            this.Container.Register<CommonListByShortNameWindow>();
            this.Container.Register<DealBorrowerDetailsWindow>();
            this.Container.Register<DealSelectExpenseCodeWindow>();


            this.Container.Register<PrimaryPendingOrigWindow>();
            this.Container.Register<ContactsCircleWindow>();
            this.Container.Register<ContactsSelectionWindow>();
            this.Container.Register<DealAdminAgentWindow>();
            this.Container.Register<PortfolioSetCircledOrLegalTradeDateWindow>();

            // FACTORIES
            this.Container.Register<WindowFactory<DealSelectWindow>>(new PerContainerLifetime());
            this.Container.Register<WindowFactory<DealNotebookWindow>>();
            this.Container.Register<WindowFactory<CommonSelectWindow>>();
            this.Container.Register<WindowFactory<BorrowerListWindow>>(new PerContainerLifetime());
            this.Container.Register<WindowFactory<SalesGroupsSelectionListWindow>>(new PerContainerLifetime());
            this.Container.Register<WindowFactory<DealInternalRiskRatingDetailsWindow>>();
            this.Container.Register<WindowFactory<DealHolidayWindow>>();
            this.Container.Register<WindowFactory<DealInterestPricingOptionDetailsWindow>>();

            this.Container.Register<WindowFactory<CommonListByShortNameWindow>>();
            this.Container.Register<WindowFactory<DealBorrowerDetailsWindow>>();


            this.Container.Register<WindowFactory<PrimaryPendingOrigWindow>>();
            this.Container.Register<WindowFactory<ContactsCircleWindow>>();
            this.Container.Register<WindowFactory<ContactsSelectionWindow>>();
            this.Container.Register<WindowFactory<DealAdminAgentWindow>>();
            this.Container.Register<WindowFactory<DealSelectExpenseCodeWindow>>();
            this.Container.Register<WindowFactory<PortfolioSetCircledOrLegalTradeDateWindow>>();
        }
    }
}
