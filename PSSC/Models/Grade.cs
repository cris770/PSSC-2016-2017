using Models.Common;
using Models.Enums;
using System;

namespace Models
{
    public class Grade : Entity<Guid>
    {
        public Grade(float gradeValue, GradeType type, DateTime examDate):this()
        {
            this.Type = type;
            this.Value = gradeValue;
            this.ExamDate = examDate;
        }
        public Grade(Guid id) : base(id)
        {
        }

        public Grade() : base(Guid.NewGuid())
        {
        }
        public GradeType Type { get; private set; }
        public float Value { get; private set; }
        public DateTime ExamDate { get; set; }
    }
}
