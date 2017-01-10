using Data.MongoDb.ReadModels;
using EventSourcing.Handlers;
using Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.MongoDb
{
    public class StudyYearEventHandler : IEventHandler<StudentCreated>
    {
        private readonly MongoDb db;

        public StudyYearEventHandler(MongoDb db)
        {
            this.db = db;
        }
        public void Handle(StudentCreated evt)
        {
            var newStudent = new StudentReadModel
            {
                Id=evt.StudentId,
                Name=evt.Name,
                StudyYear=evt.StudyYear
            };
            db.SaveStudent(newStudent);
        }
    }
}
