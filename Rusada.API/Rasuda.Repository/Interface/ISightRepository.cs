using Rusada.DTO;
using Rusada.Entity;
using Rusada.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.Repository.Interface
{
    public interface ISightRepository
    {
        Task<List<SightDetails>> GetAllSightDetails();
        Task<bool> AddUpdateSight(SightDetails sight);
        Task<SightDetails> GetSightById(int Id);
        Task<bool> DeleteSight(int Id);
    }
}
