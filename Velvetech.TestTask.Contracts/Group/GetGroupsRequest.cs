using System;
using System.Collections.Generic;
using System.Text;
using Velvetech.TestTask.Contracts.Common;
using Velvetech.TestTask.Contracts.Group.Models;

namespace Velvetech.TestTask.Contracts.Group
{
    public class GetGroupsRequest
    {
        /// <summary>
        /// Фильтр
        /// </summary>
        public GroupFilterDto Filter { get; set; } = new GroupFilterDto();

        /// <summary>
        /// Пагинация
        /// </summary>
        public PaginationDto Pagination { get; set; } = new PaginationDto();
    }
}
