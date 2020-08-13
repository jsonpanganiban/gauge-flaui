using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using System;
using FlaUI.Core.Definitions;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class DrawdownHolidaryCalendarWindow : WindowBase
    {

        public AutomationElement CalendarComboBox
        {
            get
            {
                return this.Context.FindFirstChild(c => c.ByControlType(ControlType.ComboBox));
            }
        }

        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindFirstChild(c => c.ByName("OK").And(c.ByControlType(ControlType.Button)));
            }
        }

        public DrawdownHolidaryCalendarWindow(ApplicationHelper applicationHelper) : base(applicationHelper)
        {
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                var window = ApplicationHelper.GetWindowByName("Holiday Calendar");
                this.Context = window ?? throw new Exception();
                this.Context.SetForeground();
            }, this.ApplicationHelper.Config.WaitTimeout);
        }
    }
}
