using Models.Common;
using UniversityManagement.SharedKernel;

namespace Models.CourseManagement
{
    //reference entity; contains information about a professor
    public class Professor : Entity
    {
        public PlainText Name { get; internal set; }

        public Professor(PlainText name)
        {
            Name = name;
        }
    }
}
