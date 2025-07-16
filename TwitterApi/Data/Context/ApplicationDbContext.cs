using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using TwitterApi.Data.Config;
using TwitterApi.Data.Entities;

namespace TwitterApi.Data.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<User>(options)
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<View> Viwes { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(UserConfig).Assembly);

            builder.Entity<User>()
                .Property(p => p.FullName)
                .HasComputedColumnSql("[FirstName] + ' ' + [LastName]");

            builder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .OnDelete(DeleteBehavior.NoAction); // or .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<View>()
                .HasOne(x => x.Post)
                .WithMany(c => c.Views)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<View>()
                .HasOne(x => x.User)
                .WithMany(o => o.Views)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
        }


    }
}
