using DTAF.Core.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using LoanIQ.Desktop.Automation.Core.Helpers;
using System;

namespace DTAF.Core.Desktop.Actions
{
    public static class DoubleClick
    {
        public static void On(AutomationElement element, bool waitForProcessing = false)
        {
            element.WaitUntilClickable(TimeSpan.FromSeconds(30));
            Wait.UntilResponsive(element);
            OnElement(element);

            if (waitForProcessing)
            {
                Wait.UntilInputIsProcessed();
                Wait.UntilProcessingWindowIsComplete();
            }

            var logger = InjectionHelper.GetInstance<DesktopLogger>();
            logger.Write(element, "has been double clicked.");
        }

        private static void OnElement(AutomationElement element)
        {
            element.Focus();

            switch (element.ControlType)
            {
                case ControlType.AppBar:
                    break;
                case ControlType.Button:
                    element.AsButton().DoubleClick();
                    break;
                case ControlType.Calendar:
                    break;
                case ControlType.CheckBox:
                    break;
                case ControlType.ComboBox:
                    break;
                case ControlType.Custom:
                    break;
                case ControlType.DataGrid:
                    break;
                case ControlType.DataItem:
                    break;
                case ControlType.Document:
                    break;
                case ControlType.Edit:
                    break;
                case ControlType.Group:
                    break;
                case ControlType.Header:
                    break;
                case ControlType.HeaderItem:
                    break;
                case ControlType.Hyperlink:
                    break;
                case ControlType.Image:
                    break;
                case ControlType.List:
                    break;
                case ControlType.ListItem:
                    element.AsListBoxItem().DoubleClick();
                    break;
                case ControlType.MenuBar:
                    element.AsMenu().DoubleClick();
                    break;
                case ControlType.Menu:
                    element.AsMenu().DoubleClick();
                    break;
                case ControlType.MenuItem:
                    element.AsMenuItem().DoubleClick();
                    break;
                case ControlType.Pane:
                    break;
                case ControlType.ProgressBar:
                    break;
                case ControlType.RadioButton:
                    element.AsRadioButton().DoubleClick();
                    break;
                case ControlType.ScrollBar:
                    break;
                case ControlType.SemanticZoom:
                    break;
                case ControlType.Separator:
                    break;
                case ControlType.Slider:
                    break;
                case ControlType.Spinner:
                    break;
                case ControlType.SplitButton:
                    break;
                case ControlType.StatusBar:
                    break;
                case ControlType.Tab:
                    break;
                case ControlType.TabItem:
                    element.AsTabItem().DoubleClick();
                    break;
                case ControlType.Table:
                    break;
                case ControlType.Text:
                    break;
                case ControlType.Thumb:
                    break;
                case ControlType.TitleBar:
                    element.AsTitleBar().DoubleClick();
                    break;
                case ControlType.ToolBar:
                    break;
                case ControlType.ToolTip:
                    break;
                case ControlType.Tree:
                    element.AsTree().DoubleClick();
                    break;
                case ControlType.TreeItem:
                    element.AsTreeItem().DoubleClick();
                    break;
                case ControlType.Window:
                    break;
                default:
                    element.DoubleClick();
                    break;
            }
        }
    }
}