using DTAF.Core.Helpers;
using LightInject;

namespace DTAF.Core.Base
{
    public abstract class StepBase
    {
        public SoftAssertions Assertions { get; protected set; }

        protected IServiceContainer Container
        {
            get
            {
                return InjectionHelper.Instance;
            }
        }

        public StepBase()
        {
            
        }

        protected virtual void Register()
        {
            
        }
    }
}
