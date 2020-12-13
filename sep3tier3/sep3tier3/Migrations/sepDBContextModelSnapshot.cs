﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sep3tier3.DataAccess;

namespace sep3tier3.Migrations
{
    [DbContext(typeof(sepDBContext))]
    partial class sepDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("sep3tier3.Models.ChatMessage", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("date")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("image")
                        .HasColumnType("BLOB");

                    b.Property<string>("message")
                        .HasColumnType("TEXT");

                    b.Property<string>("nameReceived")
                        .HasColumnType("TEXT");

                    b.Property<string>("nameSend")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("ChatMessages");
                });

            modelBuilder.Entity("sep3tier3.Models.Friend", b =>
                {
                    b.Property<string>("username1")
                        .HasColumnType("TEXT");

                    b.Property<string>("username2")
                        .HasColumnType("TEXT");

                    b.Property<bool>("accept")
                        .HasColumnType("INTEGER");

                    b.HasKey("username1", "username2");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("sep3tier3.Models.SocialLine", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("date")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("image")
                        .HasColumnType("BLOB");

                    b.Property<string>("message")
                        .HasColumnType("TEXT");

                    b.Property<string>("username")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("SocialLines");
                });

            modelBuilder.Entity("sep3tier3.Models.User", b =>
                {
                    b.Property<string>("username")
                        .HasColumnType("TEXT");

                    b.Property<int>("age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<string>("firstname")
                        .HasColumnType("TEXT");

                    b.Property<string>("hobbies")
                        .HasColumnType("TEXT");

                    b.Property<string>("hometown")
                        .HasColumnType("TEXT");

                    b.Property<string>("lastname")
                        .HasColumnType("TEXT");

                    b.Property<string>("major")
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("profilePicture")
                        .HasColumnType("BLOB");

                    b.Property<string>("sex")
                        .HasColumnType("TEXT");

                    b.HasKey("username");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}