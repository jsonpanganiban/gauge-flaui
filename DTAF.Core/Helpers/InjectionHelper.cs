using LightInject;
using System;

namespace DTAF.Core.Helpers
{
    public static class InjectionHelper
    {
        static IServiceContainer _instance;

        public static IServiceContainer Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ServiceContainer();

                return _instance;
            }
        }

        public static T GetInstance<T>()
        {
            return (T)_instance.GetInstance(typeof(T));
        }
    }
}
