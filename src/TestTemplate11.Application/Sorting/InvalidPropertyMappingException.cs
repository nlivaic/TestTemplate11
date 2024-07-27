using System;

namespace TestTemplate11.Application.Sorting
{
    public class InvalidPropertyMappingException : Exception
    {
        public InvalidPropertyMappingException(string message)
            : base(message)
        {
        }
    }
}
