using Domain.Models;
using Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AbsanteeContext : DbContext
    {
        public virtual DbSet<SpecialityDataModel> Specialities { get; set; }
        //public virtual DbSet<SpecialityTemporaryDataModel> SpecialityTemporaries { get; set; }
        public virtual DbSet<CollaboratorDataModel> Collaborators { get; set; }
        public virtual DbSet<TechnologyDataModel> Technologies { get; set; }


        public AbsanteeContext(DbContextOptions<AbsanteeContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpecialityDataModel>().OwnsOne(a => a.PeriodDate);
            modelBuilder.Entity<CollaboratorDataModel>();

            //modelBuilder.Entity<SpecialityTemporaryDataModel>().OwnsOne(a => a.PeriodDate);

            base.OnModelCreating(modelBuilder);
        }
    }
}