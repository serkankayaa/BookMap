﻿// <auto-generated />
using System;
using BookStore.Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BookStore.Api.Migrations
{
    [DbContext(typeof(BookDbContext))]
    partial class BookDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("BookStore.Entity.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnName("CONTENT_TYPE");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnName("CREATED_BY")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CREATED_DATE");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnName("FILE_NAME");

                    b.Property<string>("FullPath")
                        .IsRequired()
                        .HasColumnName("FULL_PATH");

                    b.Property<string>("UpdatedBy")
                        .HasColumnName("UPDATED_BY")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnName("UPDATED_DATE");

                    b.HasKey("Id");

                    b.ToTable("DOCUMENT");
                });

            modelBuilder.Entity("BookStore.Entity.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("Biography")
                        .HasColumnName("BIOGRAPHY");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnName("BIRTH_DATE");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnName("CREATED_BY")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CREATED_DATE");

                    b.Property<Guid>("DocumetIdFk")
                        .HasColumnName("DOCUMENT_ID_FK");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasMaxLength(250);

                    b.Property<string>("UpdatedBy")
                        .HasColumnName("UPDATED_BY")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnName("UPDATED_DATE");

                    b.HasKey("Id");

                    b.HasIndex("DocumetIdFk");

                    b.ToTable("AUTHOR");
                });

            modelBuilder.Entity("BookStore.Entity.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<Guid>("AuthorIdFk")
                        .HasColumnName("AUTHOR_ID_FK");

                    b.Property<Guid>("CategoryIdFk")
                        .HasColumnName("CATEGORY_ID_FK");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnName("CREATED_BY")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CREATED_DATE");

                    b.Property<Guid>("DocumetIdFk")
                        .HasColumnName("DOCUMENT_ID_FK");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasMaxLength(250);

                    b.Property<Guid>("PublisherIdFk")
                        .HasColumnName("PUBLISHER_ID_FK");

                    b.Property<Guid>("ShopIdFk")
                        .HasColumnName("SHOP_ID_FK");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnName("SUMMARY");

                    b.Property<string>("UpdatedBy")
                        .HasColumnName("UPDATED_BY")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnName("UPDATED_DATE");

                    b.HasKey("Id");

                    b.HasIndex("AuthorIdFk");

                    b.HasIndex("CategoryIdFk");

                    b.HasIndex("DocumetIdFk");

                    b.HasIndex("PublisherIdFk");

                    b.HasIndex("ShopIdFk");

                    b.ToTable("BOOK");
                });

            modelBuilder.Entity("BookStore.Entity.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnName("CREATED_BY")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CREATED_DATE");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasMaxLength(250);

                    b.Property<string>("UpdatedBy")
                        .HasColumnName("UPDATED_BY")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnName("UPDATED_DATE");

                    b.HasKey("Id");

                    b.ToTable("CATEGORY");
                });

            modelBuilder.Entity("BookStore.Entity.Models.ErrorLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ErrorMessage")
                        .IsRequired();

                    b.Property<DateTime>("ErrorTime");

                    b.Property<string>("ErrorType");

                    b.HasKey("Id");

                    b.ToTable("ERROR_LOG");
                });

            modelBuilder.Entity("BookStore.Entity.Models.Log", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Method")
                        .IsRequired();

                    b.Property<string>("Path")
                        .IsRequired();

                    b.Property<string>("QueryString");

                    b.Property<string>("RequestBody");

                    b.Property<DateTime>("RequestTime");

                    b.Property<string>("ResponseBody");

                    b.Property<long>("ResponseMillis");

                    b.Property<int>("StatusCode");

                    b.HasKey("Id");

                    b.ToTable("LOG");
                });

            modelBuilder.Entity("BookStore.Entity.Models.Publisher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnName("CREATED_BY")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CREATED_DATE");

                    b.Property<string>("Location")
                        .HasColumnName("LOCATION")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasMaxLength(250);

                    b.Property<string>("UpdatedBy")
                        .HasColumnName("UPDATED_BY")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnName("UPDATED_DATE");

                    b.HasKey("Id");

                    b.ToTable("PUBLISHER");
                });

            modelBuilder.Entity("BookStore.Entity.Models.Shop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnName("CREATED_BY")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CREATED_DATE");

                    b.Property<string>("Location")
                        .HasColumnName("LOCATION")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasMaxLength(250);

                    b.Property<string>("UpdatedBy")
                        .HasColumnName("UPDATED_BY")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnName("UPDATED_DATE");

                    b.HasKey("Id");

                    b.ToTable("SHOP");
                });

            modelBuilder.Entity("BookStore.Entity.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnName("CREATED_BY")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CREATED_DATE");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnName("EMAIL_ADDRESS")
                        .HasMaxLength(250);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnName("EMAIL_CONFIRMED");

                    b.Property<byte>("Role")
                        .HasColumnName("ROLE");

                    b.Property<string>("UpdatedBy")
                        .HasColumnName("UPDATED_BY")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnName("UPDATED_DATE");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnName("USER_NAME")
                        .HasMaxLength(150);

                    b.Property<string>("VerificationCode")
                        .HasColumnName("VERIFICATION_CODE");

                    b.HasKey("Id");

                    b.ToTable("USER");
                });

            modelBuilder.Entity("BookStore.Entity.Models.UserBook", b =>
                {
                    b.Property<Guid>("BookIdFk")
                        .HasColumnName("BOOK_ID_FK");

                    b.Property<Guid>("UserIdFk")
                        .HasColumnName("USER_ID_FK");

                    b.HasKey("BookIdFk", "UserIdFk");

                    b.HasIndex("UserIdFk");

                    b.ToTable("USER_BOOK");
                });

            modelBuilder.Entity("BookStore.Entity.Models.UserLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnName("CREATED_BY")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CREATED_DATE");

                    b.Property<DateTime>("LoginDate")
                        .HasColumnName("LOGIN_DATE");

                    b.Property<DateTime>("LogoutDate")
                        .HasColumnName("LOGOUT_DATE");

                    b.Property<string>("Token")
                        .HasColumnName("TOKEN");

                    b.Property<string>("UpdatedBy")
                        .HasColumnName("UPDATED_BY");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnName("UPDATED_DATE");

                    b.Property<Guid>("UserIdFk")
                        .HasColumnName("USER_ID_FK");

                    b.HasKey("Id");

                    b.HasIndex("UserIdFk");

                    b.ToTable("USER_LOG");
                });

            modelBuilder.Entity("BookStore.Entity.Models.UserPassword", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnName("CREATED_BY")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CREATED_DATE");

                    b.Property<bool>("IsActive")
                        .HasColumnName("IS_ACTIVE");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnName("PASSWORD_HASH");

                    b.Property<string>("UpdatedBy")
                        .HasColumnName("UPDATED_BY")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnName("UPDATED_DATE");

                    b.Property<Guid>("UserIdFk")
                        .HasColumnName("USER_ID_FK");

                    b.HasKey("Id");

                    b.HasIndex("UserIdFk");

                    b.ToTable("USER_PASSWORD");
                });

            modelBuilder.Entity("BookStore.Entity.Models.UserProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("Address")
                        .HasColumnName("ADDRESS");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnName("BIRTHDATE");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnName("CREATED_BY")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CREATED_DATE");

                    b.Property<Guid?>("ImageIdFk")
                        .HasColumnName("DOCUMENT_ID_FK");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasMaxLength(100);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnName("SURNAME")
                        .HasMaxLength(100);

                    b.Property<string>("UpdatedBy")
                        .HasColumnName("UPDATED_BY")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnName("UPDATED_DATE");

                    b.Property<Guid>("UserIdFk")
                        .HasColumnName("USER_ID_FK");

                    b.HasKey("Id");

                    b.HasIndex("ImageIdFk");

                    b.HasIndex("UserIdFk");

                    b.ToTable("USER_PROFILE");
                });

            modelBuilder.Entity("BookStore.Entity.Models.Author", b =>
                {
                    b.HasOne("BookStore.Entity.Document", "Document")
                        .WithMany()
                        .HasForeignKey("DocumetIdFk")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookStore.Entity.Models.Book", b =>
                {
                    b.HasOne("BookStore.Entity.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorIdFk")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookStore.Entity.Models.Category", "Category")
                        .WithMany("books")
                        .HasForeignKey("CategoryIdFk")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookStore.Entity.Document", "Document")
                        .WithMany()
                        .HasForeignKey("DocumetIdFk")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookStore.Entity.Models.Publisher", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherIdFk")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookStore.Entity.Models.Shop", "Shop")
                        .WithMany("books")
                        .HasForeignKey("ShopIdFk")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookStore.Entity.Models.UserBook", b =>
                {
                    b.HasOne("BookStore.Entity.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookIdFk")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookStore.Entity.Models.User", "User")
                        .WithMany("UserBooks")
                        .HasForeignKey("UserIdFk")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookStore.Entity.Models.UserLog", b =>
                {
                    b.HasOne("BookStore.Entity.Models.User", "User")
                        .WithMany("UserLogs")
                        .HasForeignKey("UserIdFk")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookStore.Entity.Models.UserPassword", b =>
                {
                    b.HasOne("BookStore.Entity.Models.User", "User")
                        .WithMany("UserPasswords")
                        .HasForeignKey("UserIdFk")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookStore.Entity.Models.UserProfile", b =>
                {
                    b.HasOne("BookStore.Entity.Document", "Document")
                        .WithMany()
                        .HasForeignKey("ImageIdFk");

                    b.HasOne("BookStore.Entity.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserIdFk")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
