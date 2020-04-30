﻿// <auto-generated />
using System;
using BookManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

namespace BookManagementSystem.Data.Migrations
{
    [DbContext(typeof(BookManagementSystemContext))]
    partial class BookManagementSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            modelBuilder.Entity("BookManagementSystem.Data.Model.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnName("AUTHORNAME")
                        .HasColumnType("VARCHAR2(40)");

                    b.Property<int?>("BookId");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("AUTHOR");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorName = "Ivan Vazov",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            AuthorName = "Peio Qvorov",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 3,
                            AuthorName = "Dimcho Debelqnov",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("BookManagementSystem.Data.Model.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("BookTitle")
                        .IsRequired()
                        .HasColumnName("BOOKTITLE")
                        .HasColumnType("VARCHAR2(50)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnName("DATECREATED")
                        .HasColumnType("DATE");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("Id");

                    b.ToTable("BOOK");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookTitle = "Pod Igoto",
                            DateCreated = new DateTime(2014, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            BookTitle = "Poeziq",
                            DateCreated = new DateTime(2020, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 3,
                            BookTitle = "V polite na Vitosha",
                            DateCreated = new DateTime(2018, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("BookManagementSystem.Data.Model.BookLending", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("BookId");

                    b.Property<DateTime>("TakeDate")
                        .HasColumnName("TAKEDATE")
                        .HasColumnType("DATE");

                    b.Property<int?>("UserAccountId");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserAccountId");

                    b.ToTable("BOOKLENDING");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            TakeDate = new DateTime(2020, 4, 30, 14, 12, 4, 814, DateTimeKind.Local).AddTicks(8650),
                            UserAccountId = 2
                        },
                        new
                        {
                            Id = 2,
                            BookId = 2,
                            TakeDate = new DateTime(2020, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserAccountId = 3
                        },
                        new
                        {
                            Id = 3,
                            BookId = 3,
                            TakeDate = new DateTime(2020, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserAccountId = 1
                        });
                });

            modelBuilder.Entity("BookManagementSystem.Data.Model.UserAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FIRSTNAME")
                        .HasColumnType("VARCHAR2(40)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("LASTNAME")
                        .HasColumnType("VARCHAR2(40)");

                    b.HasKey("Id");

                    b.ToTable("USERACCOUNT");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Dimitur",
                            LastName = "Sokolov"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Kaloqn",
                            LastName = "Ivanov"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Emiliqn",
                            LastName = "Nikolov"
                        });
                });

            modelBuilder.Entity("BookManagementSystem.Data.Model.Author", b =>
                {
                    b.HasOne("BookManagementSystem.Data.Model.Book", "Book")
                        .WithMany("Authors")
                        .HasForeignKey("BookId");
                });

            modelBuilder.Entity("BookManagementSystem.Data.Model.BookLending", b =>
                {
                    b.HasOne("BookManagementSystem.Data.Model.Book", "Book")
                        .WithMany("BookLendings")
                        .HasForeignKey("BookId");

                    b.HasOne("BookManagementSystem.Data.Model.UserAccount", "UserAccount")
                        .WithMany("BookLendings")
                        .HasForeignKey("UserAccountId");
                });
#pragma warning restore 612, 618
        }
    }
}
