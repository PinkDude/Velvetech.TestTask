using System;
using System.Collections.Generic;
using System.Text;
using Velvetech.TestTask.Contracts.Enums;

namespace Velvetech.TestTask.Domain.Entities
{
    public class Student
    {
        /// <summary>
        /// Идентификатор студента
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Позывной
        /// </summary>
        public string Callsign { get; set; }

        public List<StudentGroupRelation> StudentGroupRelations { get; set; }
    }
}
