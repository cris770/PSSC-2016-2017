using System;

namespace Models.Common.Exceptions
{
    public class InvalidStudentListException : Exception
    {
        public InvalidStudentListException(string message) :base(message)
        {

        }
    }
}
