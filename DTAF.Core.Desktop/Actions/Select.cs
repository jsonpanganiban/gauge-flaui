using System;
using DTAF.Core.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;
using LoanIQ.Desktop.Automation.Core.Helpers;

namespace DTAF.Core.Desktop.Actions
{
    public static class Select
    {
        //TODO
        public static void By(AutomationElement element, string text, VirtualKeyShort? virtualKeyShort = VirtualKeyShort.TAB)
        {
            var logger = InjectionHelper.GetInstance<DesktopLogger>();

            if (element.ControlType == ControlType.ComboBox)
            {
                Wait.UntilResponsive(element);
                var combo = element.AsComboBox();
                combo.Focus();
                combo.Expand();
                combo.Select(text);
                combo.Collapse();
                Keyboard.Press(virtualKeyShort.Value);

                logger.Write(combo, "has been selected");
            }
            if (element.ControlType == ControlType.List)
            {
                var list = element.AsListBox();
                
                if (virtualKeyShort == null)
                {
                    var item = list.FindFirstChild(c => c.ByName(text));
                    Click.On(item);
                }
                else
                {
                    list.Select(text);
                    Keyboard.Press(virtualKeyShort.Value);
                }

                logger.Write(list, "has been selected");
            }
        }

        // DEPRECATED
        public static void ByAndWait(AutomationElement elementOne, string textOne, AutomationElement elementTwo, string textTwo)
        {

            if (elementOne.ControlType == ControlType.ComboBox && elementTwo.ControlType == ControlType.ComboBox)
            {
                var combo = elementOne.AsComboBox();
                combo.Expand();
                combo.Select(textOne);
                combo.Collapse();
                Keyboard.Press(VirtualKeyShort.ENTER);

                Retry.WhileTrue(() => elementTwo.AsComboBox().Items.Length == 0,
                TimeSpan.FromSeconds(30), TimeSpan.FromMilliseconds(250));

                combo = elementTwo.AsComboBox();
                combo.Expand();
                combo.Select(textTwo);
                combo.Collapse();
                Keyboard.Press(VirtualKeyShort.ENTER);

            }
        }

        public static void By(AutomationElement element, int index, bool isDouble)
        {
            var logger = InjectionHelper.GetInstance<DesktopLogger>();

            if (isDouble && element.ControlType == ControlType.Tree)
            {
                var tree = element.AsTree();
                var item = tree.FindChildAt(index);
                DoubleClick.On(item);

                logger.Write(tree, "has been selected");
            }
        }

        //TODO
        public static void By(AutomationElement element, int index, VirtualKeyShort virtualKeyShort = VirtualKeyShort.TAB)
        {
            var logger = InjectionHelper.GetInstance<DesktopLogger>();

            if (element.ControlType == ControlType.ComboBox)
            {
                var combo = element.AsComboBox();
                combo.Expand();
                combo.Select(index);
                combo.Collapse();
                Keyboard.Press(virtualKeyShort);

                logger.Write(combo, "has been selected");
            }
            if (element.ControlType == ControlType.Tree)
            {
                var tree = element.AsTree();
                var item = tree.FindChildAt(index);
                Click.On(item);

                logger.Write(tree, "has been selected");
            }

            
        }
    }
}