using Models.Common;
using UniversityManagement.SharedKernel;

namespace Models.CourseManagement
{
    public class Student : Entity
    {
        public RegistrationNumber RegNumber { get; internal set; }
        public PlainText Name { get; internal set; }
        public Credits Credits { get; internal set; }

        public Student(RegistrationNumber regNumber, PlainText name)
        {
            RegNumber = regNumber;
            Name = name;
        }

        public Student(RegistrationNumber regNumber, PlainText name, Credits credits)
            : this(regNumber, name)
        {
            Credits = credits;
        }
    }
}
