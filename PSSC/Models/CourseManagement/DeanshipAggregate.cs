using System;
using System.Collections.Generic;
using System.Linq;
using UniversityManagement.SharedKernel;

namespace Models.CourseManagement
{
    public class DeanshipAggregate:Entity
    {
        public IList<CourseAssignment> CourseAssignments { get; private set; }
        public int StudyYear { get; private set; }
       
        private DeanshipAggregate():base(Guid.NewGuid())
        {

        }
        public DeanshipAggregate(int studyYear) : base(Guid.NewGuid())
        {
            this.StudyYear = studyYear;
        }

        public void AddCourseAssignment(CourseAssignment courseAssignment)
        {
            if (CourseAssignments.Any(a => a.Id == courseAssignment.Id))
            {
                throw new ArgumentException("Cannot add duplicate appointment to schedule.", "appointment");
            }
            CourseAssignments.Add(courseAssignment);

        }
    }
}
