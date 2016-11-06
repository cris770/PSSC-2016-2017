using UniversityManagement.SharedKernel;

namespace Models.Common
{
    public class Attendance : ValueObject<Attendance>
    {
        private int _count;
        public int Count { get; internal set; }

        public Attendance(int count)
        {
            _count = count;
        }
    }
}
