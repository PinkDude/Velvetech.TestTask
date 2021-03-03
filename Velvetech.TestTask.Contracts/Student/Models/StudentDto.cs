using System;
using System.Collections.Generic;
using System.Text;
using Velvetech.TestTask.Contracts.Enums;

namespace Velvetech.TestTask.Contracts.Student.Models
{
    /// <summary>
    /// Модель студента
    /// </summary>
    public class StudentDto
    {
        /// <summary>
        /// Идентификатор студента
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Позывной
        /// </summary>
        public string Callsign { get; set; }

        /// <summary>
        /// Названия групп, в которых состоит студент
        /// </summary>
        public IReadOnlyList<string> GroupNames { get; set; }
    }
}
