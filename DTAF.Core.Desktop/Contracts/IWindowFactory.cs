using DTAF.Core.Contracts;
using DTAF.Core.Desktop.Helpers;

namespace DTAF.Core.Desktop.Contracts
{
    public interface IWindowFactory<T> : IFactory<T> where T: IWindowElement
    {
        ApplicationHelper ApplicationHelper { get; }
        T Context { get; }
    }
}
