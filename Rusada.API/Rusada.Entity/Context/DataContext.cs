using Microsoft.EntityFrameworkCore;
using Rusada.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rusada.Entity.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        { }

        public DbSet<SightDetails> SightDetails { get; set; }
    }
}
