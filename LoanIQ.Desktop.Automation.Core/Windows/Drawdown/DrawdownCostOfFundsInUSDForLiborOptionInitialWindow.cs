using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using System;
using FlaUI.Core.Definitions;
using DTAF.Core.Desktop.Contracts;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class DrawdownCostOfFundsInUSDForLiborOptionInitialWindow : WindowBase, IWindowElement
    {

        public AutomationElement RowItem(int rowNumber)
        {
            return this.Context.FindFirstDescendant(d => d.ByControlType(ControlType.Tree))
                .FindChildAt(rowNumber - 1, c => c.ByControlType(ControlType.TreeItem));
        }

        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindFirstChild(c => c.ByControlType(ControlType.Button).And(c.ByName("OK")));
            }
        }

        public AutomationElement CancelButton
        {
            get
            {
                return this.Context.FindFirstChild(c => c.ByControlType(ControlType.Button).And(c.ByName("Cancel")));
            }
        }

        public DrawdownCostOfFundsInUSDForLiborOptionInitialWindow(ApplicationHelper applicationHelper) 
            : base(applicationHelper)
        {
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                var window = ApplicationHelper.GetWindowWithNameContaining("Cost Of Funds in USD for Libor Option Initial Drawdow");
                this.Context = window ?? throw new Exception();
                this.Context.SetForeground();
            }, this.ApplicationHelper.Config.WaitTimeout);
        }
    }
}
