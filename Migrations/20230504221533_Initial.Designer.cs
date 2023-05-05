﻿// <auto-generated />
using System;
using ChatGPTModeration.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChatGPTModeration.Migrations
{
    [DbContext(typeof(CommentsContext))]
    [Migration("20230504221533_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChatGPTModeration.CommentModel", b =>
                {
                    b.Property<Guid>("CommnetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommnetId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            CommnetId = new Guid("5530d53a-5c47-4448-ab8b-08a3aebba9a0"),
                            Approved = true,
                            Comment = "How are you?"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
