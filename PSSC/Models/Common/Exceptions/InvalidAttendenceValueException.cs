using System;

namespace Models.Common.Exceptions
{
    public class InvalidAttendenceValueException: Exception
    {
        public InvalidAttendenceValueException(string message):base(message)
        {

        }
    }
}
