using System;
using UniversityManagement.SharedKernel;

namespace Models.Common
{
    public class Grade:ValueObject<Grade>
    {
        private decimal _value;
        public decimal Value { get { return _value; } }

        public Grade(decimal value) 
        {
            _value = value;
        }
    }
}
