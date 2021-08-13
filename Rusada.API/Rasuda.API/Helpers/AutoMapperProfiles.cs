using AutoMapper;
using Rusada.DTO;
using Rusada.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rusada.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<SightDetails, SightDetailsDto>().ReverseMap();
        }
    }
}
