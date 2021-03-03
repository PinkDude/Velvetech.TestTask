using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Velvetech.TestTask.Contracts.Group;
using Velvetech.TestTask.Contracts.Group.Models;
using Velvetech.TestTask.Domain.Entities;
using Velvetech.TestTask.Web.Services.Interfaces;

namespace Velvetech.TestTask.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;

        public GroupController(
            IGroupService groupService,
            IMapper mapper)
        {
            _groupService = groupService;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение групп
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("groups")]
        public async Task<IReadOnlyList<GroupDto>> GetGroups([FromQuery] GetGroupsRequest request)
        {
            var groups = await _groupService.GetGroups(request.Filter, request.Pagination);

            return groups;
        }

        /// <summary>
        /// Создание новой группы
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("groups")]
        public async Task<ActionResult> CreateGroup([FromBody] CreateGroupDto model)
        {
            var group = _mapper.Map<Group>(model);
            await _groupService.CreateGroup(group);

            return Ok();
        }

        /// <summary>
        /// Обновление данных о группе
        /// </summary>
        /// <param name="groupId"> Идентификатор группы </param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("groups/{groupId}")]
        public async Task<ActionResult> UpdateGroup(
            [FromRoute] Guid groupId,
            [FromBody] CreateGroupDto model)
        {
            var group = _mapper.Map<Group>(model);
            await _groupService.UpdateGroup(groupId, group);

            return Ok();
        }

        /// <summary>
        /// Удаление группы
        /// </summary>
        /// <param name="groupId"> Идентификатор группы </param>
        /// <returns></returns>
        [HttpDelete("groups/{groupId}")]
        public async Task<ActionResult> RemoveGroup([FromRoute] Guid groupId)
        {
            await _groupService.RemoveGroup(groupId);

            return Ok();
        }

        /// <summary>
        /// Добавление студента в группу
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpPost("groups/{groupId}")]
        public async Task<ActionResult> AddStudentInGroup([FromRoute] Guid groupId, [FromQuery] Guid studentId)
        {
            await _groupService.AddStudentInGroup(groupId, studentId);

            return Ok();
        }

        /// <summary>
        /// Удаление студента из группы
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpDelete("groups/{groupId}/{studentId}")]
        public async Task<ActionResult> RemoveStudentFromGroup([FromRoute] Guid groupId, [FromRoute] Guid studentId)
        {
            await _groupService.RemoveStudentFromGroup(groupId, studentId);

            return Ok();
        }
    }
}
