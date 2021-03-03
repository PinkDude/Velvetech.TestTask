using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Velvetech.TestTask.Domain.Entities;

namespace Velvetech.TestTask.Data.Configurations
{
    class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Gender)
                .IsRequired();
            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(40);
            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(40);
            builder.Property(c => c.MiddleName)
                .HasMaxLength(60);
            builder.Property(c => c.Callsign)
                .HasMaxLength(16);

            builder.HasIndex(c => c.LastName);
            builder.HasIndex(c => c.FirstName);
            builder.HasIndex(c => c.MiddleName);
            builder.HasIndex(c => c.Callsign)
                .IsUnique();
        }
    }
}
