using DTAF.Core.Desktop.Helpers;
using DTAF.Core.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using LoanIQ.Desktop.Automation.Core.Elements.Tabs;
using LoanIQ.Desktop.Automation.Core.Helpers;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public abstract class WindowBase : Element
    {
        protected ApplicationHelper ApplicationHelper { get; private set; }

        public WindowBase(ApplicationHelper applicationHelper)
        {
            this.ApplicationHelper = applicationHelper;
            this.ResolveElement();
        }

        protected virtual void ResolveElement()
        {
            this.Context.SetForeground();

            var logger = InjectionHelper.GetInstance<DesktopLogger>();
            logger.Write(this.Context, "has been focused on");
        }

        public virtual void Maximize()
        {
            this.Context.Parent.AsWindow().MaximizeWindow();
        }

        public virtual void Close()
        {
            if (this.Context.ControlType == ControlType.Window)
                this.Context.AsWindow().Dispose();
            else
                this.Context.Parent.AsWindow().Dispose();
        }
    }
}
