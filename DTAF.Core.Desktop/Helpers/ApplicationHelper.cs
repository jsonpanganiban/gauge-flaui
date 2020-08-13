using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using DTAF.Core.Contracts;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.UIA3;

namespace DTAF.Core.Desktop.Helpers
{
    public class ApplicationHelper
    {
        public Application Application { get; private set; }
        public IConfig Config { get; private set; }

        public ApplicationHelper(IConfig config)
        {
            this.Config = config;
            this.Application = GetApplication();
        }

        public Application GetApplication()
        {
            try
            {
                if (GetLoadedProcess() == null)
                {
                    this.StartApplication();
                }
                return Application.Attach(GetLoadedProcess());
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }


        public ProcessStartInfo StartApplication()
        {
            try
            {
                var info = new ProcessStartInfo
                {
                    FileName = Config.ExecutableLocation,
                    Arguments = Config.Args
                };
                var pBuilder = new Process
                {
                    StartInfo = info
                }.Start();

                return info;
            }
            catch (Exception ex)
            {
                //GaugeMessages.WriteMessage("ERROR: Failed to Start " + appName);
                //GaugeMessages.WriteMessage("DETAILS: " + ex);
                ex.ToString();
                return null;
            }
        }

        private Process GetLoadedProcess()
        {
            return Process.GetProcessesByName(Config.ProcessName).FirstOrDefault();
        }

        public Menu GetContextMenu(string menuName = "Context")
        {
            using (var automation = new UIA3Automation())
            {
                return this.Application.GetMainWindow(automation).ContextMenu;
            }
        }

        public Window GetWindowNameByRegex(string expression)
        {

            using (var automation = new UIA3Automation())
            {
                var regex = new Regex(expression);
                return this.Application.GetAllTopLevelWindows(automation).FirstOrDefault(_ => regex.Match(_.Name).Success);
            }
        }

        public Window[] GetAllWindows()
        {
            using (var automation = new UIA3Automation())
            {
                return this.Application.GetAllTopLevelWindows(automation);
            }
        }

        public Window GetWindowByName(string name)
        {
            using (var automation = new UIA3Automation())
            {

                return this.Application.GetAllTopLevelWindows(automation).FirstOrDefault(w => w.Name == name);
            }
        }

        public Window GetDialogByName(string name)
        {
            using (var automation = new UIA3Automation())
            {
                var window = this.Application.GetMainWindow(automation);
                return window.Name == name ? window : null;
            }
        }

        public Window GetDialogWithNameContaining(string name)
        {
            using (var automation = new UIA3Automation())
            {
                var window = this.Application.GetMainWindow(automation);
                return window.Name.Contains(name) ? window : null;
            }
        }

        public Window GetWindowWithNameContaining(string name)
        {
            using (var automation = new UIA3Automation())
            {
                return this.Application.GetAllTopLevelWindows(automation).FirstOrDefault(w => w.Name.ToLower().Contains(name.ToLower()));
            }
        }

        public Window GetWindowsByNames(string[] names)
        {
            using (var automation = new UIA3Automation())
            {
                return this.Application.GetAllTopLevelWindows(automation).Where(w => names.Any(n => n == w.Name)).FirstOrDefault();
            }
        }

        public void MaximizeWindow(Window window)
        {
            if (window.Patterns.Window.Pattern.WindowVisualState.Value != WindowVisualState.Maximized)
            {
                window.TitleBar.MaximizeButton.Click();
            }
        }
    }
}
