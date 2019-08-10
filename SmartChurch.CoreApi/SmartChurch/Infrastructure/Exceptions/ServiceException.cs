using System;

namespace SmartChurch.Infrastructure.Exceptions
{
    public class ServiceException : Exception
    {
        public override string Message =>
            "This service is unavailable.";
    }
}