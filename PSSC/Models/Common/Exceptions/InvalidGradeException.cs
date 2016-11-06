using System;

namespace Models.Common.Exceptions
{
    public class InvalidGradeException:Exception
    {
        public InvalidGradeException(string message):base(message)
        {

        }
    }
}
