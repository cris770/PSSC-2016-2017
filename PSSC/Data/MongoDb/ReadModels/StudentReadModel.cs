using System;

namespace Data.MongoDb.ReadModels
{
    public class StudentReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int StudyYear { get; set; }

    }
}
