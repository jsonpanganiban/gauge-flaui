using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using System;
using FlaUI.Core.Definitions;
using DTAF.Core.Desktop.Contracts;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class DrawdownCostOfFundsInUSDWindow : WindowBase, IWindowElement
    {
        public AutomationElement RateTextBox
        {
            get
            {
                return this.Context.FindChildAt(1, c => c.ByControlType(ControlType.Edit));
            }
        }

        public AutomationElement TicketNumberTextBox
        {
            get
            {
                return this.Context.FindChildAt(2, c => c.ByControlType(ControlType.Edit));
            }
        }

        public AutomationElement SpreadTextBox
        {
            get
            {
                return this.Context.FindChildAt(3, c => c.ByControlType(ControlType.Edit));
            }
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

        public DrawdownCostOfFundsInUSDWindow(ApplicationHelper applicationHelper) 
            : base(applicationHelper)
        {
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                var window = ApplicationHelper.GetWindowByName("Cost Of Funds in USD");
                this.Context = window ?? throw new Exception();
                this.Context.SetForeground();
            }, this.ApplicationHelper.Config.WaitTimeout);
        }
    }
}
