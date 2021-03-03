using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Velvetech.TestTask.Domain.Entities;

namespace Velvetech.TestTask.Data.Context
{
    public class TestTaskContext : DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<StudentGroupRelation> StudentGroupRelations { get; set; }

        public TestTaskContext()
        {
        }

        public TestTaskContext(DbContextOptions<TestTaskContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TestTaskContext).Assembly);
        }
    }
}
