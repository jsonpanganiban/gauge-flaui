using DTAF.Core.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;
using FlaUI.UIA3;
using LoanIQ.Desktop.Automation.Core.Helpers;
using System;

namespace DTAF.Core.Desktop.Actions
{
    public static class Enter
    {
        public static void TextInto(AutomationElement context, string value, bool useFlaUIEnter = true)
        {
            using (var automation = new UIA3Automation())
            {
                var textBox = context.AsTextBox();
                Wait.UntilResponsive(textBox);
                textBox.WaitUntilClickable(TimeSpan.FromSeconds(15));

                if (!useFlaUIEnter)
                {
                    Retry.WhileFalse(() =>
                    {
                        textBox.Focus();
                        return textBox.Text == value;
                    }, TimeSpan.FromSeconds(15), TimeSpan.FromMilliseconds(250), true);
                }
                else
                {
                    textBox.Enter(value);
                }

                var logger = InjectionHelper.GetInstance<DesktopLogger>();
                logger.Write(context, "has been filled with " + value);
            }
        }

        public static void TextInto(AutomationElement context, string value, VirtualKeyShort virtualKeyShort, bool waitForProcessing = false)
        {
            using (var automation = new UIA3Automation())
            {
                var textBox = context.AsTextBox();
                Wait.UntilResponsive(textBox);
                textBox.Enter(value);
                Keyboard.Press(virtualKeyShort);

                if (waitForProcessing)
                {
                    Wait.UntilInputIsProcessed();
                    Wait.UntilProcessingWindowIsComplete();
                }

                var logger = InjectionHelper.GetInstance<DesktopLogger>();
                logger.Write(context, "has been filled with " + value);
            }
        }


        //public static void TextInto(AutomationElement context, string value, VirtualKeyShort virtualKeyShort = VirtualKeyShort.ENTER)
        //{
        //    using (var automation = new UIA3Automation())
        //    {
        //        var textBox = context.AsTextBox();
        //        textBox.Enter(string.Empty);
        //        textBox.Enter(value);

        //        Keyboard.Press(virtualKeyShort);

        //        Wait.UntilInputIsProcessed();
        //    }
        //}
    }
}
