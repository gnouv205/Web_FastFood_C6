﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web_food_Asm.Data;

#nullable disable

namespace Web_food_Asm.Migrations
{
    [DbContext(typeof(ConnectStr))]
    [Migration("20250322125648_data")]
    partial class data
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
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

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Web_food_Asm.Models.ChiTietDonDatHang", b =>
                {
                    b.Property<int>("MaChiTiet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaChiTiet"));

                    b.Property<decimal>("Gia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MaDonHang")
                        .HasColumnType("int");

                    b.Property<int>("MaSanPham")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayGiao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayNhan")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayThanhToan")
                        .HasColumnType("datetime2");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TrangThai")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaChiTiet");

                    b.HasIndex("MaDonHang");

                    b.HasIndex("MaSanPham");

                    b.ToTable("ChiTietDonDatHangs");
                });

            modelBuilder.Entity("Web_food_Asm.Models.DanhMucSanPham", b =>
                {
                    b.Property<int>("MaDanhMuc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDanhMuc"));

                    b.Property<string>("TenDanhMuc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaDanhMuc");

                    b.ToTable("DanhMucSanPhams");
                });

            modelBuilder.Entity("Web_food_Asm.Models.DonDatHang", b =>
                {
                    b.Property<int>("MaDonHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDonHang"));

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgayDat")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TongTien")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TrangThai")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaDonHang");

                    b.HasIndex("Id");

                    b.ToTable("DonDatHangs");
                });

            modelBuilder.Entity("Web_food_Asm.Models.GioHang", b =>
                {
                    b.Property<int>("MaGioHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaGioHang"));

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("MaSanPham")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaGioHang");

                    b.HasIndex("Id");

                    b.HasIndex("MaSanPham");

                    b.ToTable("GioHangs");
                });

            modelBuilder.Entity("Web_food_Asm.Models.KhachHang", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Hinh")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TinhTrang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Web_food_Asm.Models.SanPham", b =>
                {
                    b.Property<int>("MaSanPham")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaSanPham"));

                    b.Property<decimal>("Gia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("MaDanhMuc")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaSanPham");

                    b.HasIndex("MaDanhMuc");

                    b.ToTable("SanPhams");
                });

            modelBuilder.Entity("Web_food_Asm.Models.SanPhamYeuThich", b =>
                {
                    b.Property<int>("MaYeuThich")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaYeuThich"));

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("MaSanPham")
                        .HasColumnType("int");

                    b.HasKey("MaYeuThich");

                    b.HasIndex("Id");

                    b.HasIndex("MaSanPham");

                    b.ToTable("SanPhamYeuThichs");
                });

            modelBuilder.Entity("Web_food_Asm.Models.ThanhToan", b =>
                {
                    b.Property<int>("MaDonHang")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayThanhToan")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhuongThuc")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("SoTien")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TrangThai")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaDonHang");

                    b.ToTable("ThanhToans");
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
                    b.HasOne("Web_food_Asm.Models.KhachHang", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Web_food_Asm.Models.KhachHang", null)
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

                    b.HasOne("Web_food_Asm.Models.KhachHang", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Web_food_Asm.Models.KhachHang", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Web_food_Asm.Models.ChiTietDonDatHang", b =>
                {
                    b.HasOne("Web_food_Asm.Models.DonDatHang", "DonDatHang")
                        .WithMany("ChiTietDonDatHangs")
                        .HasForeignKey("MaDonHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web_food_Asm.Models.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonDatHang");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("Web_food_Asm.Models.DonDatHang", b =>
                {
                    b.HasOne("Web_food_Asm.Models.KhachHang", "KhachHang")
                        .WithMany("DonDatHangs")
                        .HasForeignKey("Id");

                    b.Navigation("KhachHang");
                });

            modelBuilder.Entity("Web_food_Asm.Models.GioHang", b =>
                {
                    b.HasOne("Web_food_Asm.Models.KhachHang", "KhachHang")
                        .WithMany("GioHangs")
                        .HasForeignKey("Id");

                    b.HasOne("Web_food_Asm.Models.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhachHang");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("Web_food_Asm.Models.SanPham", b =>
                {
                    b.HasOne("Web_food_Asm.Models.DanhMucSanPham", "DanhMucSanPham")
                        .WithMany("SanPhams")
                        .HasForeignKey("MaDanhMuc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DanhMucSanPham");
                });

            modelBuilder.Entity("Web_food_Asm.Models.SanPhamYeuThich", b =>
                {
                    b.HasOne("Web_food_Asm.Models.KhachHang", "KhachHang")
                        .WithMany("SanPhamYeuThichs")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web_food_Asm.Models.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhachHang");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("Web_food_Asm.Models.ThanhToan", b =>
                {
                    b.HasOne("Web_food_Asm.Models.DonDatHang", "DonDatHang")
                        .WithOne("ThanhToan")
                        .HasForeignKey("Web_food_Asm.Models.ThanhToan", "MaDonHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonDatHang");
                });

            modelBuilder.Entity("Web_food_Asm.Models.DanhMucSanPham", b =>
                {
                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("Web_food_Asm.Models.DonDatHang", b =>
                {
                    b.Navigation("ChiTietDonDatHangs");

                    b.Navigation("ThanhToan")
                        .IsRequired();
                });

            modelBuilder.Entity("Web_food_Asm.Models.KhachHang", b =>
                {
                    b.Navigation("DonDatHangs");

                    b.Navigation("GioHangs");

                    b.Navigation("SanPhamYeuThichs");
                });
#pragma warning restore 612, 618
        }
    }
}
