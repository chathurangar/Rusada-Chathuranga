using Rusada.DTO;
using Rusada.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.Service.Interface
{
    public interface ISightService
    {
        Task<List<SightDetailsDto>> GetAllSightDetails();
        Task<SightDetailsDto> GetSightById(int Id);
        Task<bool> AddUpdateSight(SightDetailsDto sight);
        Task<bool> DeleteSight(int Id);
    }
}
