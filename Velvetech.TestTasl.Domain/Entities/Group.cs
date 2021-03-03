using System;
using System.Collections.Generic;
using System.Text;

namespace Velvetech.TestTask.Domain.Entities
{
    public class Group
    {
        /// <summary>
        /// Идентификаторк группы
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование группы
        /// </summary>
        public string Name { get; set; }

        public List<StudentGroupRelation> StudentGroupRelations { get; set; }
    }
}
