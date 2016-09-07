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

        public Subject GetSubject(int id)
        {
            return FindSingle(subject => subject.ID == id);
        }

        public List<Subject> GetSubjects()
        {
            return LoadAll();
        }

        public List<Subject> GetSubjects(int requirementId)
        {
            var subjects = FindMany(x => x.StudentReportId == requirementId);

            return subjects;
        }


    }
}