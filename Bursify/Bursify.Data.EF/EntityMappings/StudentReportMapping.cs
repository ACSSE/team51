﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bursify.Data.EF.Entities.User;

namespace Bursify.Data.EF.EntityMappings
{
    public class StudentReportMapping : EntityTypeConfiguration<StudentReport>
    {
        public StudentReportMapping()
        {
            this.ToTable("StudentReport", "dbo");

            this.HasKey(x => x.ID);

            this.Property(x => x.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.StudentId)
                .IsRequired();

            this.Property(x => x.Average)
                .IsOptional();

            this.Property(x => x.ReportLevel)
                .IsOptional();

            this.Property(x => x.ReportPeriod)
                .IsOptional();

            this.HasRequired(x => x.Student)
                .WithMany(x => x.StudentReports)
                .HasForeignKey(x => x.StudentId);

            this.HasMany(x => x.Subjects)
                .WithRequired(x => x.Report)
                .HasForeignKey(x => x.RequirementId);
        }
    }
}
