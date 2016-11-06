using Models.Common;
using Models.Common.Enums;
using System;
using UniversityManagement.SharedKernel;

namespace Models.CourseManagement
{
    public class Course : Entity
    {
        public PlainText Name { get; internal set; }
        public EvaluationType EvaluationType { get; set; }
        public Credits Credits { get; set; }
        public Course(PlainText name, EvaluationType evaluationType, Credits credits)
            : base(Guid.NewGuid())
        {
            this.Name = name;
            this.EvaluationType = evaluationType;
            this.Credits = credits;
        }
    }
}
