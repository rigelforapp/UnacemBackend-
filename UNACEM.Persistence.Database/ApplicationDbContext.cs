using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UNACEM.Domain;
using UNACEM.Persistence.Database.Configuration;

namespace UNACEM.Persistence.Database
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<UNACEM.Domain.BrickFormats> BrickFormats { get; set; }
        public DbSet<UNACEM.Domain.Tyres> Tyres { get; set; }
        public DbSet<UNACEM.Domain.Color> Color { get; set; }
        public DbSet<UNACEM.Domain.Headquarters> Headquarters { get; set; }
        public DbSet<UNACEM.Domain.Ovens> Ovens { get; set; }
        public DbSet<UNACEM.Domain.Users> Users { get; set; }
        public DbSet<UNACEM.Domain.Versions> Versions { get; set; }
        public DbSet<UNACEM.Domain.Budgets> Budgets { get; set; }
        public DbSet<UNACEM.Domain.BudgetCurrency> BudgetCurrency { get; set; }
        public DbSet<UNACEM.Domain.Stretchs> Stretchs { get; set; }
        public DbSet<UNACEM.Domain.Providers> Providers { get; set; }
        public DbSet<UNACEM.Domain.ProviderImportations> ProviderImportations { get; set; }
        public DbSet<UNACEM.Domain.ProviderBricks> ProviderBricks { get; set; }
        public DbSet<UNACEM.Domain.BudgetStretch> BudgetStretch { get; set; }
        public DbSet<UNACEM.Domain.Gallery> Gallery { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ModelConfig(builder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new BrickFormatsConfiguration(modelBuilder.Entity<UNACEM.Domain.BrickFormats>());
            new TyresConfiguration(modelBuilder.Entity<UNACEM.Domain.Tyres>());
            new ColorConfiguration(modelBuilder.Entity<UNACEM.Domain.Color>());
            new HeadquartersConfiguration(modelBuilder.Entity<UNACEM.Domain.Headquarters>());
            new OvensConfiguration(modelBuilder.Entity<UNACEM.Domain.Ovens>());
            new UsersConfiguration(modelBuilder.Entity<UNACEM.Domain.Users>());
            new VersionsConfiguration(modelBuilder.Entity<UNACEM.Domain.Versions>());
            new BudgetsConfiguration(modelBuilder.Entity<UNACEM.Domain.Budgets>());
            new BudgetCurrencyConfiguration(modelBuilder.Entity<UNACEM.Domain.BudgetCurrency>());
            new StretchsConfiguration(modelBuilder.Entity<UNACEM.Domain.Stretchs>());
            new ProvidersConfiguration(modelBuilder.Entity<UNACEM.Domain.Providers>());
            new ProviderImportationsConfiguration(modelBuilder.Entity<UNACEM.Domain.ProviderImportations>());
            new ProviderBricksConfiguration(modelBuilder.Entity<UNACEM.Domain.ProviderBricks>());
            new BudgetStretchConfiguration(modelBuilder.Entity<UNACEM.Domain.BudgetStretch>());
            new GalleryConfiguration(modelBuilder.Entity<UNACEM.Domain.Gallery>());
            
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            MakeAudit();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void MakeAudit()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(
                x => x.Entity is AuditFields
                && (x.State == EntityState.Added || x.State == EntityState.Modified));

            var now = DateTime.Now;

            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as AuditFields;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedBy = entity.CreatedBy;
                    entity.CreatedAt = now;
                }
                else
                {
                    entity.UpdatedAt = now;
                }

             
            }
        }
    }
}
