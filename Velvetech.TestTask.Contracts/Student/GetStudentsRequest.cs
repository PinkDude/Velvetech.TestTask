using System;
using System.Collections.Generic;
using System.Text;
using Velvetech.TestTask.Contracts.Common;
using Velvetech.TestTask.Contracts.Student.Models;

namespace Velvetech.TestTask.Contracts.Student
{
    public class GetStudentsRequest
    {
        /// <summary>
        /// Фильтр
        /// </summary>
        public StudentFilterDto Filter { get; set; } = new StudentFilterDto();

        /// <summary>
        /// Пагинация
        /// </summary>
        public PaginationDto Pagination { get; set; } = new PaginationDto();
    }
}
