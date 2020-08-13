using DTAF.Core.Desktop.Contracts;
using FlaUI.Core.AutomationElements;
using System.Linq;

namespace LoanIQ.Desktop.Automation.Core.Elements
{
    public class MenuButtonTreePane : ElementBase, IElement
    {
        public AutomationElement CustomerTreeItem
        {
            get
            {

                return Context.FindFirstChild().FindAllChildren(_ => _.ByControlType(FlaUI.Core.Definitions.ControlType.TreeItem))
                                             .Select(xxx => xxx.FindFirstChild(zz => zz.ByName("Customer"))).First();
            }
        }

        public AutomationElement FindTreeItem(string treeItemName)
        {

            return Context.FindFirstChild().FindAllChildren(_ => _.ByControlType(FlaUI.Core.Definitions.ControlType.TreeItem))
                                             .Select(xxx => xxx.FindFirstChild(zz => zz.ByName(treeItemName))).First();
        }
    }
}
