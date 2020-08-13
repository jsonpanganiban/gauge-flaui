using DTAF.Core.Desktop.Contracts;
using FlaUI.Core.AutomationElements;

namespace LoanIQ.Desktop.Automation.Core.Elements.Tabs.Facility
{
    public class FacilityTypesOrPurposeTabItem : TabItemBase, IElement
    {
        public AutomationElement AddButton
        {
            get
            {
                return this.Context.Parent.FindFirstDescendant(d => d.ByName("Add..."));
            }
        }

        public AutomationElement LoanPurposeTypes
        {
            get
            {
                return this.Context.Parent.FindFirstDescendant(d => d.ByName("Loan Purpose Types"));
            }
        }

        public FacilityTypesOrPurposeTabItem()
            : base("Types/Purpose")
        {

        }
    }
}
