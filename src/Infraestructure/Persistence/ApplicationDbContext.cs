
using ApplicationCore.Interfaces;
using Domain.Entities;
using Finbuckle.MultiTenant;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence
{
    public class ApplicationDbContext : BaseDbContext
    {
        public ApplicationDbContext(ITenantInfo currentTenant, DbContextOptions options, ICurrentUserService currentUser)
            : base(currentTenant, options, currentUser)
        {

        }
        public DbSet<cliente> clientes { get; set; }
        public DbSet<logs> logs { get; set; }

        //public DbSet<BranchOffice> BranchOffice => Set<BranchOffice>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
