using Rasuda.DTO;
using Rasuda.Repository.Interface;
using Rasuda.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rasuda.Service.Implementation
{
    public class SightService : ISightService
    {
        private readonly ISightRepository _sightRepository;

        public SightService(ISightRepository sightRepository)
        {
            _sightRepository = sightRepository;
        }

        public async Task<List<SightDetails>> GetAllSightDetails()
        {
            return await _sightRepository.GetAllSightDetails();
        }

        public async Task<int> InsertSight(SightDetails sight)
        {
            return await _sightRepository.InsertSight(sight);
        }

        public async Task<SightDetails> GetSightById(int Id)
        {
            return await _sightRepository.GetSightById(Id);
        }        

        public async Task<ResponseObject> UpdateSight(SightDetails sight)
        {
            return await _sightRepository.UpdateSight(sight);
        }

        public async Task<bool> DeleteSight(int Id)
        {
            return await _sightRepository.DeleteSight(Id);
        }
    }
}
