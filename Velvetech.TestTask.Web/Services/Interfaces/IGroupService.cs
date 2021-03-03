using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Velvetech.TestTask.Contracts.Common;
using Velvetech.TestTask.Contracts.Group.Models;
using Velvetech.TestTask.Domain.Entities;

namespace Velvetech.TestTask.Web.Services.Interfaces
{
    public interface IGroupService
    {
        /// <summary>
        /// Получение групп
        /// </summary>
        /// <param name="filter"> Фильтр для поиска </param>
        /// <param name="pagination"> Пагинация </param>
        /// <returns></returns>
        Task<IReadOnlyList<GroupDto>> GetGroups(
            GroupFilterDto filter,
            PaginationDto pagination);

        /// <summary>
        /// Создание группы
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        Task CreateGroup(Group group);

        /// <summary>
        /// Обновление группы
        /// </summary>
        /// <param name="groupId"> Идеентификатор группы </param>
        /// <param name="group"> Новые данные </param>
        /// <returns></returns>
        Task UpdateGroup(Guid groupId, Group group);

        /// <summary>
        /// Удаление группы
        /// </summary>
        /// <param name="groupId"> Идентификатор группы </param>
        /// <returns></returns>
        Task RemoveGroup(Guid groupId);

        /// <summary>
        /// Добавление студента в группу
        /// </summary>
        /// <param name="groupId"> Идентификатор группы </param>
        /// <param name="studentId"> Идентификатор студента </param>
        /// <returns></returns>
        Task AddStudentInGroup(Guid groupId, Guid studentId);

        /// <summary>
        /// Удаление студента из группы
        /// </summary>
        /// <param name="groupId"> Идентификатор группы </param>
        /// <param name="studentId"> Идентификатор студента </param>
        /// <returns></returns>
        Task RemoveStudentFromGroup(Guid groupId, Guid studentId);
    }
}
