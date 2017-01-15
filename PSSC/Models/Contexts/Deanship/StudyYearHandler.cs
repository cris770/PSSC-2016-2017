using EventSourcing.Handlers;
using EventSourcing.Persistence;
using Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models.Contexts.Deanship
{
    public class StudyYearHandler : ICommandHandler<CreateNewStudent>
    {
        private readonly IRepository _repo;
        public StudyYearHandler(IRepository repo)
        {
            this._repo = repo;
        }

        public void Handle(CreateNewStudent cmd)
        {
            Execute(cmd.StudentId, (sy) => sy.AddStudent(cmd.StudentId, cmd.Name, cmd.StudyYear));
        }

        private void Execute(Guid id, Action<StudyYear> action)
        {
           var studyYear = _repo.GetById<StudyYear>(id);
            action(studyYear);
            this._repo.Save(studyYear);
        }
    }
}
