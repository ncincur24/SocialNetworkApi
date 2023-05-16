using Microsoft.EntityFrameworkCore;
using SocialNetwork.DataAccess.Configurations;
using SocialNetwork.DataAccess.Entities;
using System;

namespace SocialNetwork.DataAccess
{
    public class SocialNetworkContext : DbContext
    {
        public SocialNetworkContext()
        {
            
        }
        public SocialNetworkContext(DbContextOptions opt) : base(opt)
        {
            Database.EnsureCreated();   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().Property(x => x.Username).IsRequired();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Entity).Assembly);
            modelBuilder.Entity<GroupChatUser>().HasKey(x => new { x.UserId, x.GroupChatId });
            modelBuilder.Entity<GroupChatUser>().Property(x => x.AddedAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<PostFile>().HasKey(x => new { x.PostId, x.FileId });
            modelBuilder.Entity<HashTagPost>().HasKey(x => new { x.PostId, x.HashTagId });
            modelBuilder.Entity<CommentReaction>().HasKey(x => new { x.CommentId, x.ReactionId });
            modelBuilder.Entity<UserMessage>()
                    .HasOne(x => x.Sender)
                    .WithMany(x => x.SentUserMessages)
                    .HasForeignKey(x => x.SenderId)
                    .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserMessage>()
                    .HasOne(x => x.Receiver)
                    .WithMany(x => x.ReceivedUserMessages)
                    .HasForeignKey(x => x.ReceiverId)
                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GroupChatMessage>()
                    .HasOne(x => x.GroupChat)
                    .WithMany(x => x.GroupChatMessages)
                    .HasForeignKey(x => x.GroupChatId)
                    .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog = SocialNetwork; Integrated Security = true");
            //base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<HashTag> HashTag { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<GroupChat> GroupChats { get; set; }
        public DbSet<GroupChatUser> GroupChatUsers { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<GroupChatMessage> GroupChatMessages { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<HashTagPost> HashTagPost { get; set; }
        public DbSet<CommentReaction> CommentReaction { get; set; }
    }
}
