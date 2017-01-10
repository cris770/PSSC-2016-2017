using Data.MongoDb.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.MongoDb
{
    public class MongoDb
    {
        private readonly Dictionary<Guid, StudentReadModel> students = new Dictionary<Guid, StudentReadModel>();

        public StudentReadModel GetStudentById(Guid id)
        {
            return this.students[id];
        }


        public void SaveStudent(StudentReadModel student)
        {
            if (!this.students.ContainsKey(student.Id))
            {
                this.students.Add(student.Id, student);
            }
            else
            {
                this.students[student.Id] = student;
            }
        }

        public void RemoveStudent(Guid studentId)
        {
            if (this.students.ContainsKey(studentId))
            {
                this.students.Remove(studentId);
            }
        }
    }
}
