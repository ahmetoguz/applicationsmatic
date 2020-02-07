using Microsoft.EntityFrameworkCore;


namespace Smatic.Core.Entities
{
    public class SmaticAppDbContext : DbContext
    {
        public SmaticAppDbContext() { }

        public SmaticAppDbContext(DbContextOptions<SmaticAppDbContext> options)
            : base(options)
        { }


        public virtual DbSet<Event> Event { get; set; }

        public virtual DbSet<EventRoom> EventRoom { get; set; }

        public virtual DbSet<Participant> EventPartipicant { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=YAZILIM-PC1;initial catalog=EventDB;Trusted_Connection = True;");

                //Server = (localdb)\\mssqllocaldb; Database = EFGetStarted.ConsoleApp.NewDb; Trusted_Connection = True;

                //YAZILIM - PC1
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().HasOne<EventRoom>
                (s => s.EventRoom).
                WithMany(g => g.Events).
                HasForeignKey(g => g.EventRoomId);

            //many to many ilişki- ara tablo
            modelBuilder.Entity<Event_Partipicant>().
                HasKey(ep => new { ep.EventId, ep.PartipicantId });

            base.OnModelCreating(modelBuilder);
        }
    }
}



