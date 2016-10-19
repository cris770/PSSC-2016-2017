using Models.Enums;
using System;
using System.Collections.Generic;

namespace Models
{
    public class Professor : Person
    {
        public IList<Course> Courses { get; set; }
        public bool AddGrade(Enrollment enrollment, float gradeValue, GradeType gradeType, DateTime date)
        {
            var result = false;
            if (enrollment != null && gradeValue > 0 && date != default(DateTime))
            {
                enrollment.AddGrade(gradeValue, gradeType, date);
                result = true;
            }
            return result;
        }

    }
}
