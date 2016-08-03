
using Bursify.Data.EF.Entities.StudentUser;
using Bursify.Data.EF.Entities.User;
using System.Collections.Generic;
using System.Linq;

namespace Bursify.Web.Models
{
    public class InstitutionViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Website { get; set; }

        public Institution MapSingleInstitution(Institution institution)
        {
            return new Institution()
            {
                ID = institution.ID,
                Name = institution.Name,
                Type = institution.Type,
                Website = institution.Website
            };
        }

        public List<Institution> MapMultipleInstitutions(List<Institution> institutions)
        {
            return (from institution in institutions select MapSingleInstitution(institution)).ToList();
        }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        