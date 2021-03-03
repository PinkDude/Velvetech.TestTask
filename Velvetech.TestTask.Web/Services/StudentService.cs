using CodeJam.Strings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Velvetech.TestTask.Contracts.Common;
using Velvetech.TestTask.Contracts.Student.Models;
using Velvetech.TestTask.Domain.Abstractions;
using Velvetech.TestTask.Domain.Entities;
using Velvetech.TestTask.Web.Services.Interfaces;

namespace Velvetech.TestTask.Web.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _uow;

        public StudentService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IReadOnlyList<StudentDto>> GetStudents(
            StudentFilterDto filter,
            PaginationDto pagination)
        {
            var students = await _uow.Students.GetQuery()
                .Include(student => student.StudentGroupRelations)
                    .ThenInclude(relation => relation.Group)
                .Where(student =>
                    (filter.Gender == null || student.Gender == filter.Gender)
                    && (filter.FIO.IsNullOrEmpty()
                        || student.LastName.ToUpper().Contains(filter.FIO.ToUpper())
                        || student.FirstName.ToUpper().Contains(filter.FIO.ToUpper())
                        || student.MiddleName.ToUpper().Contains(filter.FIO.ToUpper())
                       )
                    && (filter.Callsign.IsNullOrEmpty()
                        || student.Callsign.ToUpper().Contains(filter.Callsign.ToUpper())
                       )
                    && (filter.GroupName.IsNullOrEmpty()
                        || student.StudentGroupRelations
                            .Any(relation => relation.Group.Name.ToUpper().Contains(filter.GroupName.ToUpper()))
                       )
                    )
                .Skip(pagination.Skip)
                .Take(pagination.Take)
                .Select(student => new StudentDto
                {
                    Id = student.Id,
                    FIO = $"{student.LastName} {student.FirstName}{(student.MiddleName != null ? $" {student.MiddleName}" : "")}",
                    Gender = student.Gender,
                    Callsign = student.Callsign,
                    GroupNames = student.StudentGroupRelations
                        .Select(relation => relation.Group.Name)
                        .ToList()
                })
                .ToListAsync();

            return students;
        }

        public async Task CreateStudent(Student model)
            => await _uow.Students.CreateAsync(model);

        public async Task UpdateStudent(Guid studentId, Student model)
        {
            if (!await _uow.Students.GetQuery().AnyAsync(student => student.Id == studentId))
                throw new Exception("Не удалось найти такого студента!");

            model.Id = studentId;

            await _uow.Students.UpdateAsync(model);
        }

        public async Task RemoveStudent(Guid studentId)
        {
            var student = await _uow.Students.GetQuery()
                .FirstOrDefaultAsync(student => student.Id == studentId);
            if (student is null)
                throw new Exception("Не удалось найти такого студента!");

            await _uow.Students.RemoveAsync(student);
        }
    }
}
