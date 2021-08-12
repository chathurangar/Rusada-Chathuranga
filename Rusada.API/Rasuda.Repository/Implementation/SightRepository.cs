using Dapper;
using Microsoft.Extensions.Configuration;
using Rasuda.DTO;
using Rasuda.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rasuda.Repository.Implementation
{
    public class SightRepository : ISightRepository
    {
        private readonly IConfiguration _config;

        public SightRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DBConnection"));
            }
        }

        public async Task<List<SightDetails>> GetAllSightDetails()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT Id, Make, Model, Registration, Location, SightDate, PhotoFileName, RowVersion FROM [dbo].[SightDetails]";
                conn.Open();
                var result = await conn.QueryAsync<SightDetails>(sQuery);
                return result.ToList();
            }
        }

        public async Task<int> InsertSight(SightDetails sight)
        {
            const string sql = "INSERT INTO [dbo].[SightDetails] (Make, Model, Registration, Location, SightDate, PhotoFileName) " +
                               " OUTPUT inserted.id " +
                               "VALUES(@Make, @Model, @Registration, @Location, @SightDate, @PhotoFileName)";
            try
            {
                using (IDbConnection conn = Connection)
                {
                    var createdId = await Connection.ExecuteScalarAsync<int>(sql, new
                    {
                        Make = sight.Make,
                        Model = sight.Model,
                        Registration = sight.Registration,
                        Location = sight.Location,
                        SightDate = sight.SightDate,
                        PhotoFileName = sight.PhotoFileName
                    });
                    return createdId;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }

        public async Task<SightDetails> GetSightById(int Id)
        {
            using (IDbConnection conn = Connection)
            {
                string sql = "SELECT Id, Make, Model, Registration, Location, SightDate, PhotoFileName FROM [dbo].[SightDetails] WHERE Id = @ID";
                conn.Open();
                var result = await conn.QuerySingleOrDefaultAsync<SightDetails>(sql, new { ID = Id });
                return result;
            }
        }

        public async Task<ResponseObject> UpdateSight(SightDetails sight)
        {
            byte[] rowVersion;

            const string sql = "UPDATE [dbo].[SightDetails] " +
                               " SET Make = @Make, Model = @Model, Registration = @Registration, Location = @Location, SightDate = @SightDate, PhotoFileName = @PhotoFileName " +
                               " OUTPUT inserted.RowVersion " +
                               " WHERE Id = @Id AND RowVersion = @RowVersion";
            try {
                using (IDbConnection conn = Connection)
                {
                    rowVersion = await Connection.ExecuteScalarAsync<byte[]>(sql, new
                    {
                        Id = sight.Id,
                        Make = sight.Make,
                        Model = sight.Model,
                        Registration = sight.Registration,
                        Location = sight.Location,
                        SightDate = sight.SightDate,
                        PhotoFileName = sight.PhotoFileName,
                        RowVersion = sight.RowVersion
                    });
                    if (rowVersion == null)
                    {
                        throw new DBConcurrencyException("The sighting you were trying to edit has changed. Reload the list and try again.");
                    } else
                    {
                        return new ResponseObject { isSuccess = true, errorMessage = "" };
                    }
                }
            } 
            catch (Exception ex)
            {
                return new ResponseObject { isSuccess = false, errorMessage = ex.Message.ToString() };
            }
            
        }

        public async Task<bool> DeleteSight(int Id)
        {
            const string sql = "DELETE FROM [dbo].[SightDetails] WHERE Id = @Id";

            using (IDbConnection conn = Connection)
            {
                var rowsAffected = await Connection.ExecuteAsync(sql, new
                {
                    Id = Id
                });
                return true;
            }
        }
    }
}
