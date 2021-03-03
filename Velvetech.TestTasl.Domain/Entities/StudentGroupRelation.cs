using System;
using System.Collections.Generic;
using System.Text;

namespace Velvetech.TestTask.Domain.Entities
{
    public class StudentGroupRelation
    {
        /// <summary>
        /// Идентификатор студента
        /// </summary>
        public Guid StudentId { get; set; }

        /// <summary>
        /// Идентификатор группы
        /// </summary>
        public Guid GroupId { get; set; }

        public virtual Student Student { get; set; }

        public virtual Group Group { get; set; }
    }
}
