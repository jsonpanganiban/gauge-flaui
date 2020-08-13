using System;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using LoanIQ.Desktop.Automation.Core.Elements.Tabs.ContactDetails;
using LoanIQ.Desktop.Automation.Core.Elements.Tabs.CustomerContactListDetails;
using System;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class CustomerContactListDetailWindow : WindowBase, IWindowElement
    {
        private const string WINDOW_EXPRESSION = @"(Contact Detail\s-\s)([\w\s]*)-\s,\s";

        public CustomerContactListDetailWindow(ApplicationHelper applicationHelper,
                                               ContactDetailGeneralTabItem generalTab,
                                               ContactDetailCurrenciesTabItem currenciesTab,
                                               ContactDetailAddressesTabItem addressTab) : base(applicationHelper)
        {

            GeneralTab = generalTab;
            AddressesTab = addressTab;
            CurrencyTab = currenciesTab;

            GeneralTab.Context = Context.FindFirstChild();
            AddressesTab.Context = Context.FindFirstChild();
            CurrencyTab.Context = Context.FindFirstChild();
        }

        public ContactDetailAddressesTabItem AddressesTab { get; private set; }
        public ContactDetailGeneralTabItem GeneralTab { get; set; }
        public ContactDetailCurrenciesTabItem CurrencyTab { get; set; }


        public AutomationElement GeneralTabButton
        {
            get
            {
                return Context.FindFirstDescendant(_ => _.ByName("General"));
            }
        }

        public AutomationElement AdressesTabButton
        {
            get
            {
                return Context.FindFirstDescendant(_ => _.ByName("Addresses"));
            }
        }

        public AutomationElement CurrencyTabButton
        {
            get
            {
                return Context.FindFirstDescendant(_ => _.ByName("Currencies"));
            }
        }

        public AutomationElement WindowClose
        {
            get
            {
                return Context.FindFirstChild().FindFirstDescendant(_ => _.ByName("Close").And(_.ByControlType(FlaUI.Core.Definitions.ControlType.Button)));
            }
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                var custContactList = ApplicationHelper.GetWindowWithNameContaining("Contact Detail");
                Context = custContactList.FindFirstChild() ?? throw new Exception();
                Context.SetForeground();
            }, ApplicationHelper.Config.WaitTimeout);
        }
    }
}
