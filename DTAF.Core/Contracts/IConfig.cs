using System;

namespace DTAF.Core.Contracts
{
    public interface IConfig
    {
        string ProcessName { get; }
        string ExecutableLocation { get; }
        string Args { get; }
        TimeSpan WaitTimeout { get; }
    }
}
