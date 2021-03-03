using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Velvetech.TestTask.Contracts.Group.Models;
using Velvetech.TestTask.Contracts.Student.Models;
using Velvetech.TestTask.Domain.Entities;

namespace Velvetech.TestTask.Web.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Students

            CreateMap<CreateStudentDto, Student>();

            #endregion

            #region Groups

            CreateMap<CreateGroupDto, Group>();

            #endregion
        }
    }
}
