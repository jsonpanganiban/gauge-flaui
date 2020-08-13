using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using Gauge.CSharp.Lib;

namespace LoanIQ.Desktop.Automation.Core.Elements.ContextMenus
{
    public class DefaultContextMenu : ContextMenuBase
    {
        public AutomationElement MenuItem(string menuItem)
        {
            return this.Context.FindFirstChild(c => c.ByName(menuItem).And(c.ByControlType(ControlType.MenuItem)));
        }

        public DefaultContextMenu(ApplicationHelper applicationHelper)
            : base(applicationHelper)
        {

        }
    }
}
