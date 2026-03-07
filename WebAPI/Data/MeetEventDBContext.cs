using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Principal;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class MeetEventDBContext : DbContext
    {
        public MeetEventDBContext(DbContextOptions options)
        : base(options)
        {

        }

        //реп

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Eventing> Events { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Pol> Pols { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Role> Roles { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<Post>().ToTable("Post");
            modelBuilder.Entity<Eventing>().ToTable("Eventing");
            modelBuilder.Entity<Meeting>().ToTable("Meeting");
            modelBuilder.Entity<Message>().ToTable("Message");
            modelBuilder.Entity<Pol>().ToTable("Pol");
            modelBuilder.Entity<Stage>().ToTable("Stage");
            modelBuilder.Entity<Role>().ToTable("Role");
        }


    }
}
