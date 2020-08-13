using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;

namespace LoanIQ.Desktop.Automation.Core.Elements.Tabs
{
    public abstract class TabItemBase : ElementBase
    {
        private string _headerName;

        public TabItemBase(string headerName)
        {
            this._headerName = headerName;
        }

        public AutomationElement Header
        {
            get
            {
                return this.Context.Parent.FindFirstChild(c => c.ByControlType(ControlType.TabItem).And(c.ByName(_headerName)));
            }
        }
    }
}
