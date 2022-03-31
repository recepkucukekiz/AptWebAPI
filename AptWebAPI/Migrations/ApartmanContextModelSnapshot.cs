﻿// <auto-generated />
using AptWebAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AptWebAPI.Migrations
{
    [DbContext(typeof(ApartmanContext))]
    partial class ApartmanContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AptWebAPI.Database.Entity.Aidat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DaireId")
                        .HasColumnType("int");

                    b.Property<string>("Donem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OdendiMi")
                        .HasColumnType("bit");

                    b.Property<double>("Tutar")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DaireId");

                    b.ToTable("Aidats");
                });

            modelBuilder.Entity("AptWebAPI.Database.Entity.Apartman", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Isim")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Apartmans");
                });

            modelBuilder.Entity("AptWebAPI.Database.Entity.Daire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ApartmanId")
                        .HasColumnType("int");

                    b.Property<short>("Kat")
                        .HasColumnType("smallint");

                    b.Property<int>("KiraciId")
                        .HasColumnType("int");

                    b.Property<int>("No")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApartmanId");

                    b.HasIndex("KiraciId")
                        .IsUnique();

                    b.ToTable("Daires");
                });

            modelBuilder.Entity("AptWebAPI.Database.Entity.Kiraci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("KiraciMi")
                        .HasColumnType("bit");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoyAd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kiracis");
                });

            modelBuilder.Entity("AptWebAPI.Database.Entity.Yonetici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ApartmanId")
                        .HasColumnType("int");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoyAd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApartmanId")
                        .IsUnique();

                    b.ToTable("Yoneticis");
                });

            modelBuilder.Entity("AptWebAPI.Database.Entity.Aidat", b =>
                {
                    b.HasOne("AptWebAPI.Database.Entity.Daire", "Daire")
                        .WithMany("AidatList")
                        .HasForeignKey("DaireId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Daire");
                });

            modelBuilder.Entity("AptWebAPI.Database.Entity.Daire", b =>
                {
                    b.HasOne("AptWebAPI.Database.Entity.Apartman", "Apartman")
                        .WithMany("Daires")
                        .HasForeignKey("ApartmanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AptWebAPI.Database.Entity.Kiraci", "Kiraci")
                        .WithOne("Daire")
                        .HasForeignKey("AptWebAPI.Database.Entity.Daire", "KiraciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Apartman");

                    b.Navigation("Kiraci");
                });

            modelBuilder.Entity("AptWebAPI.Database.Entity.Yonetici", b =>
                {
                    b.HasOne("AptWebAPI.Database.Entity.Apartman", "Apartman")
                        .WithOne("Yonetici")
                        .HasForeignKey("AptWebAPI.Database.Entity.Yonetici", "ApartmanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Apartman");
                });

            modelBuilder.Entity("AptWebAPI.Database.Entity.Apartman", b =>
                {
                    b.Navigation("Daires");

                    b.Navigation("Yonetici");
                });

            modelBuilder.Entity("AptWebAPI.Database.Entity.Daire", b =>
                {
                    b.Navigation("AidatList");
                });

            modelBuilder.Entity("AptWebAPI.Database.Entity.Kiraci", b =>
                {
                    b.Navigation("Daire");
                });
#pragma warning restore 612, 618
        }
    }
}