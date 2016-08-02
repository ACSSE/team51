using Bursify.Data.EF.Entities.StudentUser;
using Bursify.Data.EF.Entities.User;

namespace Bursify.Web.Models
{
    public class InstitutionViewModel
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Website { get; set; }

        public InstitutionViewModel(Institution institution)
        {
            StudentId = institution.ID;
            Name = institution.Name;
            Type = institution.Type;
            Website = institution.Website;
        }
    }
}