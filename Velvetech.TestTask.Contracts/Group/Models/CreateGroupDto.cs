using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Velvetech.TestTask.Contracts.Group.Models
{
    public class CreateGroupDto
    {
        /// <summary>
        /// Наименование группы
        /// </summary>
        [Required(ErrorMessage = "Наименование группы - обязательное поле!")]
        [MaxLength(25, ErrorMessage = "Максимальная длина наименования группы 25 символов")]
        public string Name { get; set; }
    }
}
