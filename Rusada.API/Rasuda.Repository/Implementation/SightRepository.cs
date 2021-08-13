using Microsoft.EntityFrameworkCore;
using Rusada.DTO;
using Rusada.Entity;
using Rusada.Entity.Context;
using Rusada.Entity.Entities;
using Rusada.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.Repository.Implementation
{
    public class SightRepository : ISightRepository
    {
        private readonly DataContext _context;

        public SightRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<SightDetails>> GetAllSightDetails()
        {
            return await _context.SightDetails.ToListAsync();
        }

        public async Task<SightDetails> GetSightById(int Id)
        {
            return await _context.SightDetails.FindAsync(Id);
        }

        public async Task<int> InsertSight(SightDetails sight)
        {
            sight.Created = DateTime.Now;
            sight.CreatedBy = UserConstants.userId;
            _context.SightDetails.Add(sight);
            await _context.SaveChangesAsync();
            return sight.Id;
        }

        public async Task<bool> UpdateSight(SightDetails sight)
        {
            //var sightEntity = await _context.SightDetails.FindAsync(sight.Id);
            var sightEntity = await _context.SightDetails.FirstOrDefaultAsync<SightDetails>(x => x.Id == sight.Id && x.RowVersion == sight.RowVersion);

            if (sightEntity == null)
            {
                return false;
            }

            sightEntity.Make = sight.Make;
            sightEntity.Model = sight.Model;
            sightEntity.Registration = sight.Registration;
            sightEntity.Location = sight.Location;
            sightEntity.SightDate = sight.SightDate;
            sightEntity.PhotoFileName = sight.PhotoFileName;
            sightEntity.Modified = DateTime.Now;
            sightEntity.ModifiedBy = UserConstants.userId;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteSight(int Id)
        {
            var sightEntity = await _context.SightDetails.FindAsync(Id);

            if(sightEntity == null)
            {
                return false;
            }
            _context.SightDetails.Remove(sightEntity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
