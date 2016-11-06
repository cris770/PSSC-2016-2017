using Models.Common.Enums;

namespace Models.Common
{
    public class ExamGrade : Grade
    {
        public ExamGradeType Type { get; set; }
        public ExamGrade(decimal value, ExamGradeType type) : base(value)
        {
            this.Type = type;
        }
    }
}
