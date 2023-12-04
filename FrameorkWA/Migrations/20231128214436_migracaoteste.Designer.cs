﻿// <auto-generated />
using FrameorkWA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FrameorkWA.Migrations
{
    [DbContext(typeof(FrameorkWAContext))]
    [Migration("20231128214436_migracaoteste")]
    partial class migracaoteste
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FrameorkWA.Models.Filho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PaiId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaiId");

                    b.ToTable("Filho", (string)null);
                });

            modelBuilder.Entity("FrameorkWA.Models.Pai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Pai", (string)null);
                });

            modelBuilder.Entity("FrameorkWA.Models.Filho", b =>
                {
                    b.HasOne("FrameorkWA.Models.Pai", null)
                        .WithMany("Filhos")
                        .HasForeignKey("PaiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FrameorkWA.Models.Pai", b =>
                {
                    b.Navigation("Filhos");
                });
#pragma warning restore 612, 618
        }
    }
}
