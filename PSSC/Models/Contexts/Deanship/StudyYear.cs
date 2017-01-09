using Models.Common.Subject;
using Models.Generics;
using Models.Generics.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Contexts.Deanship
{
    /*
     * Aggregate root
     * Deanship interacts with a list of 'DefinedSubjects'. It is able to:
     * 1. Define new subjects
     * 2. Enroll students to subjects
     * 3. View the subject situation for any student
     * 4. Calculate students average
     * 
     * !?TODO!?:
     * 1. Possibility to add students
     */
    public class StudyYear : Entity<Guid>
    {
        private HashSet<DefinedSubject> _definedSubjects;
        public ReadOnlyCollection<DefinedSubject> Subjects { get { return _definedSubjects.ToList().AsReadOnly(); } }

        private StudyYear(Guid id) : base(id)
        {
            Contract.Requires(id != null, "Guid is null!");
        }

        private StudyYear() : base(Guid.NewGuid())
        {

        }

        public StudyYear(Guid id, HashSet<DefinedSubject> definedSubjects) : this(id)
        {
            Contract.Requires(definedSubjects != null, "Defined subjects!");

            _definedSubjects = definedSubjects;
        }

        public StudyYear(HashSet<DefinedSubject> definedSubjects) : this()
        {
            Contract.Requires(definedSubjects != null, "Defined subjects!");

            _definedSubjects = definedSubjects;
        }

        public void DefineSubject(PlainText subjectName, Credits credits, Dictionary<Common.Student.Student, ViewableSituation> enrolledStudents,
            EvaluationType type, Common.Professor.Professor professor, Proportion prop)
        {
            Contract.Requires(prop != null, "Proportion is null!");
            Contract.Requires(professor != null, "Professor is null!");
            Contract.Requires(enrolledStudents != null, "Enrolled students list is null!");

            _definedSubjects.Add(new DefinedSubject(subjectName, credits, type, professor, prop, enrolledStudents));
        }

        public void DefineSubject(PlainText subjectName, Credits credits, Dictionary<Common.Student.Student, ViewableSituation> enrolledStudents,
            EvaluationType type, Common.Professor.Professor professor)
        {
            Contract.Requires(professor != null, "Professor is null!");
            Contract.Requires(enrolledStudents != null, "Enrolled students list is null!");

            _definedSubjects.Add(new DefinedSubject(subjectName, credits, type, professor, enrolledStudents));
        }

        public void EnrollStudentToSubject(PlainText subjectName, Common.Student.Student student)
        {
            Contract.Requires(subjectName != null, "Subject name is null!");
            Contract.Requires(student != null, "Student is null!");

            _definedSubjects.First(d => d.Name == subjectName).EnrollStudent(student);
        }

        public Grade CalculateStudentAverage(PlainText subjectName, RegistrationNumber regNumber)
        {
            Contract.Requires(subjectName != null, "Subject name is null!");
            Contract.Requires(regNumber != null, "Registration number is null!");

            return _definedSubjects.First(d => d.Name == subjectName).GetStudentAverage(regNumber);
        }

        public ViewableSituation GetStudentSituation(PlainText subjectName, RegistrationNumber regNumber)
        {
            Contract.Requires(subjectName != null, "Subject name is null!");
            Contract.Requires(regNumber != null, "Registration number is null!");

            return _definedSubjects.First(d => d.Name == subjectName).GetStudentSituation(regNumber);
        }
    }
}
