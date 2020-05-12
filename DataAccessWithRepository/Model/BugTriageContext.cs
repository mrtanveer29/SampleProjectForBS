using DataAccessWithRepository.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Models
{
    public partial class BugTriageContext : IdentityDbContext
    {


        public BugTriageContext(DbContextOptions<BugTriageContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentReaction> CommentReactions { get; set; }
      



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>(x=>x.ToTable("post"));

            modelBuilder.Entity<Comment>(x => x.ToTable("comments"));
            modelBuilder.Entity<CommentReaction>(x => x.ToTable("comment_reaction"));



        }







    }
}
