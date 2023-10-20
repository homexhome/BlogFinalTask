using BlogFinalTask.Web.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlogFinalTask.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<CustomIdentity, CustomRole, string>
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ArticleTags> ArticleTags { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        protected void RemoveFixups(ModelBuilder modelBuilder, Type type) {
            foreach (var relationship in modelBuilder.Model.FindEntityType(type)!.GetForeignKeys()) {
                relationship.DeleteBehavior = DeleteBehavior.ClientNoAction;
            }
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            //customizations
            RemoveFixups(builder, typeof(Article));
            RemoveFixups(builder, typeof(Tag));
            RemoveFixups(builder, typeof(ArticleTags));
            RemoveFixups(builder, typeof(Comment));
            RemoveFixups(builder, typeof(CustomIdentity));


            builder.Entity<CustomIdentity>()
            .HasOne(u => u.Role)
            .WithMany()
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<CustomRole>().HasData(new CustomRole {
                Name = "User",
                NormalizedName = "USER",
                Id = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });
            builder.Entity<CustomRole>().HasData(new CustomRole {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Id = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });

            base.OnModelCreating(builder);
        }


    }
}