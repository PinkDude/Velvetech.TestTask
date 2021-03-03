using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Velvetech.TestTask.Domain.Abstractions
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Получить проекцию сущности
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetQuery();

        /// <summary>
        /// Создать сущность в бд
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task CreateAsync(T entity);

        /// <summary>
        /// Обновить сущность в бд
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Удалить сущность из бд
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task RemoveAsync(T entity);
    }
}
