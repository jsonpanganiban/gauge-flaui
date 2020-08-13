using DTAF.Core.Desktop.Contracts;
using FlaUI.Core.AutomationElements;

namespace LoanIQ.Desktop.Automation.Core.Elements.Tabs.ContactDetails
{
    public class ContactDetailAddressesTabItem : Element, IElement
    {
        public AutomationElement MailingAddressCodeComboBox
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByName("Mailing Address"))
                                    .FindFirstDescendant(d => d.ByControlType(FlaUI.Core.Definitions.ControlType.ComboBox));
            }

        }

        public AutomationElement AddAddressButton
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByName("Add Address")
                                                              .And(_.ByControlType(FlaUI.Core.Definitions.ControlType.Button)));
            }
        }
    }
}
