using Models.Common;
using System;
using System.Collections.Generic;

namespace Models
{
    public class Department : Entity<Guid>
    {
        protected Department(Guid id) : base(id)
        {
        }

        protected Department() : base(Guid.NewGuid())
        {
        }

        public IList<Course> Courses { get; set; }
        public IList<Enrollment> Enrollments { get; set; }

        public void AddCourse()
        {
            //TODO:
        }

        public void AddEnrollments()
        {
            //TODO:
        }

        //TODO: reporting



    }
}
