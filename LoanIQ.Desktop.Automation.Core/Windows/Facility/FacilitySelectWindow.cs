using System;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.Tools;
using FlaUI.Core.Definitions;
using FlaUI.Core.AutomationElements;
using DTAF.Core.Desktop.Contracts;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class FacilitySelectWindow : WindowBase, IWindowElement
    {
        public FacilitySelectWindow(ApplicationHelper applicationHelper)
            : base(applicationHelper)
        {
        }

        public AutomationElement DealTextBox
        {
            get
            {
                return this.Context.FindAllChildren(x => x.ByControlType(ControlType.Edit))[0];
            }
        }

        public AutomationElement NameTextBox
        {
            get
            {
                return this.Context.FindAllChildren(x => x.ByControlType(ControlType.Edit))[1];
            }
        }

        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindFirstDescendant(x => x.ByName("OK").And(x.ByControlType(ControlType.Button)));
            }
        }

        public AutomationElement SearchButton
        {
            get
            {
                return this.Context.FindFirstDescendant(x => x.ByName("Search").And(x.ByControlType(ControlType.Button)));
            }
        }

        public AutomationElement CloseWindowButton
        {
            get
            {
                return this.Context.FindFirstDescendant(x => x.ByName("Close").And(x.ByControlType(ControlType.Button)));
            }
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = ApplicationHelper.GetWindowByName("Facility Select") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
