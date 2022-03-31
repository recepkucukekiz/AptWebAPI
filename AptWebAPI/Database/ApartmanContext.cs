using AptWebAPI.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace AptWebAPI.Database
{
    public class ApartmanContext : DbContext
    {

        public DbSet<Kiraci> Kiracis { get; set; }
        public DbSet<Aidat> Aidats { get; set; }
        public DbSet<Apartman> Apartmans { get; set; }
        public DbSet<Daire> Daires { get; set; }
        public DbSet<Yonetici> Yoneticis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server = aptsqlserver.database.windows.net; Database = ApartmanDB; User Id = recox; Password = Asdfdsa123+;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Yonetici>()
                .HasOne<Apartman>(y => y.Apartman)
                .WithOne(a => a.Yonetici)
                .HasForeignKey<Yonetici>(y => y.ApartmanId);

            modelBuilder.Entity<Daire>()
                .HasOne<Apartman>(d => d.Apartman)
                .WithMany(a => a.Daires)
                .HasForeignKey(d => d.ApartmanId);

            modelBuilder.Entity<Daire>()
                .HasOne<Kiraci>(d => d.Kiraci)
                .WithOne(k => k.Daire)
                .HasForeignKey<Daire>(d => d.KiraciId);

            modelBuilder.Entity<Aidat>()
                .HasOne<Daire>(a => a.Daire)
                .WithMany(d => d.AidatList)
                .HasForeignKey(a => a.DaireId);
        }
    }
}
