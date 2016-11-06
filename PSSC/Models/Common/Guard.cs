using Models.Common.Exceptions;
using Models.CourseManagement;
using System;
using System.Collections.Generic;

namespace Models.Common
{
    public class Guard
    {
        public static void IsIdGuidEmpty(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new InvalidIdException("Id is not allowed to be an empty Guid");
            }
        }

        public static void IsEmpyStudentList(IList<Student> students)
        {
            if (students == null || students.Count == 0)
            {
                throw new InvalidStudentListException("Student list cannot be empty");
            }
        }

        public static void IsStudentNull(Student student)
        {
            if (student == null)
            {
                throw new InvalidStudentItemException("Student param cannot be null");
            }
        }

        public static void IsInvalidAttendenceValue(Attendance attendence)
        {
            if (attendence == null || attendence.Count < 0)
            {
                throw new InvalidAttendenceValueException("Attendence value should be greater than 0");
            }
        }

        public static void IsInvalidGrade(Grade grade)
        {
            if (grade == null || grade.Value < 0 || grade.Value > 10)
            {
                throw new InvalidGradeException("Grade value should be between 0 an 10");
            }
        }

        public static void IsInvalidGradeList(IList<ExamGrade> gradeList)
        {
            foreach (var grade in gradeList)
            {
                if (grade == null || grade.Value < 0 || grade.Value > 10)
                {
                    throw new InvalidGradeException("Grade value should be between 0 an 10");
                }

            }
        }
    }
}
