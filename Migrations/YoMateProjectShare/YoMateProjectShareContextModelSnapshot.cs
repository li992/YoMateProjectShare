﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YoMateProjectShare.Data;

namespace YoMateProjectShare.Migrations.YoMateProjectShare
{
    [DbContext(typeof(YoMateProjectShareContext))]
    partial class YoMateProjectShareContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("YoMateProjectShare.Models.ChatHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChatroomId")
                        .HasColumnType("int");

                    b.Property<string>("message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("sendingTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChatroomId");

                    b.ToTable("ChatHistorys");
                });

            modelBuilder.Entity("YoMateProjectShare.Models.ChatList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChatListId")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChatListId");

                    b.ToTable("ChatLists");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ChatList");
                });

            modelBuilder.Entity("YoMateProjectShare.Models.FriendList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FriendListId")
                        .HasColumnType("int");

                    b.Property<string>("belongtoId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FriendListId");

                    b.ToTable("FriendLists");

                    b.HasDiscriminator<string>("Discriminator").HasValue("FriendList");
                });

            modelBuilder.Entity("YoMateProjectShare.Models.Projects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AbstractText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArticleName")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("AuthorName")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("FieldOfStudy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UploadTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("YoMateProjectShare.Models.Chatroom", b =>
                {
                    b.HasBaseType("YoMateProjectShare.Models.ChatList");

                    b.HasDiscriminator().HasValue("Chatroom");
                });

            modelBuilder.Entity("YoMateProjectShare.Models.Friend", b =>
                {
                    b.HasBaseType("YoMateProjectShare.Models.FriendList");

                    b.Property<DateTime>("addingTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("friendId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("friendNickname")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Friend");
                });

            modelBuilder.Entity("YoMateProjectShare.Models.ChatHistory", b =>
                {
                    b.HasOne("YoMateProjectShare.Models.Chatroom", null)
                        .WithMany("historyLists")
                        .HasForeignKey("ChatroomId");
                });

            modelBuilder.Entity("YoMateProjectShare.Models.ChatList", b =>
                {
                    b.HasOne("YoMateProjectShare.Models.ChatList", null)
                        .WithMany("chatLists")
                        .HasForeignKey("ChatListId");
                });

            modelBuilder.Entity("YoMateProjectShare.Models.FriendList", b =>
                {
                    b.HasOne("YoMateProjectShare.Models.FriendList", null)
                        .WithMany("friendLists")
                        .HasForeignKey("FriendListId");
                });
#pragma warning restore 612, 618
        }
    }
}
