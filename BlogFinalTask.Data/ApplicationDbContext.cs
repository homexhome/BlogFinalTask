using BlogFinalTask.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BlogFinalTask.Data
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

            builder.Entity<ArticleTags>()
        .HasKey(at => new { at.ArticleId, at.TagId });

            builder.Entity<ArticleTags>()
                .HasOne(at => at.Article)
                .WithMany(a => a.ArticleTags)
                .HasForeignKey(at => at.ArticleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ArticleTags>()
                .HasOne(at => at.Tag)
                .WithMany(t => t.ArticleTags)
                .HasForeignKey(at => at.TagId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            string userId = Guid.NewGuid().ToString();
            string moderatorId = Guid.NewGuid().ToString();
            string adminId = Guid.NewGuid().ToString();

            // SEED DATA
            builder.Entity<CustomRole>().HasData(new CustomRole {
                Name = "User",
                NormalizedName = "USER",
                Id = userId,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Description = "Basic User Role"
            });
            builder.Entity<CustomRole>().HasData(new CustomRole {
                Name = "Moderator",
                NormalizedName = "MODERATOR",
                Id = moderatorId,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Description = "Basic Moderator Role"

            });
            builder.Entity<CustomRole>().HasData(new CustomRole {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Id = adminId,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Description = "Basic Admin Role"
            });
            builder.Entity<IdentityRoleClaim<string>>().HasData(new IdentityRoleClaim<string> {
                Id = 3,
                RoleId = userId,
                ClaimType = "Role",
                ClaimValue = "User"
            });
            builder.Entity<IdentityRoleClaim<string>>().HasData(new IdentityRoleClaim<string> {
                Id = 2,
                RoleId = moderatorId,
                ClaimType = "Role",
                ClaimValue = "Moderator"
            });
            builder.Entity<IdentityRoleClaim<string>>().HasData(new IdentityRoleClaim<string> {
                Id = 1,
                RoleId = adminId,
                ClaimType = "Role",
                ClaimValue = "Admin"
            });

            builder.Entity<IdentityRoleClaim<string>>().Property(x => x.Id).UseIdentityColumn();


            base.OnModelCreating(builder);
        }


    }
}