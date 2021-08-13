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
        private readonly ISightRepository _sightRepository;
        private readonly IMapper _mapper;

        public SightService(ISightRepository sightRepository, IMapper mapper)
        {
            _sightRepository = sightRepository;
            _mapper = mapper;
        }

        public async Task<List<SightDetailsDto>> GetAllSightDetails()
        {
            var sightsEntity = await _sightRepository.GetAllSightDetails();
            return _mapper.Map<List<SightDetailsDto>>(sightsEntity);
        }

        public async Task<int> InsertSight(SightDetailsDto sightDto)
        {
            var sightEntity = _mapper.Map<SightDetails>(sightDto);
           return await _sightRepository.InsertSight(sightEntity);

        }

        public async Task<SightDetailsDto> GetSightById(int Id)
        {
            var sightEntity = await _sightRepository.GetSightById(Id);
            return _mapper.Map<SightDetailsDto>(sightEntity);
        }        

        public async Task<bool> UpdateSight(SightDetailsDto sightDto)
        {
            var sightEntity = _mapper.Map<SightDetails>(sightDto);
            return await _sightRepository.UpdateSight(sightEntity);
        }

        public async Task<bool> DeleteSight(int Id)
        {
            return await _sightRepository.DeleteSight(Id);
        }
    }
}
