using Models.Generics;
using Models.Generics.ValueObjects;
using System.Diagnostics.Contracts;

namespace Models.Common.Subject
{
    /*
     * Basic subject scheleton - Name and credits
     */
    public abstract class Subject : Entity<PlainText>
    {
        public PlainText Name { get; internal set; }
        public Credits Credits { get; internal set; }

        public Subject(PlainText name, Credits credits) : base(name)
        {
            Contract.Requires(name != null, "Name is null!");
            Contract.Requires(credits != null, "Credits is null!");

            Name = name;
            Credits = credits;
        }
    }
}
