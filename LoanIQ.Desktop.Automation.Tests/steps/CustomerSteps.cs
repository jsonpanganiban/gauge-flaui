using System.Linq;
using FluentAssertions;
using Gauge.CSharp.Lib;
using Gauge.CSharp.Lib.Attribute;
using LightInject;
using LoanIQ.Desktop.Automation.Core;
using LoanIQ.Desktop.Automation.Core.Elements.Tabs;
using LoanIQ.Desktop.Automation.Core.Elements.Tabs.ActiveCustomer;
using LoanIQ.Desktop.Automation.Core.Helpers;
using LoanIQ.Desktop.Automation.Core.Windows;
using LoaniqDesktopAutomationTests.steps;
using DTAF.Core.Desktop.Factories;
using DTAF.Core.Desktop.Actions;
using FlaUI.Core.AutomationElements;
using LoanIQ.Desktop.Automation.Core.Windows.Customer;
using LoanIQ.Desktop.Automation.Core.Elements.Tabs.ContactDetails;
using FlaUI.Core.WindowsAPI;

namespace LoaniqDesktopAutomationTests
{
    public class CustomerSteps : LoanIQStepBase
    {

        [Step("Login as <username> and password <password>")]
        public void Login(string username, string password)
        {
            var loginWindow = this.Container.GetInstance<WindowFactory<LoginWindow>>().Context;
            Click.On(loginWindow.UserNameTextBox);
            Enter.TextInto(loginWindow.UserNameTextBox, username);
            Enter.TextInto(loginWindow.PasswordTextBox, password);
            Click.On(loginWindow.SignInButton);
            var disclaimerWindow = this.Container.GetInstance<WindowFactory<DisclaimerWindow>>().Context;
            Click.On(disclaimerWindow.OkButton);
            var mainWindow = Container.GetInstance<WindowFactory<MainWindow>>().Context;
            mainWindow.Maximize();

        }

        [Step("Create New Alias <alias> and Select Type <type>")]
        public void CreateNewAlias(string alias, string type)
        {
            var activeCustomerWindow = this.Container.GetInstance<WindowFactory<ActiveCustomerWindow>>().Context;
            Click.On(activeCustomerWindow.GeneralTabItem);
            Click.On(activeCustomerWindow.GeneralTab.GenaralButton("Add"));
            var newAliasWIndow = this.Container.GetInstance<WindowFactory<NewAliasWindow>>().Context;
            Select.By(newAliasWIndow.AliasTypeCombobox, type, FlaUI.Core.WindowsAPI.VirtualKeyShort.ENTER);
            Enter.TextInto(newAliasWIndow.AliasTextBox, StringHelpers.GenerateNameWithSuffix(alias));
            Click.On(newAliasWIndow.AliasOkButton);
        }

        [Step("Select Expense Code <code>")]
        public void SelectExpenseCode(string code)
        {
            var activeCustomerWindow = this.Container.GetInstance<WindowFactory<ActiveCustomerWindow>>().Context;
            Click.On(activeCustomerWindow.GeneralTab.GenaralButton("Expense Code"));
            var expenseWindow = this.Container.GetInstance<WindowFactory<CommonSelectCodeWindow>>().Context;
            Enter.TextInto(expenseWindow.SearchByCodeTextBox, code);
            Click.On(expenseWindow.OkButton);
        }

        [Step("Select Department Code <code>")]
        public void SelectDeparmentCode(string code)
        {
            var activeCustomerWindow = this.Container.GetInstance<WindowFactory<ActiveCustomerWindow>>().Context;
            Click.On(activeCustomerWindow.GeneralTab.GenaralButton("Department"));
            var departmentWindow = this.Container.GetInstance<WindowFactory<CommonSelectCodeWindow>>().Context;
            Enter.TextInto(departmentWindow.SearchByCodeTextBox, code);
            Click.On(departmentWindow.OkButton);
        }

