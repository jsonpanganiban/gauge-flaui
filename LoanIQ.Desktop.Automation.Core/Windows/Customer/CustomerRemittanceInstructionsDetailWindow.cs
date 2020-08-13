using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Tools;
using LoanIQ.Desktop.Automation.Core.Helpers;
using System;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class CustomerRemittanceInstructionsDetailWindow : WindowBase, IDisposable, IWindowElement
    {
        private const int _methodComboBoxIndex = 5;
        private const int _methodDescriptionTextBoxIndex = 4;
        private const int _accountNameTextBoxIndex = 6;
        private const int _currencyComboBoxIndex = 22;
        private const int _accountNumberTextBoxIndex = 26;
        private const int _custodyAccountTextBoxIndex = 28;

        public AutomationElement CurrnecyComboBox
        {
            get
            {
                return Context.FindChildAt(_currencyComboBoxIndex);
            }
        }


        public AutomationElement CustodyAccountTextBox
        {
            get
            {
                return Context.FindChildAt(_custodyAccountTextBoxIndex);
            }
        }

        public AutomationElement AccountNumberTextBox
        {
            get
            {
                return Context.FindChildAt(_accountNumberTextBoxIndex);
            }
        }

        public AutomationElement AccountNameTextBox
        {
            get
            {
                return Context.FindChildAt(_accountNameTextBoxIndex);
            }
        }

        public AutomationElement MethodComboBox
        {
            get
            {
                return Context.FindChildAt(_methodComboBoxIndex);
            }
        }

        public AutomationElement MethodDescriptionTextBox
        {
            get
            {
                return Context.FindChildAt(_methodDescriptionTextBoxIndex);
            }
        }

        public AutomationElement AllLoanTypesCheckBox
        {
            get
            {
                return Context.FindFirstDescendant(_ => _.ByName("All Loan Types")
                                                         .And(_.ByControlType(FlaUI.Core.Definitions.ControlType.CheckBox)));
            }
        }

        public AutomationElement SBLC_BACheckBox
        {
            get
            {
                return Context.FindFirstDescendant(_ => _.ByName("SBLC/BA")
                                                         .And(_.ByControlType(FlaUI.Core.Definitions.ControlType.CheckBox)));
            }
        }

        public AutomationElement FromCustCheckBox
        {
            get
            {
                return Context.FindFirstDescendant(_ => _.ByName("From Cust")
                                                         .And(_.ByControlType(FlaUI.Core.Definitions.ControlType.CheckBox)));

            }
        }

        public AutomationElement ToCustCheckBox
        {
            get
            {
                return Context.FindFirstDescendant(_ => _.ByName("To Cust")
                                                         .And(_.ByControlType(FlaUI.Core.Definitions.ControlType.CheckBox)));

            }
        }

        public AutomationElement PrincipalCheckBox
        {
            get
            {
                return Context.FindFirstDescendant(_ => _.ByName("Principal")
                                                         .And(_.ByControlType(FlaUI.Core.Definitions.ControlType.CheckBox)));
            }
        }

        public AutomationElement InterestCheckBox
        {
            get
            {
                return Context.FindFirstDescendant(_ => _.ByName("Interest")
                                                         .And(_.ByControlType(FlaUI.Core.Definitions.ControlType.CheckBox)));

            }
        }

        public AutomationElement FeesCheckBox
        {
            get
            {
                return Context.FindFirstDescendant(_ => _.ByName("Fees")
                                                         .And(_.ByControlType(FlaUI.Core.Definitions.ControlType.CheckBox)));

            }
        }

        public CustomerRemittanceInstructionsDetailWindow(ApplicationHelper applicationHelper) : base(applicationHelper)
        {
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                var remittanceList = ApplicationHelper.GetWindowWithNameContaining("Remittance Instructions Detail--");
                Context = remittanceList.FindFirstChild() ?? throw new Exception();
                Context.Focus();
            }, ApplicationHelper.Config.WaitTimeout);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CustomerRemittanceInstructionsDetailWindow() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
