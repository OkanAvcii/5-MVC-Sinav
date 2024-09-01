using BlogApp.Core.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Dal.Contexts
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<ArticleTopic> ArticleTopics { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure many-to-many relationship for Article-Topic
            builder.Entity<ArticleTopic>()
                .HasKey(at => new { at.ArticleId, at.TopicId });

            builder.Entity<ArticleTopic>()
                .HasOne(at => at.Article)
                .WithMany(a => a.ArticleTopics)
                .HasForeignKey(at => at.ArticleId);

            builder.Entity<ArticleTopic>()
                .HasOne(at => at.Topic)
                .WithMany(t => t.ArticleTopics)
                .HasForeignKey(at => at.TopicId);
        }
    }
}
