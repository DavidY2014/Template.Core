using System;
using Microsoft.EntityFrameworkCore;
using Nba.Core.Models.Entites;

namespace Nba.Core.EntityFramework
{
    public partial class NbaCoreDbContext : DbContext
    {
        public NbaCoreDbContext(DbContextOptions<NbaCoreDbContext> options)
           : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserInfo> Users { get; set; }

        public DbSet<PredictResult> PredictResults { get; set; } 
    }
}
