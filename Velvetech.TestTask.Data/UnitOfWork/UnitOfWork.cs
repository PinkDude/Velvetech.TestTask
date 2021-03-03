using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Velvetech.TestTask.Data.Context;
using Velvetech.TestTask.Data.EfRepository;
using Velvetech.TestTask.Domain.Abstractions;
using Velvetech.TestTask.Domain.Entities;

namespace Velvetech.TestTask.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Student> Students { get; private set; }

        public IRepository<Group> Groups { get; private set; }

        public IRepository<StudentGroupRelation> StudentGroupRelations { get; private set; }

        private readonly TestTaskContext _context;

        public UnitOfWork(TestTaskContext context)
        {
            _context = context;

            Students = new EfRepository<Student>(_context);
            Groups = new EfRepository<Group>(_context);
            StudentGroupRelations = new EfRepository<StudentGroupRelation>(_context);
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
