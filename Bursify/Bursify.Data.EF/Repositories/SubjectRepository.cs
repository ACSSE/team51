using System;
using System.Collections.Generic;
using Bursify.Data.EF.Entities.StudentUser;
using Bursify.Data.EF.Entities.User;
using Bursify.Data.EF.Uow;

namespace Bursify.Data.EF.Repositories
{
    public class SubjectRepository : Repository<Subject>
    {
        public SubjectRepository(DataSession dataSession) : base(dataSession)
        {
        }

        public List<Subject> GetSubjects(string subjectLevel)
        {
            var subjects = FindMany(subject => subject.SubjectLevel.Equals(subjectLevel, StringComparison.OrdinalIgnoreCase));

            return subjects;
        }
    }
}