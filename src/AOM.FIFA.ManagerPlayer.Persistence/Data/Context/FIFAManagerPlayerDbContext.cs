using AOM.FIFA.ManagerPlayer.Application.League.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Persistence.Data.Context
{
    public class FIFAManagerPlayerDbContext : DbContext
    {
        public FIFAManagerPlayerDbContext(DbContextOptions<FIFAManagerPlayerDbContext> options) : base(options)
        {

        }

        public DbSet<League> Leagues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {

        }
    }
}
