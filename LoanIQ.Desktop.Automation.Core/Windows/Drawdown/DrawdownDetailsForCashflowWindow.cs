using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using System;
using FlaUI.Core.Definitions;
using DTAF.Core.Desktop.Contracts;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class DrawdownDetailsForCashflowWindow : WindowBase, IWindowElement
    {
        protected AutomationElement RemittanceInstructionDetailGroup { get; private set; }

        public AutomationElement SelectRemittanceInstructions
        {
            get
            {
                return this.RemittanceInstructionDetailGroup.FindFirstChild(c => c.ByName("Select Remittance Instructions").
                And(c.ByControlType(ControlType.Button)));
            }        
        }

        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindFirstChild(d => d.ByName("OK").And(d.ByControlType(ControlType.Button)));
            }
        }

        public AutomationElement CancelButton
        {
            get
            {
                return this.Context.FindFirstChild(d => d.ByName("Cancel").And(d.ByControlType(ControlType.Button)));
            }
        }

        public DrawdownDetailsForCashflowWindow(ApplicationHelper applicationHelper) : base(applicationHelper)
        {
            this.RemittanceInstructionDetailGroup = this.Context.FindFirstChild(c => c.ByControlType(ControlType.Group)
                                    .And(c.ByName("Remittance Instruction Detail")));
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                var window = ApplicationHelper.GetWindowWithNameContaining("Details for Cashflow to");
                this.Context = window ?? throw new Exception();
                this.Context.SetForeground();
            }, this.ApplicationHelper.Config.WaitTimeout);
        }
    }
}
