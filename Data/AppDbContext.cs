using Hookbox.Models;
using Microsoft.EntityFrameworkCore;

namespace Hookbox.Data
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {
            

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Inbox>().HasIndex(u => u.Token).IsUnique();

            
        }
        public DbSet<Inbox> Inboxes {get;set;}
        public DbSet<User> Users {get;set;}
        public DbSet<WebhookRequest> WebhookRequests {get;set;}

    }
}