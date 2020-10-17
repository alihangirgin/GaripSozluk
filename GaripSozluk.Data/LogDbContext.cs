using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Mapping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Data
{
    public class LogDbContext : DbContext
    {

        public LogDbContext() : base()
        {

        }
        public LogDbContext(DbContextOptions<LogDbContext> options) : base(options)
        {

        }
        //public override DbSet<User> Users { get; set; }
        //public DbSet<Post> Posts { get; set; }
        //public DbSet<PostCategory> PostCategories { get; set; }
        //public DbSet<Entry> Entries { get; set; }
        //public DbSet<EntryRating> EntryRatings { get; set; }
        //public DbSet<BlockedUser> BlockedUsers { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder
            //    .UseSqlServer("Server=ALIHAN; Database=GaripSozlukDB18; Trusted_Connection=True;Integrated Security=true;");
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new LogMapping());
            //builder.ApplyConfiguration(new BlockedUserMap());
            //builder.ApplyConfiguration(new PostCategoryMapping());
            //builder.ApplyConfiguration(new PostMap());
            //builder.ApplyConfiguration(new EntryMapping());
            //builder.ApplyConfiguration(new EntryRatingMapping());
            //builder.ApplyConfiguration(new UserMap());

        }
    }
}
