using API.Minimal.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Minimal.Infrastructre
{
    public class MinimalDB : DbContext
    {
        public DbSet<Usuarios> Usuarios => Set<Usuarios>();
        public DbSet<StateCodes> CodeStates => Set<StateCodes>();
        public MinimalDB(DbContextOptions<MinimalDB> dbContext) : base(dbContext)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<StateCodes>( entity =>
            //{
            //    entity.Property(property => property.Id);
            //});
            base.OnModelCreating(modelBuilder);
        }
    }
}
