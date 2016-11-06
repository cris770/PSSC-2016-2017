using System;

namespace Models.Common.Exceptions
{
    public class InvalidIdException : Exception
    {
        public InvalidIdException(string message)
        : base(message)
        {
        }
    }
}
