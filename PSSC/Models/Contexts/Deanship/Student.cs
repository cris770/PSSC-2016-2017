using Models.Generics;
using System;

namespace Models.Contexts.Deanship
{
    public class Student : Entity<Guid>
    {
        public Student(Guid id) : base(id)
        {
        }

        public Student() : base(Guid.NewGuid())
        {
        }
        public string Name { get; set; }
        public int Year { get; set; }

    }
}
