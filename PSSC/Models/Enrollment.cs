using Models.Common;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public class Enrollment : Entity<Guid>
    {
        //TODO: we can add a factory method here
        public Enrollment(Guid id, Guid studentId, Course course) : this(id)
        {
            //TODO: validations and logging
            this.Course = course;
            this.StudentId = studentId;
            this.CourseId = course.Id;

        }
        public Enrollment(Course course, Guid studentId) : this(Guid.NewGuid(),studentId, course)
        {

        }
        public Enrollment(Guid id) : base(id)
        {
            Grades = new List<Grade>();
        }
        public Enrollment() : base(Guid.NewGuid())
        {
            Grades = new List<Grade>();
        }
        public Guid StudentId { get; private set; }
        public Student Student { get; set; }
        public Guid CourseId { get; private set; }
        public Course Course { get; set; }
        public IList<Grade> Grades { get; set; }
        public EvaluationResult EvaluationResult
        {
            get
            {
                //TODO:check if the course evaluation is distributed and see if there are two grades
                var result = EvaluationResult.Unknown;
                if (this.Grades != null && this.Grades.Count() > 0)
                {
                    result = (this.Grades.Average(x => x.Value) > 5) ? EvaluationResult.Passed : EvaluationResult.Failed;
                }
                return result;
            }
        }

        public bool AddGrade(float gradeValue, GradeType type, DateTime examDate)
        {
            //TODO: log
            var result = false;
            if (gradeValue > 0)
            {
                var grade = new Grade(gradeValue, type, examDate);
                Grades.Add(grade);
                result = true;    
            }
            return result;
        }
    }
}
