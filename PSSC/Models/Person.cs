using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Person :Entity<Guid>
    {
        public Person(Guid id) : base(id)
        {
        }

        public Person():base(Guid.NewGuid())
        {

        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        protected bool CreatePerson(string firstName, string lastName)
        {
            var result = false;
            return result;
        }
    }
}