        [Step("Select Customer Classification Code <code>")]
        public void SelectCustomerClassificationCode(string code)
        {
            var activeCustomerWindow = this.Container.GetInstance<WindowFactory<ActiveCustomerWindow>>().Context;
            Click.On(activeCustomerWindow.GeneralTab.GenaralButton("Classification"));
            var customerWindow = this.Container.GetInstance<WindowFactory<CommonSelectCodeWindow>>().Context;
            Enter.TextInto(customerWindow.SearchByCodeTextBox, code);
            Click.On(customerWindow.OkButton);
        }

        [Step("Create customer <shortName> and <legalName>")]
        public void CreateNewCustomer(string shortName, string legalName)
        {
            var mainWindow = Container.GetInstance<WindowFactory<MainWindow>>().Context;
            Click.On(mainWindow.MenuButtonPane.Actions);
            DoubleClick.On(mainWindow.MenuButtonTreePane.FindTreeItem("Customer"));

            var customerSelectWindow = Container.GetInstance<WindowFactory<CustomerSelectWindow>>().Context;

            Click.On(customerSelectWindow.NewCustomerComboBox);
            Enter.TextInto(customerSelectWindow.CustomerShortNameTextBox, StringHelpers.GenerateNameWithSuffix(shortName));
            Enter.TextInto(customerSelectWindow.LegalNameDocumentBox, StringHelpers.GenerateNameWithSuffix(legalName));
            Click.On(customerSelectWindow.OKButton);

            var customerCreateWarning = Container.GetInstance<WindowFactory<WarningWindow>>().Context;
            Click.On(customerCreateWarning.YesButton);
        }

        [Step("Add a <profile> profile")]
        public void CreateNewAlias(string profile)
        {
            var activeCustomerWindow = this.Container.GetInstance<WindowFactory<ActiveCustomerWindow>>().Context;
            Click.On(activeCustomerWindow.ProfilesTabItem);
            Click.On(activeCustomerWindow.ProfileTab.AddProfileButton);
            var selectProfileWindow = this.Container.GetInstance<WindowFactory<SelectProfileWindow>>().Context;
            Select.By(selectProfileWindow.ProfileTree, 2, FlaUI.Core.WindowsAPI.VirtualKeyShort.ENTER);
            selectProfileWindow.ProfileTree.AsTree().SelectedTreeItem.Should().Be(selectProfileWindow.ProfileTree.FindChildAt(2));
            Click.On(selectProfileWindow.OkButton);

            var borrowerProfileDetails = Container.GetInstance<WindowFactory<CustomerBorrowerProfileDetailsWindow>>().Context;
            Click.On(borrowerProfileDetails.GenaralButton("OK"));
        }

        [Step("Add customer location <locationCode>")]
        public void AddCustomerLocation(string locationCode)
        {
            var activeCustomerWindow = Container.GetInstance<WindowFactory<ActiveCustomerWindow>>().Context;
            Click.On(activeCustomerWindow.ProfilesTabItem);
            Click.On(activeCustomerWindow.GenaralButton("Add Location"));

            var selectLocation = Container.GetInstance<WindowFactory<CommonSelectCodeWindow>>().Context;
            Click.On(selectLocation.SearchSortByCodeRadioButton);
            Enter.TextInto(selectLocation.SearchByCodeTextBox, locationCode);
            Click.On(selectLocation.OkButton);

            var borrowerDetails = Container.GetInstance<WindowFactory<CustomerBorrowerLocationDetailsWindow>>().Context;
            Enter.TextInto(borrowerDetails.ExternalIdTextBox, StringHelpers.RandomDigits(9));
            //Enter.TextInto(borrowerDetails.FirstTransactionDateTextBox, DateTime.Now.ToShortDateString());
            //Enter.TextInto(borrowerDetails.LastTransactionDateTextBox, DateTime.Now.AddDays(4).ToShortDateString());
            Enter.TextInto(borrowerDetails.TaxPayerIdTextBox, StringHelpers.RandomDigits(9));
            Select.By(borrowerDetails.PreferredLanguageComboBox, "English");
            Click.On(borrowerDetails.GenaralButton("OK"));
        }

