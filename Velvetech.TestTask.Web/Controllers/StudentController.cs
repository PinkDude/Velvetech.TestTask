using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Velvetech.TestTask.Contracts.Student;
using Velvetech.TestTask.Contracts.Student.Models;
using Velvetech.TestTask.Domain.Entities;
using Velvetech.TestTask.Web.Services.Interfaces;

namespace Velvetech.TestTask.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentController(
            IStudentService studentService,
            IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение студентов
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("students")]
        public async Task<IReadOnlyList<StudentDto>> GetStudents([FromQuery] GetStudentsRequest request)
        {
            var students = await _studentService.GetStudents(request.Filter, request.Pagination);

            return students;
        }

        /// <summary>
        /// Создание нового студента
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("students")]
        public async Task<ActionResult> CreateStudent([FromBody] CreateStudentDto model)
        {
            var student = _mapper.Map<Student>(model);
            await _studentService.CreateStudent(student);

            return Ok();
        }

        /// <summary>
        /// Обновление данных стуента
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("students/{studentId}")]
        public async Task<ActionResult> UpdateStudent(
            [FromRoute] Guid studentId,
            [FromBody] CreateStudentDto model)
        {
            var student = _mapper.Map<Student>(model);
            await _studentService.UpdateStudent(studentId, student);

            return Ok();
        }

        [HttpDelete("students/{studentId}")]
        public async Task<ActionResult> RemoveStudent([FromRoute] Guid studentId)
        {
            await _studentService.RemoveStudent(studentId);

            return Ok();
        }
    }
}
