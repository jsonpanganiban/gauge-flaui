using DTAF.Core.Base;
using DTAF.Core.Contracts;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Factories;
using DTAF.Core.Desktop.Helpers;
using LightInject;
using LoanIQ.Desktop.Automation.Core.Helpers;

namespace DTAF.Core.Desktop
{
    public class DesktopStepBase : StepBase
    {
        private Config _config;

        public DesktopStepBase(Config config)
        {
            this._config = config;

            this.Register();
        }

        protected virtual T GetWindow<T>()
            where T: IWindowElement
        {
            return this.Container.GetInstance<WindowFactory<T>>().Context;
        }

        protected override void Register()
        {
            base.Register();

            //config
            this.Container.RegisterInstance<IConfig>(this._config);
            this.Container.Register<ApplicationHelper>(new PerContainerLifetime());
            this.Container.Register<DesktopLogger>(new PerContainerLifetime());
        }
    }
}
