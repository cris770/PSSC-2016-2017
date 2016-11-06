using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagement.SharedKernel;

namespace Models.CourseManagement
{
    //domain entity that links a course to a professor and to a list of students
    public class CourseAssignment : Entity
    {
        public Guid CourseId { get; set; }
        public Guid ProfessorId { get; set; }
        public IList<Student> Students { get; set; }

        private CourseAssignment() : base(Guid.NewGuid())
        { }
        /// <summary>
        /// Factory method for domain entity creation
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="professorId"></param>
        /// <returns></returns>
        public static CourseAssignment Create(Guid courseId, Guid professorId)
        {
            Guard.IsIdGuidEmpty(courseId);
            Guard.IsIdGuidEmpty(professorId);
            var result = new CourseAssignment();
            result.Students = new List<Student>();
            result.CourseId = courseId;
            result.ProfessorId = professorId;
            return result;
        }

        /// <summary>
        /// Factory method for domain entity creation
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="professorId"></param>
        /// <returns></returns>
        public static CourseAssignment Create(Guid courseId, Guid professorId, IList<Student> enrolledStudents)
        {
            Guard.IsIdGuidEmpty(courseId);
            Guard.IsIdGuidEmpty(professorId);
            Guard.IsEmpyStudentList(enrolledStudents);
            var result = new CourseAssignment();
            result.Students = enrolledStudents;
            result.CourseId = courseId;
            result.ProfessorId = professorId;
            return result;
        }

        public void EnrollStudent(Student student)
        {
            Guard.IsStudentNull(student);
            this.Students.Add(student);
        }
    }
}
