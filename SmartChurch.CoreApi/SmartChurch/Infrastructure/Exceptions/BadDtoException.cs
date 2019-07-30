using System;

namespace SmartChurch.Infrastructure.Exceptions
{
    public class BadDtoException : Exception
    {
        public BadDtoException(string message) : base(message) 
        {}
    }
}