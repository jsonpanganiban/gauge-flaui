using DTAF.Core.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using LoanIQ.Desktop.Automation.Core.Helpers;
using System;

namespace DTAF.Core.Desktop.Actions
{
    public static class Click
    {
        private static void OnElement(AutomationElement element)
        {
            element.Focus();

            switch (element.ControlType)
            {
                case ControlType.AppBar:
                    break;
                case ControlType.Button:
                    element.AsButton().Click();
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
                    element.AsListBoxItem().Click();
                    break;
                case ControlType.MenuBar:
                    element.AsMenu().Click();
                    break;
                case ControlType.Menu:
                    element.AsMenu().Click();
                    break;
                case ControlType.MenuItem:
                    element.AsMenuItem().Click();
                    break;
                case ControlType.Pane:
                    break;
                case ControlType.ProgressBar:
                    break;
                case ControlType.RadioButton:
                    element.AsRadioButton().Click();
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
                    element.AsTabItem().Click();
                    break;
                case ControlType.Table:
                    break;
                case ControlType.Text:
                    break;
                case ControlType.Thumb:
                    break;
                case ControlType.TitleBar:
                    break;
                case ControlType.ToolBar:
                    break;
                case ControlType.ToolTip:
                    break;
                case ControlType.Tree:
                    element.AsTree().Click();
                    break;
                case ControlType.TreeItem:
                    element.AsTreeItem().Click();
                    break;
                case ControlType.Window:
                    break;
                default:
                    element.Click();
                    break;
            }
        }

        public static void On(AutomationElement element, bool waitForProcessing = false)
        {
            try
            {
                Wait.UntilResponsive(element);
                element.WaitUntilClickable(TimeSpan.FromSeconds(30));
                OnElement(element);

                if (waitForProcessing)
                {
                    Wait.UntilInputIsProcessed();
                    Wait.UntilProcessingWindowIsComplete();
                }

                var logger = InjectionHelper.GetInstance<DesktopLogger>();
                logger.Write(element, "has been clicked");
            }
            catch (Exception ex)
            {
                var logger = InjectionHelper.GetInstance<DesktopLogger>();
                logger.WriteError(ex.Message);
                throw ex;
            }
        }
    }
}