        [Step("Select Primary SIC <code>")]
        public void SelectPrimarySic(string code)
        {
            var activeCustomerWindow = this.Container.GetInstance<WindowFactory<ActiveCustomerWindow>>().Context;
            Click.On(activeCustomerWindow.SICTabItem);
            Click.On(activeCustomerWindow.GenaralButton("Primary SIC..."));
            var sicWindow = Container.GetInstance<WindowFactory<SicSelectWindow>>().Context;
            Enter.TextInto(sicWindow.CodeTextBox, code, true);
            Click.On(sicWindow.OkButton);
        }

        [Step("Verify <shortname> is present in Immediate, Ultimate and Trading Parent")]
        public void VerifyShortnameInGeneralTab(string shortName)
        {
            //var activeCustomerWindow = this.Container.GetInstance<WindowFactory<ActiveCustomerWindow>>().Context;
            //activeCustomerWindow.CorporateTab.ImmediateParentTextBox.Should().Be(shortName);
        }

        [Step("Add Internal Risk Rating <riskTable>")]
        public void AddIternalRiskRating(Table riskTable)
        {
            var activeCustomerWindow = Container.GetInstance<WindowFactory<ActiveCustomerWindow>>().Context;
            Click.On(activeCustomerWindow.RiskTabItem, true);
            Click.On(activeCustomerWindow.GenaralButton("Add Internal"));
            var alertMessage = Container.GetInstance<WindowFactory<WarningWindow>>().Context;
            Click.On(alertMessage.YesButton);

            var internalRisk = this.Container.GetInstance<WindowFactory<CustomerInternalRiskRating>>().Context;
            var values = riskTable.GetTableRows().Select(x => x.GetCell("Value")).ToList();
            Select.By(internalRisk.RatingTypeComboBox, values[0], VirtualKeyShort.ENTER);
            Enter.TextInto(internalRisk.RatingTextBox, values[1]);
            Enter.TextInto(internalRisk.PercentTextbox, values[2], VirtualKeyShort.TAB);
            Enter.TextInto(internalRisk.EffectiveDateTextBox, values[3], VirtualKeyShort.TAB);
            Enter.TextInto(internalRisk.ExpiryDateTextBox, values[4], VirtualKeyShort.TAB);
            Click.On(internalRisk.OkButton);
        }

        [Step("Add External Risk Rating <riskTable>")]
        public void AddExternalRiskRating(Table riskTable)
        {
            var activeCustomerWindow = this.Container.GetInstance<WindowFactory<ActiveCustomerWindow>>().Context;
            Click.On(activeCustomerWindow.RiskTabItem, true);
            Click.On(activeCustomerWindow.GenaralButton("Delete External"));
            var alertMessage = Container.GetInstance<WindowFactory<WarningWindow>>().Context;
            Click.On(alertMessage.YesButton);
            Click.On(activeCustomerWindow.GenaralButton("Add External"));

            var exterternalRisk = this.Container.GetInstance<WindowFactory<CustomerExternalRiskRating>>().Context;
            var values = riskTable.GetTableRows().Select(x => x.GetCell("Value")).ToList();
            Select.By(exterternalRisk.RatingTypeComboBox, values[0], VirtualKeyShort.ENTER);
            Enter.TextInto(exterternalRisk.RatingTextBox, values[1]);
            //Enter.TextInto(exterternalRisk.StartDateTextBox, values[2]);
            Click.On(exterternalRisk.OkButton);
        }

