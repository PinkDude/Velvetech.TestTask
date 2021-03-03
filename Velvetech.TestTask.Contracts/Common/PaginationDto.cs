using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Velvetech.TestTask.Contracts.Common
{
    public class PaginationDto
    {
        /// <summary>
        /// Количество элементов, которое нужно пропустить (min = 0, max = 2147483647)
        /// </summary>
        [Range(minimum: 0, maximum: int.MaxValue, ErrorMessage = "Значение 'Skip' должно быть в промежутке от 0 до 2147483647")]
        public int Skip { get; set; } = 0;

        /// <summary>
        /// Количество элементов, которое нужно взять (min = 1, max = 100)
        /// </summary>
        [Range(minimum: 1, maximum: 100, ErrorMessage = "Значение 'Take' должно быть в промежутке от 1 до 100")]
        public int Take { get; set; } = 10;
    }
}
