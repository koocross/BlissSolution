using System;

namespace Forum.CQRS.Exceptions
{
    public class UnRegisteredCommandException : Exception
    {
        public UnRegisteredCommandException() { }

        public UnRegisteredCommandException(string message) : base(message) { }
    }
}