        [Step("Update Address <addressTable>")]
        public void UpdateAddress(Table addressTable)
        {
            var activeCustomerWindow = Container.GetInstance<WindowFactory<ActiveCustomerWindow>>().Context;
            Click.On(activeCustomerWindow.ProfilesTabItem);
            Click.On(activeCustomerWindow.GenaralButton("Addresses"));

            var addressListWindow = Container.GetInstance<WindowFactory<AddressListWindow>>().Context;
            Click.On(addressListWindow.AddButton);

            var updateAddressWindow = Container.GetInstance<WindowFactory<UpdateAddressWindow>>().Context;
            var values = addressTable.GetTableRows().Select(x => x.GetCell("Value")).ToList();
            Enter.TextInto(updateAddressWindow.AddressCode, values[0]);
            Enter.TextInto(updateAddressWindow.Line1, values[1]);
            Enter.TextInto(updateAddressWindow.Line2, values[2]);
            Enter.TextInto(updateAddressWindow.City, values[3]);
            Select.By(updateAddressWindow.Country, values[4]);
            Enter.TextInto(updateAddressWindow.DefaultPhoneNumber, values[5]);
            Enter.TextInto(updateAddressWindow.ZipPostalCode, values[6]);
            Click.On(updateAddressWindow.OkButton);

            Click.On(addressListWindow.GenaralButton("Exit"));
        }

        [Step("Add contact general tab <firstName> <lastName>")]
        public void AddContact(string firstName, string lastName)
        {
            var activeCustomerWindow = Container.GetInstance<WindowFactory<ActiveCustomerWindow>>().Context;
            Click.On(activeCustomerWindow.ProfilesTabItem);
            Click.On(activeCustomerWindow.GenaralButton("Contacts"));

            var contactListWindow = this.Container.GetInstance<WindowFactory<CustomerContactListWindow>>().Context;
            Click.On(contactListWindow.GenaralButton("Add"));

            var contactDetail = Container.GetInstance<WindowFactory<CustomerContactListDetailWindow>>().Context;

            Click.On(contactDetail.GeneralTabButton);
            Enter.TextInto(contactDetail.GeneralTab.FirstNameTextBox, firstName);
            Enter.TextInto(contactDetail.GeneralTab.LastNameTextBox, lastName);
            Select.By(contactDetail.GeneralTab.PreferredLanguageComboBox, "English", FlaUI.Core.WindowsAPI.VirtualKeyShort.ENTER);
            Enter.TextInto(contactDetail.GeneralTab.PrimaryPhoneTextBox, "123-2223-111");
            Enter.TextInto(contactDetail.GeneralTab.DepartmentTextBox, "Loan Department");
            Click.On(contactDetail.GeneralTab.LoanCheckBox);
            Click.On(contactDetail.GeneralTab.PrincipalCheckBox);
            Click.On(contactDetail.GeneralTab.AddPurposesButton);

            var purposeSelection = Container.GetInstance<WindowFactory<CustomerContactPurposeSelectionList>>().Context;
            Enter.TextInto(purposeSelection.SearchPurposeTextBox, "Borrower");
            //Enter.TextInto(purposeSelection.SearchPurposeTextBox, "Borrower");
            Click.On(purposeSelection.GenaralButton("OK"));

            Click.On(contactDetail.GeneralTab.GenaralButton("Add"));

            var contactMethods = Container.GetInstance<WindowFactory<CustomerContactNoticeMethodSelectionWindow>>().Context;
            Select.By(contactMethods.MethodsComboBox, "Email", VirtualKeyShort.ENTER);
            Enter.TextInto(contactMethods.EmailDocumentBox, "testemail@digibpl.com");
            Click.On(contactMethods.GenaralButton("OK"));

            Click.On(contactDetail.AdressesTabButton);

            //currencies
            //Click.On(contactDetail.CurrencyTabButton);
            //Click.On(contactDetail.CurrencyTab.CurrenciesButton);

            //var currencies = this.Container.GetInstance<WindowFactory<CustomerContactPurposeSelectionList>>().Context;

            //Enter.TextInto(currencies.SearchPurposeTextBox, "Philippine", VirtualKeyShort.ENTER);
            //Click.On(currencies.GenaralButton("OK"));
        }

