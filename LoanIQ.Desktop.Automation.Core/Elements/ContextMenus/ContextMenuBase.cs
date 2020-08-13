using System;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;
using FlaUI.Core.Tools;
using FlaUI.UIA3;
using Gauge.CSharp.Lib;
using LoanIQ.Desktop.Automation.Core.Windows;

namespace LoanIQ.Desktop.Automation.Core.Elements.ContextMenus
{
    public class ContextMenuBase : WindowBase, IWindowElement
    {
        public ContextMenuBase(ApplicationHelper applicationHelper)
            :base(applicationHelper)
        {

        }

        protected override void ResolveElement()
        {
            using (var automation = new UIA3Automation())
            {
                Retry.WhileException(() =>
                {
                    this.Context = this.ApplicationHelper.GetContextMenu() ?? throw new Exception();
                }, this.ApplicationHelper.Config.WaitTimeout);
            }
            GaugeMessages.WriteMessage("Loaded");
        }
    }
}
