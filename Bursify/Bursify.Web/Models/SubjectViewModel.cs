using Bursify.Data.EF.Entities.StudentUser;
using Bursify.Data.EF.Entities.User;

namespace Bursify.Web.Models
{
    public class SubjectViewModel
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }

        public SubjectViewModel(Subject subject)
        {
            SubjectId = subject.ID;
            Name = subject.Name;
        }
    }
}