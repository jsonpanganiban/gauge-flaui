using System;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class CustomerContactNoticeMethodSelectionWindow : WindowBase, IWindowElement
    {
        public CustomerContactNoticeMethodSelectionWindow(ApplicationHelper applicationHelper)
            : base(applicationHelper)
        {
        }

        public AutomationElement PreferredCheckBox
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByName("Preferred")
                                    .And(_.ByControlType(FlaUI.Core.Definitions.ControlType.CheckBox)));
            }
        }

        public AutomationElement MethodsComboBox
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByControlType(FlaUI.Core.Definitions.ControlType.ComboBox));
            }
        }

        public AutomationElement EmailDocumentBox
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByName("E-mail:")
                                                              .And(_.ByControlType(FlaUI.Core.Definitions.ControlType.Document)));
            }
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = this.ApplicationHelper.GetWindowByName("Contact Notice Method(s) Selection") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
