using System;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using FlaUI.Core.Definitions;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class DealOutstandingSelectWindow : WindowBase, IDisposable
    {
        public DealOutstandingSelectWindow(ApplicationHelper applicationHelper)
            : base(applicationHelper)
        {
        }

        public AutomationElement OutstandingSelectStatusRadioButton(string statusRadButton)
        {
            return this.Context.FindFirstDescendant(x => x.ByName(statusRadButton).And
                    (x.ByControlType(ControlType.RadioButton)));
        }

        public AutomationElement BorrowerComboBox
        {
            get
            {
                return this.Context.FindAllChildren(x => x.ByControlType(ControlType.ComboBox))[1];
            }
        }

        public AutomationElement PricingOptionComboBox
        {
            get
            {
                return this.Context.FindAllChildren(x => x.ByControlType(ControlType.ComboBox))[2];
            }
        }

        public AutomationElement CurrencyComboBox
        {
            get
            {
                return this.Context.FindAllChildren(x => x.ByControlType(ControlType.ComboBox))[3];
            }
        }

        public AutomationElement DealTextBox
        {
            get
            {
                return this.Context.FindAllChildren(x => x.ByControlType(ControlType.Edit))[0];
            }
        }

        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindFirstChild(x => x.ByName("OK").And(x.ByControlType(ControlType.Button)));
            }
        }

        public AutomationElement CancelButton
        {
            get
            {
                return this.Context.FindFirstChild(x => x.ByName("Cancel").And(x.ByControlType(ControlType.Button)));
            }
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = ApplicationHelper.GetWindowByName("Outstanding Select") ?? throw new Exception();
                this.Context.SetForeground();
            }, this.ApplicationHelper.Config.WaitTimeout);
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
        // ~ActiveCustomerWindow() {
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
