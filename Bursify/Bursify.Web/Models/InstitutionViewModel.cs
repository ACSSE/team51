
using Bursify.Data.EF.Entities.StudentUser;
using System.Collections.Generic;

namespace Bursify.Web.Models
{
    public class InstitutionViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Website { get; set; }

        public InstitutionViewModel()
        {
        }

        public InstitutionViewModel(Institution i)
        {
            MapSingleInstitution(i);
        }

        public InstitutionViewModel MapSingleInstitution(Institution institution)
        {
            ID = institution.ID;
            Name = institution.Name;
            Type = institution.Type;
            Website = institution.Website;
            return this;
        }

        public Institution ReverseMap()
        {
            return new Institution()
            {
                ID = this.ID,
                Name = this.Name,
                Type = this.Type,
                Website = this.Website
            };
        }

        public List<InstitutionViewModel> MapMultipleInstitutions(List<Institution> institutions)
        {
            List<InstitutionViewModel> institutionVm = new List<InstitutionViewModel>();
            foreach (var i in institutions)
            {
                InstitutionViewModel sVm = new InstitutionViewModel(i);
                institutionVm.Add(sVm);
            }
            return institutionVm;
        }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        