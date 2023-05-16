﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialNetwork.DataAccess;

namespace SocialNetwork.DataAccess.Migrations
{
    [DbContext(typeof(SocialNetworkContext))]
    [Migration("20230503095411_UserId on reactionsA")]
    partial class UserIdonreactionsA
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ParentCommentId")
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ParentCommentId");

                    b.HasIndex("PostId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.CommentReaction", b =>
                {
                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<int>("ReactionId")
                        .HasColumnType("int");

                    b.HasKey("CommentId", "ReactionId");

                    b.HasIndex("ReactionId");

                    b.ToTable("CommentReaction");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.GroupChat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("GroupChats");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.GroupChatUser", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("GroupChatId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("UserId", "GroupChatId");

                    b.HasIndex("GroupChatId");

                    b.ToTable("GroupChatUsers");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.HashTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("TagValue")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("TagValue")
                        .IsUnique();

                    b.ToTable("HashTag");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.HashTagPost", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("HashTagId")
                        .HasColumnType("int");

                    b.HasKey("PostId", "HashTagId");

                    b.HasIndex("HashTagId");

                    b.ToTable("HashTagPost");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int?>("ParentMessageId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReceivedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParentMessageId");

                    b.ToTable("Message");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Message");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("TextContent")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.PostFile", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("FileId")
                        .HasColumnType("int");

                    b.HasKey("PostId", "FileId");

                    b.HasIndex("FileId");

                    b.ToTable("PostFile");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.PostReaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("ReactionId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("ReactionId");

                    b.HasIndex("UserId");

                    b.ToTable("PostReaction");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.Reaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FileId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProfileImageId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("ProfileImageId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.UserRelation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InitiatorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InitiatorId");

                    b.HasIndex("ReceiverId");

                    b.ToTable("UserRelation");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.GroupChatMessage", b =>
                {
                    b.HasBaseType("SocialNetwork.DataAccess.Entities.Message");

                    b.Property<int>("GroupChatId")
                        .HasColumnType("int");

                    b.HasIndex("GroupChatId");

                    b.HasIndex("SenderId");

                    b.HasDiscriminator().HasValue("GroupChatMessage");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.UserMessage", b =>
                {
                    b.HasBaseType("SocialNetwork.DataAccess.Entities.Message");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SeenAt")
                        .HasColumnType("datetime2");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.HasDiscriminator().HasValue("UserMessage");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.Comment", b =>
                {
                    b.HasOne("SocialNetwork.DataAccess.Entities.User", "Author")
                        .WithMany("Comments")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialNetwork.DataAccess.Entities.Comment", "ParentComment")
                        .WithMany("ChildComments")
                        .HasForeignKey("ParentCommentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SocialNetwork.DataAccess.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("ParentComment");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.CommentReaction", b =>
                {
                    b.HasOne("SocialNetwork.DataAccess.Entities.Comment", "Comment")
                        .WithMany("Reactions")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialNetwork.DataAccess.Entities.Reaction", "Reaction")
                        .WithMany()
                        .HasForeignKey("ReactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");

                    b.Navigation("Reaction");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.GroupChatUser", b =>
                {
                    b.HasOne("SocialNetwork.DataAccess.Entities.GroupChat", "GroupChat")
                        .WithMany("GroupChatUsers")
                        .HasForeignKey("GroupChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.DataAccess.Entities.User", "User")
                        .WithMany("GroupChatUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GroupChat");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.HashTagPost", b =>
                {
                    b.HasOne("SocialNetwork.DataAccess.Entities.HashTag", "HashTag")
                        .WithMany("HashTagPosts")
                        .HasForeignKey("HashTagId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialNetwork.DataAccess.Entities.Post", "Post")
                        .WithMany("PostHashTags")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("HashTag");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.Message", b =>
                {
                    b.HasOne("SocialNetwork.DataAccess.Entities.Message", "ParentMessage")
                        .WithMany("ChildMessages")
                        .HasForeignKey("ParentMessageId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ParentMessage");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.Post", b =>
                {
                    b.HasOne("SocialNetwork.DataAccess.Entities.User", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.PostFile", b =>
                {
                    b.HasOne("SocialNetwork.DataAccess.Entities.File", "File")
                        .WithMany()
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.DataAccess.Entities.Post", "Post")
                        .WithMany("PostFiles")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("File");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.PostReaction", b =>
                {
                    b.HasOne("SocialNetwork.DataAccess.Entities.Post", "Post")
                        .WithMany("PostReactions")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialNetwork.DataAccess.Entities.Reaction", "Reaction")
                        .WithMany()
                        .HasForeignKey("ReactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.DataAccess.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Reaction");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.Reaction", b =>
                {
                    b.HasOne("SocialNetwork.DataAccess.Entities.File", "Icon")
                        .WithMany()
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Icon");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.User", b =>
                {
                    b.HasOne("SocialNetwork.DataAccess.Entities.File", "ProfileImage")
                        .WithMany()
                        .HasForeignKey("ProfileImageId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ProfileImage");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.UserRelation", b =>
                {
                    b.HasOne("SocialNetwork.DataAccess.Entities.User", "Initiator")
                        .WithMany("SentRequests")
                        .HasForeignKey("InitiatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialNetwork.DataAccess.Entities.User", "Receiver")
                        .WithMany("ReceivedRequests")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Initiator");

                    b.Navigation("Receiver");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.GroupChatMessage", b =>
                {
                    b.HasOne("SocialNetwork.DataAccess.Entities.GroupChat", "GroupChat")
                        .WithMany("GroupChatMessages")
                        .HasForeignKey("GroupChatId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialNetwork.DataAccess.Entities.User", "Sender")
                        .WithMany("SentGroupMessages")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GroupChat");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.UserMessage", b =>
                {
                    b.HasOne("SocialNetwork.DataAccess.Entities.User", "Receiver")
                        .WithMany("ReceivedUserMessages")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialNetwork.DataAccess.Entities.User", "Sender")
                        .WithMany("SentUserMessages")
                        .HasForeignKey("SenderId")
                        .HasConstraintName("FK_Message_Users_SenderId1")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.Comment", b =>
                {
                    b.Navigation("ChildComments");

                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.GroupChat", b =>
                {
                    b.Navigation("GroupChatMessages");

                    b.Navigation("GroupChatUsers");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.HashTag", b =>
                {
                    b.Navigation("HashTagPosts");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.Message", b =>
                {
                    b.Navigation("ChildMessages");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("PostFiles");

                    b.Navigation("PostHashTags");

                    b.Navigation("PostReactions");
                });

            modelBuilder.Entity("SocialNetwork.DataAccess.Entities.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("GroupChatUsers");

                    b.Navigation("Posts");

                    b.Navigation("ReceivedRequests");

                    b.Navigation("ReceivedUserMessages");

                    b.Navigation("SentGroupMessages");

                    b.Navigation("SentRequests");

                    b.Navigation("SentUserMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
