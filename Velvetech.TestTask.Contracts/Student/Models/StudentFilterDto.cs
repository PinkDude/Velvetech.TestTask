using System;
using System.Collections.Generic;
using System.Text;
using Velvetech.TestTask.Contracts.Enums;

namespace Velvetech.TestTask.Contracts.Student.Models
{
    /// <summary>
    /// Модель для фильтрации студентов
    /// </summary>
    public class StudentFilterDto
    {
        /// <summary>
        /// ФИО
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public Gender? Gender { get; set; }

        /// <summary>
        /// Позывной
        /// </summary>
        public string Callsign { get; set; }

        /// <summary>
        /// Наименование группы
        /// </summary>
        public string GroupName { get; set; }
    }
}
