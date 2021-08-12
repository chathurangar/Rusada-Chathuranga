using Rasuda.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rasuda.Repository.Interface
{
    public interface ISightRepository
    {
        Task<List<SightDetails>> GetAllSightDetails();
        Task<int> InsertSight(SightDetails sight);
        Task<SightDetails> GetSightById(int Id);
        Task<ResponseObject> UpdateSight(SightDetails sight);
        Task<bool> DeleteSight(int Id);
    }
}