        [Step("Add contact address tab <addressTable>")]
        public void AddProfileTabContactAddress(Table addressTable)
        {
            var contactDetail = Container.GetInstance<WindowFactory<CustomerContactListDetailWindow>>().Context;

            Select.By(contactDetail.AddressesTab.MailingAddressCodeComboBox, 1, VirtualKeyShort.ENTER);
            Click.On(contactDetail.CurrencyTabButton);
        }

        [Step("Add contact currency tab <currency>")]
        public void AddProfileTabContactCurrency(string currency)
        {
            var contactDetail = Container.GetInstance<WindowFactory<CustomerContactListDetailWindow>>().Context;

            Click.On(contactDetail.CurrencyTab.CurrenciesButton);

            var currencies = this.Container.GetInstance<WindowFactory<CustomerContactPurposeSelectionList>>().Context;

            Enter.TextInto(currencies.SearchPurposeTextBox, currency, true);
            Click.On(currencies.GenaralButton("OK"));
            //Click.On(contactDetail.WindowClose);
        }

        [Step("Add customer remittance")]
        public void AddCustomerRemittance()
        {
            var activeCustomerWindow = Container.GetInstance<WindowFactory<ActiveCustomerWindow>>().Context;

            Click.On(activeCustomerWindow.GenaralButton("Remittance Instructions"));

            var remittancePopup = Container.GetInstance<WindowFactory<CustomerAddRemittanceInstructionPopup>>().Context;
            Click.On(remittancePopup.StandardRemittanceRadioButton, true);
            Click.On(remittancePopup.GenaralButton("OK"), true);

            var remitInstructions = Container.GetInstance<WindowFactory<CustomerRemittanceInstructionsDetailWindow>>().Context;

            Select.By(remitInstructions.MethodComboBox, 1, VirtualKeyShort.ENTER);
            Enter.TextInto(remitInstructions.MethodDescriptionTextBox, "Test Description");
            Click.On(remitInstructions.AllLoanTypesCheckBox, true);
            Click.On(remitInstructions.SBLC_BACheckBox, true);
            Click.On(remitInstructions.ToCustCheckBox, true);
            Click.On(remitInstructions.PrincipalCheckBox, true);
            Click.On(remitInstructions.InterestCheckBox, true);
            Click.On(remitInstructions.FeesCheckBox, true);
            Enter.TextInto(remitInstructions.AccountNameTextBox, StringHelpers.GenerateNameWithSuffix("AccountNameAuto"), true);
        }

