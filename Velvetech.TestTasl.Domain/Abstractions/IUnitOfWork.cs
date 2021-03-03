using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Velvetech.TestTask.Domain.Entities;

namespace Velvetech.TestTask.Domain.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Student> Students { get; }

        IRepository<Group> Groups { get; }

        IRepository<StudentGroupRelation> StudentGroupRelations { get; }

        Task<int> SaveAsync();
    }
}
