using System.Collections.Generic;
using Bursify.Data.EF.Entities.Bridge;
using Bursify.Data.EF.Entities.StudentUser;
using Bursify.Data.EF.Uow;

namespace Bursify.Data.EF.Repositories
{
    public class StudentSubjectRepository : BridgeRepository<StudentSubject>
    {
        public StudentSubjectRepository(DataSession dataSession) : base(dataSession)
        {
        }

    }
}