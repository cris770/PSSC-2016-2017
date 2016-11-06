using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using UniversityManagement.SharedKernel;

namespace Models.CourseManagement
{
    //aggregat root for professor
    public class ProfessorAggregate : Entity
    {
        public IDictionary<Guid, List<GradesAssignment>> StudentGrades { get; private set; }
        public IList<Course> Courses { get; private set; }
        public readonly Proportion Proportion;
        //for EF only
        private ProfessorAggregate() : base(Guid.NewGuid())
        {
        }

        public ProfessorAggregate(IList<Student> students, IList<Course> courses, Proportion proportion)
            : base(Guid.NewGuid())
        {
            Guard.IsEmpyStudentList(students);
            this.StudentGrades = new Dictionary<Guid, List<GradesAssignment>>();
            this.Courses = courses;
            this.Proportion = proportion;
            foreach (var student in students)
            {
                this.StudentGrades.Add(student.Id, new List<GradesAssignment>());
            }
        }

        public void AddExamGrade(Guid studentId, Guid courseId, ExamGrade grade)
        {
            Guard.IsIdGuidEmpty(courseId);
            Guard.IsIdGuidEmpty(studentId);
            Guard.IsInvalidGrade(grade);
            //throws by default KeyNotFoundException if the key does not exisy
            if (this.StudentGrades[studentId].Any(g=>g.CourseId == courseId))
            {
                this.StudentGrades[studentId].Add(GradesAssignment.Create(courseId));
            }
            this.StudentGrades[studentId].Where(g => g.CourseId == courseId).FirstOrDefault()?.AddExamGrade(grade);
        }

        public void AddActivityGrade(Guid studentId, Guid courseId, Grade grade)
        {
            Guard.IsIdGuidEmpty(courseId);
            Guard.IsIdGuidEmpty(studentId);
            Guard.IsInvalidGrade(grade);
            //throws by default KeyNotFoundException if the key does not exisy
            if (this.StudentGrades[studentId].Any(g => g.CourseId == courseId))
            {
                this.StudentGrades[studentId].Add(GradesAssignment.Create(courseId));
            }
            this.StudentGrades[studentId].Where(g => g.CourseId == courseId).FirstOrDefault()?.AddActivityGrade(grade);
        }

        public void AddActivityGrade(Guid studentId, Guid courseId, Attendance attendance)
        {
            Guard.IsIdGuidEmpty(courseId);
            Guard.IsIdGuidEmpty(studentId);
            Guard.IsInvalidAttendenceValue(attendance);
            //throws by default KeyNotFoundException if the key does not exisy
            if (this.StudentGrades[studentId].Any(g => g.CourseId == courseId))
            {
                this.StudentGrades[studentId].Add(GradesAssignment.Create(courseId));
            }
            this.StudentGrades[studentId].Where(g => g.CourseId == courseId).FirstOrDefault()?.AddAttendance(attendance);
        }

    }
}
