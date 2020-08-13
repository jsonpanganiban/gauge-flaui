using System;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Tools;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class SalesGroupsSelectionListWindow : WindowBase, IWindowElement
    {
        public AutomationElement AvailableTree
        {
            get
            {
                return this.Context.FindChildAt(3).FindChildAt(1).FindFirstChild(c => c.ByControlType(ControlType.Tree));
            }
        }

        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindFirstDescendant(d => d.ByName("OK").And(d.ByControlType(ControlType.Button)));
            }
        }

        public SalesGroupsSelectionListWindow(ApplicationHelper applicationHelper) : 
            base(applicationHelper)
        {

        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = ApplicationHelper.GetDialogByName("Sales Groups Selection List") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
