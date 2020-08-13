using System;

namespace DTAF.Core.Desktop.Exceptions
{
    public class AssertionException : Exception
    {
        public AssertionException(string message) 
            : base(message)
        {

        }
    }
}
