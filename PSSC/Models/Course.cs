using Models.Common;
using System;

namespace Models
{
    public class Course : Entity<Guid>
    {
        public Course(Guid id) : base(id)
        {
        }
        public Course() : base(Guid.NewGuid())
        {

        }

        public string Name { get; private set; }
        public Guid ProfessorId { get; private set; }
        public int Credits { get; private set; }
        public DateTimeRange Duration { get; set; }
    }
}
