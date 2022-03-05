using Microsoft.EntityFrameworkCore;
using StorekeeperDetails.EfStuff.DbModel;

namespace StorekeeperDetails.EfStuff
{
    public class WebContext : DbContext
    {
        public WebContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Detail>().HasOne(d => d.Keeper).WithMany(k => k.Details);

            modelBuilder.Entity<Detail>().Property(d => d.NomenCode).IsRequired();
            modelBuilder.Entity<Detail>().Property(d => d.Name).IsRequired();
            modelBuilder.Entity<Detail>().Property(d => d.DateCreated).IsRequired();
            modelBuilder.Entity<StoreKeeper>().Property(k => k.Name).IsRequired();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
