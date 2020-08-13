using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Tools;
using System;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class CommonSelectCodeWindow : WindowBase, IWindowElement
    {
        public CommonSelectCodeWindow(ApplicationHelper applicationHelper) 
            : base(applicationHelper)
        {
        }

        public AutomationElement OkButton
        {
            get
            {
                return Context.FindFirstDescendant(x => x.ByName("OK"));
            }
        }

        public AutomationElement SearchByCodeTextBox
        {
            get
            {
                return Context.FindFirstDescendant(x => x.ByName("Search/Sort By:").And(x.ByControlType(ControlType.Edit)));
            }
        }

        public AutomationElement SearchSortByCodeRadioButton
        {
            get
            {
                return Context.FindFirstDescendant(x => x.ByName("Code"));
            }
        }

        public AutomationElement SearchSortByDescriptionRadioButton
        {
            get
            {
                return Context.FindFirstDescendant(x => x.ByName("Description"));
            }
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                Context = ApplicationHelper.GetWindowsByNames(new[] { "Select Customer Classification",
                                                                                       "Select Department Code",
                                                                                       "Select Expense Code",
                                                                                       "Select Location",
                                                                                       "Deal Classification"
                }) ?? throw new Exception();
            }, ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
