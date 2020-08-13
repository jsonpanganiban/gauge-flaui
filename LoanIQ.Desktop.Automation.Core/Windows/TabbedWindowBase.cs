using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoanIQ.Desktop.Automation.Core.Windows
{
    public abstract class TabbedWindowBase : WindowBase
    {
        protected IList<IElement> Tabs { get; private set; }

        public TabbedWindowBase(ApplicationHelper applicationHelper)
            : base(applicationHelper)
        {
            this.Tabs = new List<IElement>();
        }

        protected void AddTab(IElement tab)
        {
            this.Tabs.Add(tab);
        }

        protected virtual T GetTabContentPane<T>()
            where T : IElement, new()
        {
            var pane = this.Tabs.Where(t => t.GetType() == typeof(T)).FirstOrDefault();
            pane.Context = TabContentQuery();
            return (T)pane;
        }

        protected virtual AutomationElement TabContentQuery()
        {
            return this.Context.FindFirstChild(c => c.ByControlType(ControlType.Tab)).FindChildAt(0);
        }
    }
}
