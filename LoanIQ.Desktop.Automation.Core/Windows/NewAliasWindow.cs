using System;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class NewAliasWindow : WindowBase, IWindowElement
    {
        public NewAliasWindow(ApplicationHelper applicationHelper) : base(applicationHelper)
        {
        }

        public AutomationElement AliasTextBox
        {
            get
            {
                return this.Context.FindFirstDescendant(x => x.ByControlType(FlaUI.Core.Definitions.ControlType.Edit));
            }
        }

        public AutomationElement AliasTypeCombobox
        {
            get
            {
                return this.Context.FindFirstDescendant(x => x.ByControlType(FlaUI.Core.Definitions.ControlType.ComboBox));
            }
        }

        public AutomationElement AliasOkButton
        {
            get
            {
                return this.Context.FindFirstDescendant(x => x.ByName("OK"));
            }
        }
        public AutomationElement AliasCancelButton
        {
            get
            {
                return this.Context.FindFirstDescendant(x => x.ByName("Cancel"));
            }
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = this.ApplicationHelper.GetWindowByName("New Alias") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
