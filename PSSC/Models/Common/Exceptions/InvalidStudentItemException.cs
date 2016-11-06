using System;

namespace Models.Common.Exceptions
{
    public class InvalidStudentItemException:Exception
    {
        public InvalidStudentItemException(string message) : base(message)
        {
                
        }
    }
}
