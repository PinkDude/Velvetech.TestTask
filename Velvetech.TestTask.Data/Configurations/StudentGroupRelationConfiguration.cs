using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Velvetech.TestTask.Domain.Entities;

namespace Velvetech.TestTask.Data.Configurations
{
    class StudentGroupRelationConfiguration : IEntityTypeConfiguration<StudentGroupRelation>
    {
        public void Configure(EntityTypeBuilder<StudentGroupRelation> builder)
        {
            builder.HasKey(c => new { c.StudentId, c.GroupId });
            builder.HasOne(c => c.Student)
                .WithMany(c => c.StudentGroupRelations)
                .HasForeignKey(c => c.StudentId);
            builder.HasOne(c => c.Group)
                .WithMany(c => c.StudentGroupRelations)
                .HasForeignKey(c => c.GroupId);
        }
    }
}
