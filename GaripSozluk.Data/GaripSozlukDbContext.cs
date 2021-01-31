using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Mapping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Data
{
    public class GaripSozlukDbContext : IdentityDbContext<User, Role, int>
    {
        public GaripSozlukDbContext() : base()
        {

        }
        public GaripSozlukDbContext(DbContextOptions<GaripSozlukDbContext> options) : base(options)
        {

        }
        //public override DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<EntryRating> EntryRatings { get; set; }
        public DbSet<BlockedUser> BlockedUsers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=ALIHAN; Database=GaripSozlukDB18; Trusted_Connection=True;Integrated Security=true;");
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new BlockedUserMap());
            builder.ApplyConfiguration(new PostCategoryMapping());
            builder.ApplyConfiguration(new PostMap());
            builder.ApplyConfiguration(new EntryMapping());
            builder.ApplyConfiguration(new EntryRatingMapping());
            builder.ApplyConfiguration(new UserMap());


            builder.Entity<PostCategory>().HasData(new List<PostCategory>()
            {
                new PostCategory(){ Id=1, Title="Category1", CreateDate=DateTime.Now },
                new PostCategory(){ Id=2, Title="Category2", CreateDate=DateTime.Now },
                new PostCategory(){ Id=3, Title="Category3", CreateDate=DateTime.Now },
                new PostCategory(){ Id=4, Title="Category4", CreateDate=DateTime.Now },
                new PostCategory(){ Id=5, Title="Category5", CreateDate=DateTime.Now },
                new PostCategory(){ Id=6, Title="Book", CreateDate=DateTime.Now },
                new PostCategory(){ Id=7, Title="Author", CreateDate=DateTime.Now }
            });

            builder.Entity<Post>().HasData(new List<Post>()
            {
                new Post(){ Id=1, Title="Post1", UserId=1, ClickCount=0, CategoryId=1, CreateDate=DateTime.Now },
                new Post(){ Id=2, Title="Post2", UserId=1, ClickCount=0, CategoryId=1, CreateDate=DateTime.Now },
                new Post(){ Id=3, Title="Post3", UserId=2, ClickCount=0, CategoryId=1, CreateDate=DateTime.Now },
                new Post(){ Id=4, Title="Post4", UserId=3, ClickCount=0, CategoryId=1, CreateDate=DateTime.Now },
                new Post(){ Id=5, Title="Post5", UserId=4, ClickCount=0, CategoryId=1, CreateDate=DateTime.Now },
                new Post(){ Id=6, Title="Post6", UserId=3, ClickCount=0, CategoryId=1, CreateDate=DateTime.Now },
                new Post(){ Id=7, Title="Post7", UserId=2, ClickCount=0, CategoryId=1, CreateDate=DateTime.Now },

                new Post(){ Id=8, Title="Post8", UserId=1, ClickCount=0, CategoryId=2, CreateDate=DateTime.Now },
                new Post(){ Id=9, Title="Post9", UserId=1, ClickCount=0, CategoryId=2, CreateDate=DateTime.Now },
                new Post(){ Id=10, Title="Post10", UserId=2, ClickCount=0, CategoryId=2, CreateDate=DateTime.Now },
                new Post(){ Id=11, Title="Post11", UserId=3, ClickCount=0, CategoryId=2, CreateDate=DateTime.Now },
                new Post(){ Id=12, Title="Post12", UserId=4, ClickCount=0, CategoryId=2, CreateDate=DateTime.Now },
                new Post(){ Id=13, Title="Post13", UserId=3, ClickCount=0, CategoryId=2, CreateDate=DateTime.Now },
                new Post(){ Id=14, Title="Post14", UserId=2, ClickCount=0, CategoryId=2, CreateDate=DateTime.Now }

            });

            builder.Entity<Entry>().HasData(new List<Entry>()
            {
                new Entry(){ Id=1, UserId=1, PostId=1, Content="Entry1", CreateDate=DateTime.Now },
                new Entry(){ Id=2, UserId=1, PostId=1, Content="Entry2", CreateDate=DateTime.Now },
                new Entry(){ Id=3, UserId=1, PostId=2, Content="Entry3", CreateDate=DateTime.Now },
                new Entry(){ Id=4, UserId=1, PostId=2, Content="Entry4", CreateDate=DateTime.Now },
                new Entry(){ Id=5, UserId=1, PostId=3, Content="Entry5", CreateDate=DateTime.Now },
                new Entry(){ Id=6, UserId=1, PostId=3, Content="Entry6", CreateDate=DateTime.Now },
                new Entry(){ Id=7, UserId=1, PostId=4, Content="Entry7", CreateDate=DateTime.Now },
                new Entry(){ Id=8, UserId=1, PostId=5, Content="Entry8", CreateDate=DateTime.Now },
                new Entry(){ Id=9, UserId=1, PostId=5, Content="Entry9", CreateDate=DateTime.Now },
                new Entry(){ Id=10, UserId=1, PostId=6, Content="Entry10", CreateDate=DateTime.Now },
                new Entry(){ Id=11, UserId=1, PostId=7, Content="Entry11", CreateDate=DateTime.Now },
                new Entry(){ Id=12, UserId=1, PostId=8, Content="Entry12", CreateDate=DateTime.Now },
                new Entry(){ Id=13, UserId=1, PostId=9, Content="Entry13", CreateDate=DateTime.Now },
                new Entry(){ Id=14, UserId=1, PostId=10, Content="Entry14", CreateDate=DateTime.Now },
                new Entry(){ Id=15, UserId=2, PostId=1, Content="Entry15", CreateDate=DateTime.Now },
                new Entry(){ Id=16, UserId=2, PostId=1, Content="Entry16", CreateDate=DateTime.Now },
                new Entry(){ Id=17, UserId=2, PostId=1, Content="Entry17", CreateDate=DateTime.Now },
                new Entry(){ Id=18, UserId=2, PostId=2, Content="Entry18", CreateDate=DateTime.Now },
                new Entry(){ Id=19, UserId=2, PostId=2, Content="Entry19", CreateDate=DateTime.Now },
                new Entry(){ Id=20, UserId=2, PostId=3, Content="Entry20", CreateDate=DateTime.Now },
                new Entry(){ Id=21, UserId=2, PostId=3, Content="Entry21", CreateDate=DateTime.Now },
                new Entry(){ Id=22, UserId=2, PostId=4, Content="Entry22", CreateDate=DateTime.Now },
                new Entry(){ Id=23, UserId=2, PostId=4, Content="Entry23", CreateDate=DateTime.Now },
                new Entry(){ Id=24, UserId=3, PostId=1, Content="Entry24", CreateDate=DateTime.Now },
                new Entry(){ Id=25, UserId=3, PostId=1, Content="Entry25", CreateDate=DateTime.Now },
                new Entry(){ Id=26, UserId=3, PostId=2, Content="Entry26", CreateDate=DateTime.Now },
                new Entry(){ Id=27, UserId=3, PostId=2, Content="Entry27", CreateDate=DateTime.Now },
                new Entry(){ Id=28, UserId=3, PostId=3, Content="Entry28", CreateDate=DateTime.Now },
                new Entry(){ Id=29, UserId=3, PostId=3, Content="Entry29", CreateDate=DateTime.Now },
                new Entry(){ Id=30, UserId=3, PostId=4, Content="Entry30", CreateDate=DateTime.Now },
                new Entry(){ Id=31, UserId=3, PostId=4, Content="Entry31", CreateDate=DateTime.Now },
                new Entry(){ Id=32, UserId=5, PostId=1, Content="Entry32", CreateDate=DateTime.Now },
                new Entry(){ Id=33, UserId=5, PostId=2, Content="Entry33", CreateDate=DateTime.Now },
                new Entry(){ Id=34, UserId=5, PostId=3, Content="Entry1", CreateDate=DateTime.Now },
                new Entry(){ Id=35, UserId=5, PostId=4, Content="Entry1", CreateDate=DateTime.Now },
                new Entry(){ Id=36, UserId=5, PostId=5, Content="Entry1", CreateDate=DateTime.Now }
            });

            /*User1*/
            builder.Entity<User>().HasData(new List<User>() {
                new User(){
                    AccessFailedCount=0,
                    Email="user1@gmail.com", EmailConfirmed=true,
                    ConcurrencyStamp="cdcf8fb8-1a87-4080-9ce7-ce3f35878a9a",
                    LockoutEnabled=true,
                    NormalizedEmail="USER1@GMAIL.COM",
                    NormalizedUserName="USER1",
                    PasswordHash="AQAAAAEAACcQAAAAEFLTKZM3sI4Uxec9PUhygjVEQpN2LgFi/XysXpyJYzyYbZjHwxsY2hKdFARVzTGeCQ==",
                    PhoneNumber="NULL",
                    PhoneNumberConfirmed=false,
                    SecurityStamp="U4EFKKNM45PL6CFHSTNZODTATSLG2KVJ",
                    UserName="User1",
                    TwoFactorEnabled=false,
                    Id = 1,
                    CreateDate=DateTime.Now
                }
            });
            /*User2*/
            builder.Entity<User>().HasData(new List<User>() {
                new User(){
                    AccessFailedCount=0,
                    Email="user2@gmail.com", EmailConfirmed=true,
                    ConcurrencyStamp="16d0a306-e24a-492d-9142-eaf10f30b783",
                    LockoutEnabled=true,
                    NormalizedEmail="USER2@GMAIL.COM",
                    NormalizedUserName="USER2",
                    PasswordHash="AQAAAAEAACcQAAAAEIbs0a708a7L9uyEQLjrYyFqTwiDs223mXOIQjvY6j5p+a7Ap94aQPRxrTabRytuJw==",
                    PhoneNumber="NULL",
                    PhoneNumberConfirmed=false,
                    SecurityStamp="U4EFKKNM45PL6CFHSTNZODTATSLG2KVJ",
                    UserName="User2",
                    TwoFactorEnabled=false,
                    Id = 2,
                    CreateDate=DateTime.Now
                }
            });
            /*User3*/
            builder.Entity<User>().HasData(new List<User>() {
                new User(){
                    AccessFailedCount=0,
                    Email="user3@gmail.com", EmailConfirmed=true,
                    ConcurrencyStamp="4a4f2ff3-8267-4a44-ae6a-06d03f0ce0dc",
                    LockoutEnabled=true,
                    NormalizedEmail="USER3@GMAIL.COM",
                    NormalizedUserName="USER3",
                    PasswordHash="AQAAAAEAACcQAAAAEHDgNLSCdSxOIEwbC3j1lgpK1VGtfcsDjma8EMABjVakzMt0IKnLskeOXoTBUN+/CQ==",
                    PhoneNumber="NULL",
                    PhoneNumberConfirmed=false,
                    SecurityStamp="U4EFKKNM45PL6CFHSTNZODTATSLG2KVJ",
                    UserName="User3",
                    TwoFactorEnabled=false,
                    Id = 3,
                    CreateDate=DateTime.Now
                }
            });
            /*User4*/
            builder.Entity<User>().HasData(new List<User>() {
                new User(){
                    AccessFailedCount=0,
                    Email="user4@gmail.com", EmailConfirmed=true,
                    ConcurrencyStamp="a73462d4-05e7-415d-bd7c-6fbad9a0d2a5",
                    LockoutEnabled=true,
                    NormalizedEmail="USER4@GMAIL.COM",
                    NormalizedUserName="USER4",
                    PasswordHash="AQAAAAEAACcQAAAAEFFSlov2zoB5GBM4zJ8cykIbUmTWwnsdbHvbVmFmAvaZQ0larKX/rSBJkrdh5VZ1Dw==",
                    PhoneNumber="NULL",
                    PhoneNumberConfirmed=false,
                    SecurityStamp="U4EFKKNM45PL6CFHSTNZODTATSLG2KVJ",
                    UserName="User4",
                    TwoFactorEnabled=false,
                    Id = 4,
                    CreateDate=DateTime.Now
                }
            });
            /*User5*/
            builder.Entity<User>().HasData(new List<User>() {
                new User(){
                    AccessFailedCount=0,
                    Email="user5@gmail.com", EmailConfirmed=true,
                    ConcurrencyStamp="d49d3e5d-461f-4f06-860c-c6dee94decaf",
                    LockoutEnabled=true,
                    NormalizedEmail="USER5@GMAIL.COM",
                    NormalizedUserName="USER5",
                    PasswordHash="AQAAAAEAACcQAAAAENTXilkTA0CBlBmw09m2/w8hEoK+rErvs1/yWlppiHRPL3qa+c364B/J1ox4hi7ZDA==",
                    PhoneNumber="NULL",
                    PhoneNumberConfirmed=false,
                    SecurityStamp="U4EFKKNM45PL6CFHSTNZODTATSLG2KVJ",
                    UserName="User5",
                    TwoFactorEnabled=false,
                    Id = 5,
                    CreateDate=DateTime.Now
                }
            });

        }
    }
}