        protected override void Register()
        {
            base.Register();

            // ELEMENTS
            this.Container.Register<GeneralTab>(new PerContainerLifetime());
            this.Container.Register<RiskTabItem>(new PerContainerLifetime());
            this.Container.Register<CorporateTab>(new PerContainerLifetime());
            this.Container.Register<ProfileTabItem>(new PerContainerLifetime());
            this.Container.Register<SicTabItem>(new PerContainerLifetime());
            this.Container.Register<ContactDetailGeneralTabItem>(new PerContainerLifetime());
            this.Container.Register<ContactDetailCurrenciesTabItem>(new PerContainerLifetime());
            this.Container.Register<ContactDetailAddressesTabItem>(new PerContainerLifetime());

            // windows/screens
            this.Container.Register<ActiveCustomerWindow>(new PerContainerLifetime());
            this.Container.Register<NewAliasWindow>(new PerContainerLifetime());
            this.Container.Register<SicSelectWindow>(new PerContainerLifetime());
            this.Container.Register<CustomerSelectWindow>(new PerContainerLifetime());
            //this.Container.Register<CommonSelectionPopupWindow>();
            this.Container.Register<SelectProfileWindow>();
            this.Container.Register<CustomerInternalRiskRating>(new PerContainerLifetime());
            this.Container.Register<AddressListWindow>(new PerContainerLifetime());
            this.Container.Register<UpdateAddressWindow>();
            this.Container.Register<CustomerBorrowerProfileDetailsWindow>(new PerContainerLifetime());
            this.Container.Register<CustomerExternalRiskRating>(new PerContainerLifetime());
            this.Container.Register<CustomerBorrowerLocationDetailsWindow>(new PerContainerLifetime());
            this.Container.Register<CustomerContactListWindow>(new PerContainerLifetime());
            this.Container.Register<CustomerContactListDetailWindow>();
            this.Container.Register<CustomerContactPurposeSelectionList>();
            this.Container.Register<CustomerContactNoticeMethodSelectionWindow>(new PerContainerLifetime());
            this.Container.Register<CustomerContactAddressListForWindow>(new PerContainerLifetime());
            this.Container.Register<CustomerAddRemittanceInstructionPopup>(new PerContainerLifetime());
            this.Container.Register<CustomerRemittanceInstructionsDetailWindow>(new PerContainerLifetime());

            // factory
            this.Container.Register<WindowFactory<ActiveCustomerWindow>>(new PerContainerLifetime());
            this.Container.Register<WindowFactory<NewAliasWindow>>(new PerContainerLifetime());
            this.Container.Register<WindowFactory<SicSelectWindow>>(new PerContainerLifetime());
            this.Container.Register<WindowFactory<CustomerSelectWindow>>(new PerContainerLifetime());
            this.Container.Register<WindowFactory<CustomerInternalRiskRating>>(new PerContainerLifetime());
            //this.Container.Register<WindowFactory<CommonSelectionPopupWindow>>();
            this.Container.Register<WindowFactory<SelectProfileWindow>>();
            this.Container.Register<WindowFactory<AddressListWindow>>(new PerContainerLifetime());
            this.Container.Register<WindowFactory<UpdateAddressWindow>>();
            this.Container.Register<WindowFactory<CustomerBorrowerProfileDetailsWindow>>(new PerContainerLifetime());
            this.Container.Register<WindowFactory<CustomerExternalRiskRating>>(new PerContainerLifetime());
            this.Container.Register<WindowFactory<CustomerBorrowerLocationDetailsWindow>>(new PerContainerLifetime());
            this.Container.Register<WindowFactory<CustomerContactListWindow>>(new PerContainerLifetime());
            this.Container.Register<WindowFactory<CustomerContactListDetailWindow>>();
            this.Container.Register<WindowFactory<CustomerContactPurposeSelectionList>>();
            this.Container.Register<WindowFactory<CustomerContactNoticeMethodSelectionWindow>>(new PerContainerLifetime());
            this.Container.Register<WindowFactory<CustomerContactAddressListForWindow>>(new PerContainerLifetime());
            this.Container.Register<WindowFactory<CustomerAddRemittanceInstructionPopup>>(new PerContainerLifetime());
            this.Container.Register<WindowFactory<CustomerRemittanceInstructionsDetailWindow>>(new PerContainerLifetime());
        }

        #region private methods

        private void UpdateCustomerAddress(Table addressTable)
        {
            var updateAddressWindow = Container.GetInstance<WindowFactory<UpdateAddressWindow>>().Context;
            var values = addressTable.GetTableRows().Select(x => x.GetCell("Value")).ToList();
            Enter.TextInto(updateAddressWindow.AddressCode, values[0]);
            Enter.TextInto(updateAddressWindow.Line1, values[1]);
            Enter.TextInto(updateAddressWindow.Line2, values[2]);
            Enter.TextInto(updateAddressWindow.City, values[3]);
            Select.By(updateAddressWindow.Country, values[4], FlaUI.Core.WindowsAPI.VirtualKeyShort.ENTER);
            Enter.TextInto(updateAddressWindow.DefaultPhoneNumber, values[5]);
            Enter.TextInto(updateAddressWindow.ZipPostalCode, values[6]);
            Click.On(updateAddressWindow.OkButton);
        }
        #endregion
    }
}
