using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using System;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class CommonSelectionPopupWindow : WindowBase, IDisposable
    {
        public CommonSelectionPopupWindow(ApplicationHelper applicationHelper) : base(applicationHelper)
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
                return Context.FindFirstDescendant(x => x.ByName("Search/Sort By:"));
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
                                                                                       "Select Location"
                }) ?? throw new Exception();
                Context.SetForeground();
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
