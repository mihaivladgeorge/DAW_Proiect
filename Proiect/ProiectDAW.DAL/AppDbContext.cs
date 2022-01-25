using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProiectDAW.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDAW.DAL
{
    public class AppDbContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>,
        UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientInfo> ClientsInfo { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<ClientCar> ClientCar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>()
                .HasOne(x => x.ClientInfo)
                .WithOne(x => x.Client);

            modelBuilder.Entity<Manufacturer>()
                .HasMany(x => x.Cars)
                .WithOne(x => x.Manufacturer);

            modelBuilder.Entity<ClientCar>()
                .HasKey(x => new { x.ClientId, x.CarId });

            modelBuilder.Entity<ClientCar>()
                .HasOne<Client>(x => x.Client)
                .WithMany(x => x.ClientCar)
                .HasForeignKey(x => x.ClientId);

            modelBuilder.Entity<ClientCar>()
                .HasOne<Car>(x => x.Car)
                .WithMany(x => x.ClientCar)
                .HasForeignKey(x => x.CarId);
        }
    }
}
