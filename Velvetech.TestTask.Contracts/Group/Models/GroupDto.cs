using System;
using System.Collections.Generic;
using System.Text;

namespace Velvetech.TestTask.Contracts.Group.Models
{
    public class GroupDto
    {
        /// <summary>
        /// Идентификатор группы
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование группы
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Количество студентов в группе
        /// </summary>
        public int StudentCount { get; set; }
    }
}
