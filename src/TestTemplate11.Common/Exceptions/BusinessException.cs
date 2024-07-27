using System;

namespace TestTemplate11.Common.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message)
            : base(message)
        {
        }
    }
}