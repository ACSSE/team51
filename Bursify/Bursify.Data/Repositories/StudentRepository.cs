using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Bursify.Data.EF.Repositories;
using Bursify.Entities.CampaignEntities;
using Bursify.Entities.StudentEntities;

namespace Bursify.Data.Repositories
{
    public class StudentRepository : Repository<Student>
    {
        public StudentRepository(DataSession dataSession) : base(dataSession)
        {
        }

        public Student GetAccount(int id)
        {
            throw new NotImplementedException();
        }

        public Campaign GetSIngleCampaign(int id)
        {
            var campaign = _context.CampaignSet
                .Include(x => x.Account).FirstOrDefault(x => x.CampaignId == id);

            return campaign;
        }

        public List<Campaign> GetAllCampaigns()
        {
            throw new NotImplementedException();
        }
    }
}
