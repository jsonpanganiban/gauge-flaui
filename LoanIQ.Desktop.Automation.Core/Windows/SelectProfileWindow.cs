using System;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Tools;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public class SelectProfileWindow : WindowBase, IWindowElement
    {
        public SelectProfileWindow(ApplicationHelper applicationHelper)
            : base(applicationHelper)
        {

        }

        public AutomationElement ProfileTree
        {
            get
            {
                return this.Context.FindFirstDescendant(_ => _.ByControlType(ControlType.Tree));
            }
        }

        public AutomationElement OkButton
        {
            get
            {
                return this.Context.FindFirstChild();
            }
        }


        public void Dispose()
        {
            
        }

        protected override void ResolveElement()
        {
            Retry.WhileException(() =>
            {
                this.Context = ApplicationHelper.GetWindowByName("Select Profile") ?? throw new Exception();
            }, this.ApplicationHelper.Config.WaitTimeout);

            base.ResolveElement();
        }
    }
}
