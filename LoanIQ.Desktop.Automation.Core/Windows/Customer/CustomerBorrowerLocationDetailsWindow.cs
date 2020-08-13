using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using System;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class CustomerBorrowerLocationDetailsWindow : WindowBase, IWindowElement
    {
        private const string WindowName_Regex = @"Borrower\/\w+(,\s)?\w*\s\Details";

        const int _firstTransactionDateIndex = 5;
        const int _lastTransactionDateIndex = 6;
        const int _taxPayerIdIndex = 17;
        const int _preferredLanguageIndex = 2;

        // not numeric
        // lenght 9-15
        public AutomationElement ExternalIdTextBox
        {
            get
            {
                return Context.FindFirstChild();
            }
        }

        // numeric
        // 9 chars
        public AutomationElement TaxPayerIdTextBox
        {
            get
            {
                return Context.FindChildAt(_taxPayerIdIndex);
            }
        }

        public AutomationElement PreferredLanguageComboBox
        {
            get
            {
                return Context.FindChildAt(_preferredLanguageIndex);
            }
        }

        public AutomationElement CompleteCheckBox
        {
            get
            {
                return Context.FindFirstDescendant(_ => _.ByName("Complete").And(_.ByLocalizedControlType("check box")));
            }
        }


        public AutomationElement FirstTransactionDateTextBox
        {
            get
            {
                return Context.FindChildAt(_firstTransactionDateIndex);
            }
        }

        public AutomationElement LastTransactionDateTextBox
        {
            get
            {
                return Context.FindChildAt(_lastTransactionDateIndex);
            }
        }

        public CustomerBorrowerLocationDetailsWindow(ApplicationHelper applicationHelper) : base(applicationHelper)
        {
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                Context = ApplicationHelper.GetWindowNameByRegex(WindowName_Regex) ?? throw new Exception();
            }, ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
