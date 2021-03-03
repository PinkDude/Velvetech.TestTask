using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Velvetech.TestTask.Data.Context;
using Velvetech.TestTask.Data.EfRepository;
using Velvetech.TestTask.Domain.Abstractions;

namespace Velvetech.TestTask.Data
{
    public static class Entry
    {
        public static IServiceCollection AddDataBase(
            this IServiceCollection serviceCollection,
            Action<DbContextOptionsBuilder> optionsAction = null)
        {
            serviceCollection.AddDbContext<TestTaskContext>(optionsAction)
                .AddScoped(typeof(IRepository<>), typeof(EfRepository<>))
                .AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            return serviceCollection;
        }
    }
}
