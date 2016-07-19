using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bursify.Data.User;

namespace Bursify.Data.EF.EntityMappings
{
    public class SubjectMapping : EntityTypeConfiguration<Subject>
    {
        public SubjectMapping()
        {
            this.ToTable("Subject", "dbo");

            this.HasKey(x => x.SubjectId);

            this.Property(x => x.SubjectId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            this.HasMany(x => x.StudentSubjects);

            this.HasMany(x => x.Requirements);
        }
    }
}
