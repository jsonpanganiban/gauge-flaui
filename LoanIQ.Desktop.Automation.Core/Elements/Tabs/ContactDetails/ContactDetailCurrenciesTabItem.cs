using DTAF.Core.Desktop.Contracts;
using FlaUI.Core.AutomationElements;

namespace LoanIQ.Desktop.Automation.Core.Elements.Tabs.ContactDetails
{
    public class ContactDetailCurrenciesTabItem : Element, IElement
    {
        public AutomationElement CurrenciesButton
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByName("Currencies..."));
            }
        }
    }
}
