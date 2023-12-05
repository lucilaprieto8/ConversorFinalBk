using ConversorFinalBk.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace ConversorFinal_BE.Data
{
    public class ConversorContext : DbContext 
    {
        public DbSet<User> User { get; set; }
        public DbSet<Conversion> Conversion { get; set; }   
        public DbSet<Subscription> Subscription { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<ConversionHistory> ConversionHistory { get; set; }
       public ConversorContext(DbContextOptions<ConversorContext> options) : base(options){

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConversionHistory>().HasOne(u => u.user).WithMany(u => u.ConversionHistory).HasForeignKey(i => i.IdUser);
            modelBuilder.Entity<User>().HasOne(s => s.Subscription).WithMany(u => u.users).HasForeignKey(i => i.IdSubscription);
            modelBuilder.Entity<Currency>().HasData(
                new Currency() { Id = 1, Leyend = "Dolar Americano", Symbol = "USD", IC = 1 },
                new Currency() { Id = 2, Leyend = "Peso Argentino", Symbol = "ARS", IC = 0.002 },
                new Currency() { Id = 3, Leyend = "Euro", Symbol = "EUR", IC = 1.09 },
                new Currency() { Id = 4, Leyend = "Corona Checa", Symbol = "KC", IC = 0.043 }
            );
            modelBuilder.Entity<Subscription>().HasData(
                new Subscription() { Id = 1, Name = "Free", Price = 0, MaxAttemps = 10},
                new Subscription() { Id = 2, Name = "Trial", Price = 10, MaxAttemps = 100 },
                new Subscription() { Id = 3, Name = "Pro", Price = 30, MaxAttemps = 10000 }
            );  
        }


    }
}
