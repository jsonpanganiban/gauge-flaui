using DTAF.Core.Desktop.Contracts;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Tools;
using FlaUI.UIA3;
using System;
using System.Linq;

namespace DTAF.Core.Desktop.Actions
{
    public enum WaitToFinish
    {
        YES,
        NO
    }

    public static class Wait
    {
        public static void For<T>(T window, Action<T> func, WaitToFinish waitToClose = WaitToFinish.NO)
            where T : IWindowElement
        {
            window.Context.WaitUntilClickable(TimeSpan.FromSeconds(250));

            func(window);

            if(waitToClose == WaitToFinish.YES)
            {
                // TODO: fix this: window.Context.IsOffscreen == false is always false even though it is closed.
                //UntilNotVisible(window.Context);
                //Retry.WhileTrue(() => window != null && window.Context.IsOffscreen == false, TimeSpan.FromSeconds(250),
                //TimeSpan.FromMilliseconds(250), true);
            }
        }

        public static void For(AutomationElement[] elements, Action<AutomationElement[]> func)
        {
            elements.ToList().ForEach(e =>
            {
                if (e.ControlType == ControlType.ComboBox)
                {
                    Retry.WhileTrue(() => e.AsComboBox().Items.Length == 0, TimeSpan.FromSeconds(250),
                    TimeSpan.FromMilliseconds(250), true);
                }
            });

            func(elements);
        }

        public static void UntilVisible(AutomationElement element, int timeout = 30)
        {
            // FIX THIS
            Retry.WhileTrue(() => {
                if (element == null)
                    return true;
                else
                {
                    if (element.ControlType == ControlType.Window)
                        return element.IsOffscreen == true;
                    else
                        return false;
                }
                }, TimeSpan.FromSeconds(timeout),
                TimeSpan.FromMilliseconds(250), true);
        }

        public static void UntilNotVisible(AutomationElement element, int timeout = 30)
        {
            // FIX THIS
            Retry.WhileTrue(() => {
                if (element == null)
                    return true;
                else
                    return element.IsOffscreen == false;
            }, TimeSpan.FromSeconds(timeout),
                TimeSpan.FromMilliseconds(250), true);

            //Retry.WhileTrue(() => element == null && element.IsOffscreen == false, TimeSpan.FromSeconds(timeout),
            //    TimeSpan.FromMilliseconds(250), true);
        }

        public static void UntilInputIsProcessed()
        {
            FlaUI.Core.Input.Wait.UntilInputIsProcessed();
        }

        public static void UntilResponsive(AutomationElement element)
        {
            FlaUI.Core.Input.Wait.UntilResponsive(element);
        }

        public static void UntilProcessingWindowExists()
        {
            using (UIA3Automation automation = new UIA3Automation())
            {
                var retryResult = Retry.WhileNull<Window>(() =>
                {
                    return automation.GetDesktop().FindFirstChild(c => c.ByText("Processing")).AsWindow();
                }, timeout: TimeSpan.FromSeconds(5), ignoreException: true);
            }
        }

        public static void UntilProcessingWindowIsComplete()
        {
            using (UIA3Automation automation = new UIA3Automation())
            {
                var retryResult = Retry.WhileNotNull<Window>(() =>
                {
                    return automation.GetDesktop().FindFirstChild(c => c.ByText("Processing")).AsWindow();
                }, timeout: TimeSpan.FromSeconds(30), ignoreException: true);
            }
        }
    }
}