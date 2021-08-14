using AutoMapper;
using Rusada.DTO;
using Rusada.Entity.Entities;
using Rusada.Repository.Interface;
using Rusada.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.Service.Implementation
{
    public class SightService : ISightService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public SightService(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public async Task<List<SightDetailsDto>> GetAllSightDetails()
        {
            var sightsEntity = await _unitofWork.SightRepository.GetAllSightDetails();
            return _mapper.Map<List<SightDetailsDto>>(sightsEntity);
        }

        public async Task<bool> AddUpdateSight(SightDetailsDto sightDto)
        {
            var sightEntity = _mapper.Map<SightDetails>(sightDto);
            bool result = await _unitofWork.SightRepository.AddUpdateSight(sightEntity);
            if (result)
            {
                return await _unitofWork.Complete();
            }
            else
            {
                return false;
            }
        }

        public async Task<SightDetailsDto> GetSightById(int Id)
        {
            var sightEntity = await _unitofWork.SightRepository.GetSightById(Id);
            return _mapper.Map<SightDetailsDto>(sightEntity);
        }

        public async Task<bool> DeleteSight(int Id)
        {
            await _unitofWork.SightRepository.DeleteSight(Id);
            return await _unitofWork.Complete();
        }
    }
}
