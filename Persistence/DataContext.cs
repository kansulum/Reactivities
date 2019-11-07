using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Value>().HasData(
                new Value{Id=1,Name="Values 101"},
                new Value{Id=2,Name="Values 102"},
                new Value{Id=3,Name="Values 103"}
            );
        }

        public DbSet<Value> Values { get; set; }
    }
}
