using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Velvetech.TestTask.Contracts.Enums;

namespace Velvetech.TestTask.Contracts.Student.Models
{
    public class CreateStudentDto
    {
        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Required(ErrorMessage = "Фамилия обязательное поле!")]
        [MaxLength(40, ErrorMessage = "Максимальная длина фамилии - 40 символов!")]
        public string LastName { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [Required(ErrorMessage = "Имя обязательное поле!")]
        [MaxLength(40, ErrorMessage = "Максимальная длина имени - 40 символов!")]
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [MaxLength(60, ErrorMessage = "Максимальная длина отчества - 60 символов!")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Позывной
        /// </summary>
        [MinLength(6, ErrorMessage = "Минимальная длина позывного 6 символов!")]
        [MaxLength(16, ErrorMessage = "Максимальная длина позывного 16 символов")]
        public string Callsign { get; set; }
    }
}
