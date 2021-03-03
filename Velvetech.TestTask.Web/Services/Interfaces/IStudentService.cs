using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Velvetech.TestTask.Contracts.Common;
using Velvetech.TestTask.Contracts.Student.Models;
using Velvetech.TestTask.Domain.Entities;

namespace Velvetech.TestTask.Web.Services.Interfaces
{
    public interface IStudentService
    {
        /// <summary>
        /// Получение студентов
        /// </summary>
        /// <param name="filter"> Модель для фильтрации </param>
        /// <param name="pagination"> Модель пагинации </param>
        /// <returns></returns>
        Task<IReadOnlyList<StudentDto>> GetStudents(
            StudentFilterDto filter,
            PaginationDto pagination);

        /// <summary>
        /// Добавление нового студента
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task CreateStudent(Student model);

        /// <summary>
        /// Обновление данных студента
        /// </summary>
        /// <param name="studentId"> Идентификатор студента </param>
        /// <param name="model"> Новые данные </param>
        /// <returns></returns>
        Task UpdateStudent(Guid studentId, Student model);

        /// <summary>
        /// Удаление студента
        /// </summary>
        /// <param name="studentId"> Идентификатор студента </param>
        /// <returns></returns>
        Task RemoveStudent(Guid studentId);
    }
}
