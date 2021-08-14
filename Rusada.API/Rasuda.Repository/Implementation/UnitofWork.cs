using Rusada.Entity.Context;
using Rusada.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.Repository.Implementation
{
    public class UnitofWork : IUnitofWork
    {
        private readonly DataContext _context;

        public UnitofWork(DataContext context)
        {
            _context = context;
        }
        public ISightRepository SightRepository => new SightRepository(_context);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
