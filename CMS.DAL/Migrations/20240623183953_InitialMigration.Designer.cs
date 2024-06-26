﻿// <auto-generated />
using System;
using CMS.DAL.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CMS.DAL.Migrations
{
    [DbContext(typeof(CMSContext))]
    [Migration("20240623183953_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CMS.DAL.DataModel.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CMS.DAL.DataModel.Citatelji", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("varchar(450)")
                        .HasMaxLength(450)
                        .IsUnicode(false);

                    b.Property<int?>("BrojKomentara")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("broj_komentara")
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("Id");

                    b.ToTable("Citatelji");
                });

            modelBuilder.Entity("CMS.DAL.DataModel.Clanci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumIzmjene")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("datum_izmjene")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime>("DatumKreiranja")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("datum_kreiranja")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Kategorija")
                        .HasColumnName("kategorija")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Naslov")
                        .IsRequired()
                        .HasColumnName("naslov")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("NovinarId")
                        .HasColumnName("novinar_id")
                        .HasColumnType("varchar(450)")
                        .HasMaxLength(450)
                        .IsUnicode(false);

                    b.Property<int>("Ocjena")
                        .HasColumnName("ocjena")
                        .HasColumnType("int");

                    b.Property<string>("Sadrzaj")
                        .IsRequired()
                        .HasColumnName("sadrzaj")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NovinarId");

                    b.ToTable("Clanci");
                });

            modelBuilder.Entity("CMS.DAL.DataModel.Komentari", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CitateljId")
                        .HasColumnName("citatelj_id")
                        .HasColumnType("varchar(450)")
                        .HasMaxLength(450)
                        .IsUnicode(false);

                    b.Property<int>("ClanakId")
                        .HasColumnName("clanak_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumKreiranja")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("datum_kreiranja")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("Ocjena")
                        .HasColumnName("ocjena")
                        .HasColumnType("int");

                    b.Property<string>("OsobeId")
                        .HasColumnType("varchar(450)");

                    b.Property<string>("Sadrzaj")
                        .IsRequired()
                        .HasColumnName("sadrzaj")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CitateljId");

                    b.HasIndex("ClanakId");

                    b.HasIndex("OsobeId");

                    b.ToTable("Komentari");
                });

            modelBuilder.Entity("CMS.DAL.DataModel.Novinari", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("varchar(450)")
                        .HasMaxLength(450)
                        .IsUnicode(false);

                    b.Property<int?>("BrojClanaka")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("broj_clanaka")
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("Id");

                    b.ToTable("Novinari");
                });

            modelBuilder.Entity("CMS.DAL.DataModel.Osobe", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("varchar(450)")
                        .HasMaxLength(450)
                        .IsUnicode(false);

                    b.Property<DateTime?>("DatumRegistracije")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("datum_registracije")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnName("ime")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Lozinka")
                        .IsRequired()
                        .HasColumnName("lozinka")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("OpisProfila")
                        .HasColumnName("opis_profila")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnName("prezime")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Uloga")
                        .IsRequired()
                        .HasColumnName("uloga")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("UQ__Osobe__AB6E6164765749EB");

                    b.ToTable("Osobe");
                });

            modelBuilder.Entity("CMS.DAL.DataModel.Slike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClanakId")
                        .HasColumnName("clanak_id")
                        .HasColumnType("int");

                    b.Property<byte[]>("Slika")
                        .HasColumnName("slika")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClanakId");

                    b.ToTable("Slike");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CMS.DAL.DataModel.Citatelji", b =>
                {
                    b.HasOne("CMS.DAL.DataModel.Osobe", "IdNavigation")
                        .WithOne("Citatelji")
                        .HasForeignKey("CMS.DAL.DataModel.Citatelji", "Id")
                        .HasConstraintName("FK_Citatelji_Osobe_Id")
                        .IsRequired();
                });

            modelBuilder.Entity("CMS.DAL.DataModel.Clanci", b =>
                {
                    b.HasOne("CMS.DAL.DataModel.Novinari", "Novinar")
                        .WithMany("Clanci")
                        .HasForeignKey("NovinarId")
                        .HasConstraintName("FK_Clanci_Novinari_Id");
                });

            modelBuilder.Entity("CMS.DAL.DataModel.Komentari", b =>
                {
                    b.HasOne("CMS.DAL.DataModel.Citatelji", "Citatelj")
                        .WithMany("Komentari")
                        .HasForeignKey("CitateljId")
                        .HasConstraintName("FK_Komentari_Citatelji_Id");

                    b.HasOne("CMS.DAL.DataModel.Clanci", "Clanak")
                        .WithMany("Komentari")
                        .HasForeignKey("ClanakId")
                        .HasConstraintName("FK_Komentari_Clanci_Id")
                        .IsRequired();

                    b.HasOne("CMS.DAL.DataModel.Osobe", null)
                        .WithMany("Komentari")
                        .HasForeignKey("OsobeId");
                });

            modelBuilder.Entity("CMS.DAL.DataModel.Novinari", b =>
                {
                    b.HasOne("CMS.DAL.DataModel.Osobe", "IdNavigation")
                        .WithOne("Novinari")
                        .HasForeignKey("CMS.DAL.DataModel.Novinari", "Id")
                        .HasConstraintName("FK_Novinari_Osobe_Id")
                        .IsRequired();
                });

            modelBuilder.Entity("CMS.DAL.DataModel.Slike", b =>
                {
                    b.HasOne("CMS.DAL.DataModel.Clanci", "Clanak")
                        .WithMany("Slike")
                        .HasForeignKey("ClanakId")
                        .HasConstraintName("FK_Slike_Clanci_Id")
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CMS.DAL.DataModel.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CMS.DAL.DataModel.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CMS.DAL.DataModel.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CMS.DAL.DataModel.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
