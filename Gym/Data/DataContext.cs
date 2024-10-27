using Gym.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gym.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Training> Trainings { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<UserMembership> UserMemberships { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Reservation>(eb =>
            {
                eb.HasOne(r => r.User)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.UserId);

                eb.HasOne(r => r.Training)
                .WithMany(t => t.Reservations)
                .HasForeignKey(t => t.TrainingId);

                eb.Property(x => x.Id).ValueGeneratedOnAdd();
                eb.Property(x => x.ReservationDate).HasColumnType("date");
                
            });

            builder.Entity<Training>(eb =>
            {
                eb.HasOne(tr => tr.Trainer)
                .WithMany(t => t.Trainings)
                .HasForeignKey(tr => tr.TrainerId);

                eb.Property(x => x.Id).ValueGeneratedOnAdd();
                eb.Property(x => x.Name).HasColumnType("varchar(255)");
                eb.Property(x => x.Description).HasColumnType("varchar(255)");
                eb.Property(x => x.StartDate).HasColumnType("date");
                eb.Property(x => x.Duration).HasColumnType("int");
            });

            builder.Entity<Trainer>(eb =>
            {
                eb.Property(x => x.Id).ValueGeneratedOnAdd();
                eb.Property(x => x.FirstName).HasColumnType("varchar(255)");
                eb.Property(x => x.LastName).HasColumnType("varchar(255)");
                eb.Property(x => x.Bio).HasColumnType("varchar(255)");

            });

            builder.Entity<Membership>(eb =>
            {
                eb.Property(x => x.Id).ValueGeneratedOnAdd();
                eb.Property(x => x.Name).HasColumnType("varchar(255)");
                eb.Property(x => x.PricePerMonth).HasColumnType("decimal(10,2)");

            });

            builder.Entity<UserMembership>(eb =>
            {
                eb.Property(x => x.userId).HasColumnType("varchar(255)");
                eb.Property(x => x.MembershipId).HasColumnType("int");
            });



        }


    }
}
