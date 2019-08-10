using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SmartChurch.DataModel.Models.Core;
using SmartChurch.Services.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SmartChurch.DataAccess
{
    public sealed partial class SiriusDbContext : IdentityDbContext
    {
        private UserResolverService UserResolverService { get; }

        public SiriusDbContext(DbContextOptions options, UserResolverService userResolverService)
            : base(options)
        {
            UserResolverService = userResolverService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            RenameIdentityTables(modelBuilder);
            CreateMultiColumnConstraints(modelBuilder);
            ConfigureManyToManyRelationships(modelBuilder);
        }

        private static void RenameIdentityTables(ModelBuilder modelBuilder)
        {
        }

        public override int SaveChanges()
        {
            ApplyAuditInformation();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ApplyAuditInformation();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ApplyAuditInformation()
        {
            var addedEntities = ChangeTracker.Entries<SiriusDeletableEntity>()
                .Where(e => e.State == EntityState.Added);
            foreach (var entity in addedEntities)
            {
                entity.Entity.CreationUser = UserResolverService.GetUser();
                entity.Entity.CreationDate = DateTime.UtcNow;
                entity.Entity.ModificationUser = UserResolverService.GetUser();
                entity.Entity.ModificationDate = DateTime.UtcNow;
                entity.Entity.IsDeleted = false;
            }

            var modifiedEntities = ChangeTracker.Entries<SiriusEntity>()
                .Where(e => e.State == EntityState.Modified);
            foreach (var entity in modifiedEntities)
            {
                entity.Entity.ModificationUser= UserResolverService.GetUser();
                entity.Entity.ModificationDate= DateTime.UtcNow;
            }

            var deletedEntities = ChangeTracker.Entries<SiriusDeletableEntity>()
                .Where(e => e.State == EntityState.Deleted);
            foreach (var entity in deletedEntities)
            {
                if (!entity.Entity.IsDeleted)
                {
                    entity.Entity.IsDeleted = true;
                    entity.State = EntityState.Modified;
                }
            }
        }

        private static void CreateMultiColumnConstraints(ModelBuilder modelBuilder)
        {
            
        }

        private static void ConfigureManyToManyRelationships(ModelBuilder modelBuilder)
        {
            
        }
    }
}