using ConversorFinal_BE.Entities;
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

       public ConversorContext(DbContextOptions<ConversorContext> options) : base(options){
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOne(s => s.Subscription).WithMany(u => u.users).HasForeignKey(i => i.IdSubscription);
            modelBuilder.Entity<User>().HasMany(u => u.conversions).WithOne(u => u.User).HasForeignKey(i => i.IdUser);
            modelBuilder.Entity<Currency>().HasData(
                new Currency() { Id = 1, Leyend = "Dolar Americano", Symbol = "USD", IC = 1 },
                new Currency() { Id = 2, Leyend = "Peso Argentino", Symbol = "ARS", IC = 0.002 },
                new Currency() { Id = 3, Leyend = "Euro", Symbol = "EUR", IC = 1.09 },
                new Currency() { Id = 4, Leyend = "Corona Checa", Symbol = "KC", IC = 0.043 }
        );
                
        }


    }
}
