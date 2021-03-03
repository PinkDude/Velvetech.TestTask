using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Velvetech.TestTask.Data.Context;
using Velvetech.TestTask.Domain.Abstractions;

namespace Velvetech.TestTask.Data.EfRepository
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        protected readonly TestTaskContext DbContext;

        public EfRepository(TestTaskContext context)
        {
            DbContext = context;
        }

        public IQueryable<T> GetQuery()
        {
            return DbContext.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            DbContext.Set<T>().Add(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            DbContext.Set<T>().Update(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            await DbContext.SaveChangesAsync();
        }
    }
}
