using BurgerApp.Domain.Enums;
using BurgerApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DataAccess.DataContext
{
    public class BurgerAppDbContext : DbContext
    {
        public BurgerAppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Burger> Burgers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasMany(x => x.BurgerOrders)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);

            modelBuilder.Entity<Burger>()
                .HasMany(x => x.BurgerOrders)
                .WithOne(x => x.Burger)
                .HasForeignKey(x => x.BurgerId);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Orders)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Burger>()
                .HasData(new Burger
                {
                    Id = 1,
                    IsOnPromotion = false,
                    Name = "Cheeseburger"
                },
                new Burger
                {
                    Id = 2,
                    IsOnPromotion = true,
                    Name = "BigMac"
                },
                new Burger
                {
                    Id = 3,
                    IsOnPromotion = true,
                    Name = "Vegeterian"
                },
                new Burger
                {
                    Id = 4,
                    IsOnPromotion = false,
                    Name = "Hamburger"
                });

            modelBuilder.Entity<User>()
                .HasData(
                new User()
                {
                    Id = 1,
                    Address = "Rekord Skopje",
                    FirstName = "Stojan",
                    LastName = "Stojanovski"
                },
               new User()
               {
                   Id = 2,
                   Address = "Drzava Aerodrom",
                   FirstName = "Kate",
                   LastName = "Katerinska"
               });

            modelBuilder.Entity<Order>()
                .HasData(
                new Order()
                {
                    Id = 1,
                    IsDelivered = false,
                    Name = "Cheeseburger",
                    PaymentMethod = PaymentMethod.Cash,
                    Address = "Taftalidze",
                    Location = "Centar",
                    UserId = 2
                },
                new Order()
                {
                    Id = 2,
                    IsDelivered = true,
                    Name = "Vegeterian",
                    PaymentMethod = PaymentMethod.Card,
                    Address = "Nerezi",
                    Location = "Taftalidze",
                    UserId = 1
                });

            modelBuilder.Entity<BurgerOrder>()
                .HasData(
                new BurgerOrder()
                {
                    Id = 1,
                    OrderId = 1,
                    BurgerId = 1,
                },
                new BurgerOrder()
                {
                    Id = 2,
                    OrderId = 1,
                    BurgerId = 2,
                },
                new BurgerOrder()
                {
                    Id = 3,
                    OrderId = 2,
                    BurgerId = 3,
                });
        }
    }
}
