using Models.Common;
using System;
using System.Collections.Generic;
using UniversityManagement.SharedKernel;

namespace Models.CourseManagement
{
    //assign grades for activity and exam for a certain course
    //domain entity
    public class GradesAssignment : Entity
    {
        public Guid CourseId { get; set; }
        public Attendance Attendance { get; internal set; }
        public IList<ExamGrade> ExamGrades { get; internal set; }
        public Grade ActivityGrade { get; internal set; }
        private GradesAssignment(Guid courseId) : base(Guid.NewGuid())
        {
            this.CourseId = courseId;
            this.ExamGrades = new List<ExamGrade>();
        }

        private GradesAssignment(Guid courseId, Attendance attendance, IList<ExamGrade> examGrades, Grade activityGrade)
            : this(courseId)
        {
            Attendance = attendance;
            ExamGrades = examGrades;
            ActivityGrade = activityGrade;
        }

        public static GradesAssignment Create(Guid courseId)
        {
            Guard.IsIdGuidEmpty(courseId);
            return new GradesAssignment(courseId);
        }

        public static GradesAssignment Create(Guid courseId, Attendance attendance, IList<ExamGrade> examGrades, Grade activityGrade)
        {
            Guard.IsIdGuidEmpty(courseId);
            Guard.IsInvalidAttendenceValue(attendance);
            Guard.IsInvalidGrade(activityGrade);
            Guard.IsInvalidGradeList(examGrades);
            return new GradesAssignment(courseId, attendance, examGrades, activityGrade);
        }

        public void AddExamGrade(ExamGrade examGrade)
        {
            Guard.IsInvalidGrade(examGrade);
            ExamGrades.Add(examGrade);
        }
        public void AddActivityGrade(Grade activityGrade)
        {
            Guard.IsInvalidGrade(activityGrade);
            ActivityGrade = activityGrade;
        }
        public void AddAttendance(Attendance attendance)
        {
            Guard.IsInvalidAttendenceValue(attendance);
            Attendance = attendance;
        }

    }
}
