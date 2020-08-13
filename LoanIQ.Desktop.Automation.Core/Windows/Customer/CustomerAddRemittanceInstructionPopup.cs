using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Tools;
using LoanIQ.Desktop.Automation.Core.Helpers;
using System;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class CustomerAddRemittanceInstructionPopup : WindowBase, IDisposable, IWindowElement
    {

        public AutomationElement StandardRemittanceRadioButton
        {
            get
            {
                return Context.FindFirstDescendant(_ => _.ByName("Add Standard Remittance Instruction"));
            }
        }

        public CustomerAddRemittanceInstructionPopup(ApplicationHelper applicationHelper) : base(applicationHelper)
        {
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                var remittanceList = this.ApplicationHelper.GetWindowByName("Add Remittance Instruction");
                this.Context = remittanceList ?? throw new Exception();
                this.Context.Focus();
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
        // ~CustomerAddRemittanceInstructionPopup() {
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
