using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.Tools;
using FlaUI.UIA3;
using LoanIQ.Desktop.Automation.Core.Elements;
using LoanIQ.Desktop.Automation.Core.Windows;
using System;

namespace LoanIQ.Desktop.Automation.Core
{
    public class MainWindow : WindowBase, IWindowElement
    {
        private readonly int _buttonMenu_747 = 6;
        private readonly int _buttonMenu_750 = 7;

        public MainWindow(ApplicationHelper applicationHelper, MenuButtonPane pane, MenuButtonTreePane treePane)
            : base(applicationHelper)
        {
            this.MenuButtonPane = pane;
            this.MenuButtonTreePane = treePane;

            this.MenuButtonPane.Context = Context.FindChildAt(_buttonMenu_747);
            this.MenuButtonTreePane.Context = Context.FindChildAt(9);
        }

        public MenuButtonPane MenuButtonPane { get; set; }

        public MenuButtonTreePane MenuButtonTreePane { get; set; }

        public void Dispose()
        {

        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                using (var automation = new UIA3Automation())
                {
                    var mainWindow = ApplicationHelper.Application.GetMainWindow(automation);

                    if (mainWindow == null)
                    {
                        throw new Exception();
                    }

                    mainWindow.SetForeground();
                    Context = mainWindow.FindFirstChild();
                }
            }, ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
