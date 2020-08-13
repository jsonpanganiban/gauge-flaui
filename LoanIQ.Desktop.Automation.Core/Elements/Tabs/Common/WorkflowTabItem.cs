using DTAF.Core.Desktop.Contracts;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;

namespace LoanIQ.Desktop.Automation.Core.Elements.Tabs.Common
{
    public class WorkflowTabItem : TabItemBase, IElement
    {
        public AutomationElement WorkflowTree
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByControlType(ControlType.Tree));
            }
        }

        public WorkflowTabItem()
            : base("Workflow")
        {

        }
    }
}
