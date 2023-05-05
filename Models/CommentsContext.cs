using Microsoft.EntityFrameworkCore;
using System;

namespace ChatGPTModeration.Models
{
    public class CommentsContext : DbContext
    {
        public CommentsContext(DbContextOptions<CommentsContext> options) : base(options) { }

        public DbSet<CommentModel> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommentModel>().HasData(
                new CommentModel { CommnetId = Guid.NewGuid(), Comment = "How are you?", Approved = true}
                );
        }
    }
}
