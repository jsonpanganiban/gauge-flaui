using System;
using DTAF.Core.Contracts;

namespace DTAF.Core
{
    public class Config : IConfig
    {
        public string ProcessName { get; private set; }
        public string ExecutableLocation { get; private set; }
        public string Args { get; private set; }
        public TimeSpan WaitTimeout { get; private set; }

        public Config(string processName, string exeLocation, string args, int seconds)
        {
            this.ProcessName = processName;
            this.ExecutableLocation = exeLocation;
            this.Args = args;
            this.WaitTimeout = TimeSpan.FromSeconds(seconds);
        }
    }
}
