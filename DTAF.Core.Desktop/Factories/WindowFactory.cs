using DTAF.Core.Base;
using DTAF.Core.Desktop.Contracts;
using DTAF.Core.Desktop.Helpers;

namespace DTAF.Core.Desktop.Factories
{
    public class WindowFactory<T> : FactoryBase<T>, IWindowFactory<T> where T : IWindowElement
    {
        public ApplicationHelper ApplicationHelper { get; private set; }
        public T Context { get; private set; }

        public WindowFactory(ApplicationHelper applicationHelper, T context)
        {
            this.ApplicationHelper = applicationHelper;
            this.Context = context;
        }

    }
}
