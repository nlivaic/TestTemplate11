using MassTransit;
using Microsoft.EntityFrameworkCore;
using TestTemplate11.Core.Entities;

namespace TestTemplate11.Data
{
    public class TestTemplate11DbContext : DbContext
    {
        public TestTemplate11DbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Foo> Foos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddInboxStateEntity();
            modelBuilder.AddOutboxMessageEntity();
            modelBuilder.AddOutboxStateEntity();
        }
    }
}
