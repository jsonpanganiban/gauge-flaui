using FlaUI.Core.AutomationElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanIQ.Desktop.Automation.Core.Elements.Tabs.CustomerContactListDetails
{
    public class AddressesTab : Element
    {
        public AutomationElement MailingAddressCodeComboBox
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByName("Mailing Address"))
                                    .FindFirstDescendant(d => d.ByControlType(FlaUI.Core.Definitions.ControlType.ComboBox));
            }

        }
    }
}
