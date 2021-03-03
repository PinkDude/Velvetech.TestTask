using CodeJam.Strings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Velvetech.TestTask.Contracts.Common;
using Velvetech.TestTask.Contracts.Group.Models;
using Velvetech.TestTask.Domain.Abstractions;
using Velvetech.TestTask.Domain.Entities;
using Velvetech.TestTask.Web.Services.Interfaces;

namespace Velvetech.TestTask.Web.Services
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _uow;

        public GroupService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IReadOnlyList<GroupDto>> GetGroups(
            GroupFilterDto filter,
            PaginationDto pagination)
        {
            var groups = await _uow.Groups.GetQuery()
                .Include(group => group.StudentGroupRelations)
                .Where(group => 
                    filter.Name.IsNullOrEmpty() || group.Name.ToUpper().Contains(filter.Name.ToUpper())
                    )
                .Skip(pagination.Skip)
                .Take(pagination.Take)
                .Select(group => new GroupDto
                {
                    Id = group.Id,
                    Name = group.Name,
                    StudentCount = group.StudentGroupRelations.Count
                })
                .ToListAsync();

            return groups;
        }

        public async Task CreateGroup(Group group)
            => await _uow.Groups.CreateAsync(group);

        public async Task UpdateGroup(Guid groupId, Group group)
        {
            if (!await _uow.Groups.GetQuery().AnyAsync(group => group.Id == groupId))
                throw new Exception("Не удалось найти данную группу!");

            group.Id = groupId;

            await _uow.Groups.UpdateAsync(group);
        }

        public async Task RemoveGroup(Guid groupId)
        {
            var group = await _uow.Groups.GetQuery()
                .FirstOrDefaultAsync(group => group.Id == groupId);
            if(group is null)
                throw new Exception("Не удалось найти данную группу!");

            await _uow.Groups.RemoveAsync(group);
        }

        public async Task AddStudentInGroup(Guid groupId, Guid studentId)
        {
            if (!await _uow.Groups.GetQuery().AnyAsync(group => group.Id == groupId))
                throw new Exception("Не удалось найти данную группу!");

            if (!await _uow.Students.GetQuery().AnyAsync(student => student.Id == studentId))
                throw new Exception("Не удалось найти данного студента!");

            var studentInGroup = await _uow.StudentGroupRelations.GetQuery()
                .AnyAsync(relation => relation.GroupId == groupId
                    && relation.StudentId == studentId);
            if (studentInGroup)
                throw new Exception("Данный студент уже находится в этой группе!");

            var relation = new StudentGroupRelation
            {
                GroupId = groupId,
                StudentId = studentId
            };

            await _uow.StudentGroupRelations.CreateAsync(relation);
        }

        public async Task RemoveStudentFromGroup(Guid groupId, Guid studentId)
        {
            if (!await _uow.Groups.GetQuery().AnyAsync(group => group.Id == groupId))
                throw new Exception("Не удалось найти данную группу!");

            if (!await _uow.Students.GetQuery().AnyAsync(student => student.Id == studentId))
                throw new Exception("Не удалось найти данного студента!");

            var studentInGroup = await _uow.StudentGroupRelations.GetQuery()
                .AnyAsync(relation => relation.GroupId == groupId
                    && relation.StudentId == studentId);
            if (!studentInGroup)
                throw new Exception("В этой группе нет такого студента!");

            var relation = new StudentGroupRelation
            {
                GroupId = groupId,
                StudentId = studentId
            };

            await _uow.StudentGroupRelations.RemoveAsync(relation);
        }
    }
}
