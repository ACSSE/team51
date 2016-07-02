using Bursify.Data.StudentUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bursify.Data.EF.User
{
    public class Institution : IEntity
    {
        public int InstitutionId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int StudentId { get; set; }
        public Student StudentUser { get; set; }
        public int Id
        {
            get{ return InstitutionId; }
        }
    }
}
