using System;
using System.Collections.Generic;

namespace Models
{
    public  class Student : Person
    {
        public Student()
        {
            Enrollments = new List<Enrollment>();
        }
        public long RegistrationNumber { get; private set; }
        public IList<Enrollment> Enrollments { get; set; }
        public bool AddEnrollment(Course course, Guid studentId)
        {
            var result = false;
            if (course != null && studentId != Guid.Empty)
            {
                var enrl = new Enrollment(course, studentId);
                Enrollments.Add(enrl);
                result = true;
            }
            return result;
        }
        public int GetCreditNumer()
        {
            int result = 0;
            if(Enrollments != null && Enrollments.Count > 0)
            {
                foreach (var enrollment in Enrollments)
                {
                    //TODO: validations
                    result = enrollment.Course.Credits;
                }
            }
            return result;
        }

    }
}
