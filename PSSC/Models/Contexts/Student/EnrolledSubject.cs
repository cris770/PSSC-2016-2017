using Models.Common.Subject;
using Models.Generics.ValueObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Contexts.Student
{
    /*
     * Entity
     * An EnrolledSubject is a class that describes:
     * 1. The students current subject situation
     * 2. The subject's professor
     */
    public class EnrolledSubject : Subject
    {
        public Common.Professor.Professor Professor { get; set; }
        public ViewableSituation Situation { get; set; }

        public EnrolledSubject(PlainText subjectName, Credits credits, ViewableSituation situation, Common.Professor.Professor professor)
            : base(subjectName, credits)
        {
            Contract.Requires(situation != null, "Viewable situation is null!");
            Contract.Requires(professor != null, "Professor is null!");

            Situation = situation;
            Professor = professor;
        }
    }
}
