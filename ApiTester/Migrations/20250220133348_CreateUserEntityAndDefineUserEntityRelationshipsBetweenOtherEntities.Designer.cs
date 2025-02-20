﻿// <auto-generated />
using ApiTester.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiTester.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250220133348_CreateUserEntityAndDefineUserEntityRelationshipsBetweenOtherEntities")]
    partial class CreateUserEntityAndDefineUserEntityRelationshipsBetweenOtherEntities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiTester.Domain.Models.AccordionEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AccordionData", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "eduvos",
                            Content = "I completed my BSc in Software Engineering at Eduvos...",
                            Description = "BSc Software Engineering",
                            Image = "/src/assets/eduvos.png",
                            Label = "Eduvos | Jan 2021 - Jul 2024",
                            Type = "Education",
                            UserId = 1
                        },
                        new
                        {
                            Id = "highschool",
                            Content = "I completed my high school education at Bellville High School...",
                            Description = "HighSchool Student",
                            Image = "/src/assets/bellvillehighschool.png",
                            Label = "Bellville HighSchool | 2014 - 2019",
                            Type = "Education",
                            UserId = 1
                        },
                        new
                        {
                            Id = "nebula",
                            Content = "As a Software Development Intern at 1Nebula...",
                            Description = "Software Development Intern",
                            Image = "/src/assets/1nebula.png",
                            Label = "1Nebula | Jan 2025 - Present",
                            Type = "Experience",
                            UserId = 1
                        },
                        new
                        {
                            Id = "oceanbasket",
                            Content = "In my role as a Waiter at Ocean Basket Holdings...",
                            Description = "Waiter",
                            Image = "/src/assets/oceanbasket.png",
                            Label = "Ocean Basket | Nov 2022 - Jan 2025",
                            Type = "Experience",
                            UserId = 1
                        },
                        new
                        {
                            Id = "rocomamas",
                            Content = "As a Waiter at RocoMamas...",
                            Description = "Waiter",
                            Image = "/src/assets/rocomamas.png",
                            Label = "RocoMamas | Dec 2021 - Oct 2022",
                            Type = "Experience",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("ApiTester.Domain.Models.ContactMeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContactMe", (string)null);
                });

            modelBuilder.Entity("ApiTester.Domain.Models.HobbiesDetailEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HobbyId")
                        .HasColumnType("int");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HobbyId");

                    b.ToTable("HobbiesDetails", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HobbyId = 1,
                            Key = "Style",
                            Value = "GojuKai Karate, known for its emphasis on powerful strikes and precise techniques."
                        },
                        new
                        {
                            Id = 2,
                            HobbyId = 1,
                            Key = "Dedication",
                            Value = "Started at the age of 4 and trained consistently for over a decade to achieve black belt status."
                        },
                        new
                        {
                            Id = 3,
                            HobbyId = 1,
                            Key = "Japan Experience",
                            Value = "Traveled to Japan in 2016 to complete black belt certification, immersing yourself in the birthplace of karate and learning from world-renowned senseis."
                        },
                        new
                        {
                            Id = 4,
                            HobbyId = 1,
                            Key = "Competitions",
                            Value = "Participated in numerous regional and national tournaments, earning multiple medals."
                        },
                        new
                        {
                            Id = 5,
                            HobbyId = 1,
                            Key = "Current Engagement",
                            Value = "While no longer training intensively, you remain connected to karate through occasional participation in local competitions and by cherishing its values in daily life."
                        },
                        new
                        {
                            Id = 6,
                            HobbyId = 2,
                            Key = "Diverse Interests",
                            Value = "Enjoy playing a variety of genres, including RPGs, strategy games, and fast-paced FPS titles."
                        },
                        new
                        {
                            Id = 7,
                            HobbyId = 2,
                            Key = "Favorite Games",
                            Value = "The Witcher 3 and Elder Scrolls V: Skyrim for their deep storylines and immersive worlds."
                        },
                        new
                        {
                            Id = 8,
                            HobbyId = 2,
                            Key = "Competitive Edge",
                            Value = "Enjoy competing with friends and online players in multiplayer games like Fortnite and Valorant."
                        },
                        new
                        {
                            Id = 9,
                            HobbyId = 2,
                            Key = "Purpose",
                            Value = "Gaming serves as a way to unwind, challenge yourself, and connect with others."
                        },
                        new
                        {
                            Id = 10,
                            HobbyId = 2,
                            Key = "Current Engagement",
                            Value = "While not gaming as much as before, it remains a cherished hobby."
                        });
                });

            modelBuilder.Entity("ApiTester.Domain.Models.HobbiesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Paragraph")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Hobbies", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Paragraph = "I started practicing karate when I was just 4 years old, and it quickly became a huge part of my life. I trained in Shotokan Karate at my local dojo, where I dedicated myself to improving and eventually earned my black belt in 2016. That year, I had the incredible opportunity to travel to Japan, the birthplace of karate, to complete my black belt certification. It was an unforgettable experience, training with some of the most respected senseis in the world. Over the years, I competed in several regional and national tournaments, winning numerous medals, and attending international seminars. Though I dont train as intensely now, karate still holds a special place in my heart, and I occasionally participate in local competitions when I can.",
                            Title = "Karate",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Paragraph = "Ive been into gaming for as long as I can remember. It started when I was really young, with simple games on the family computer, but over the years, it became a bigger part of my life. Ive played just about everything from RPGs and strategy games to fast-paced FPS titles. My favorite games are those that offer a deep storyline and immersive worlds, like The Witcher 3 and Elder Scrolls V: Skyrim. Ive always enjoyed competing with friends and online players, especially in games like Fortnite and Valorant. Gaming has been a way for me to unwind, challenge myself, and connect with others, and even though I dont game as much as I used to, its still a hobby I hold dear.",
                            Title = "Gaming",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("ApiTester.Domain.Models.InfoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TableData", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Key = "Full Name:",
                            Type = "Personal Info",
                            UserId = 1,
                            Value = "Meyer Hendrik Nigrini"
                        },
                        new
                        {
                            Id = 2,
                            Key = "Date of Birth:",
                            Type = "Personal Info",
                            UserId = 1,
                            Value = "29 August 2001"
                        },
                        new
                        {
                            Id = 3,
                            Key = "Phone:",
                            Type = "Personal Info",
                            UserId = 1,
                            Value = "074 444 5533"
                        },
                        new
                        {
                            Id = 4,
                            Key = "Email:",
                            Type = "Personal Info",
                            UserId = 1,
                            Value = "MeyerNigrini25@gmail.com"
                        },
                        new
                        {
                            Id = 5,
                            Key = "Address:",
                            Type = "Personal Info",
                            UserId = 1,
                            Value = "123 Maple Street, Springfield, IL, 62701"
                        },
                        new
                        {
                            Id = 6,
                            Key = "Nationality:",
                            Type = "Personal Info",
                            UserId = 1,
                            Value = "South African"
                        },
                        new
                        {
                            Id = 7,
                            Key = "Occupation:",
                            Type = "Personal Info",
                            UserId = 1,
                            Value = "Software Developer"
                        },
                        new
                        {
                            Id = 8,
                            Key = "Company:",
                            Type = "Personal Info",
                            UserId = 1,
                            Value = "1Nebula"
                        },
                        new
                        {
                            Id = 9,
                            Key = "Marital Status:",
                            Type = "Personal Info",
                            UserId = 1,
                            Value = "Single"
                        },
                        new
                        {
                            Id = 10,
                            Key = "Languages:",
                            Type = "Personal Info",
                            UserId = 1,
                            Value = "Afrikaans, English"
                        },
                        new
                        {
                            Id = 11,
                            Key = "Programming Languages:",
                            Type = "Technical Skills",
                            UserId = 1,
                            Value = "JavaScript, TypeScript, Python, Java."
                        },
                        new
                        {
                            Id = 12,
                            Key = "Frontend Development:",
                            Type = "Technical Skills",
                            UserId = 1,
                            Value = "HTML, CSS, React, Tailwind CSS."
                        },
                        new
                        {
                            Id = 13,
                            Key = "Backend Development:",
                            Type = "Technical Skills",
                            UserId = 1,
                            Value = "Node.js, Django, RESTful APIs."
                        },
                        new
                        {
                            Id = 14,
                            Key = "Database Management:",
                            Type = "Technical Skills",
                            UserId = 1,
                            Value = "MySQL, PostgreSQL, MongoDB."
                        });
                });

            modelBuilder.Entity("ApiTester.Domain.Models.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PasswordHash = "AQAAAAIAAYagAAAAEATzWzTsWoRe9nDipd3Hc/j342w0Vyf/crcF3Tb820eHagJ6FL603sFhAa6/OlGAjw==",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("ApiTester.Domain.Models.AccordionEntity", b =>
                {
                    b.HasOne("ApiTester.Domain.Models.UserEntity", "User")
                        .WithMany("Accordions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApiTester.Domain.Models.HobbiesDetailEntity", b =>
                {
                    b.HasOne("ApiTester.Domain.Models.HobbiesEntity", "Hobby")
                        .WithMany("Details")
                        .HasForeignKey("HobbyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hobby");
                });

            modelBuilder.Entity("ApiTester.Domain.Models.HobbiesEntity", b =>
                {
                    b.HasOne("ApiTester.Domain.Models.UserEntity", "User")
                        .WithMany("Hobbies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApiTester.Domain.Models.InfoEntity", b =>
                {
                    b.HasOne("ApiTester.Domain.Models.UserEntity", "User")
                        .WithMany("Infos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApiTester.Domain.Models.HobbiesEntity", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("ApiTester.Domain.Models.UserEntity", b =>
                {
                    b.Navigation("Accordions");

                    b.Navigation("Hobbies");

                    b.Navigation("Infos");
                });
#pragma warning restore 612, 618
        }
    }
}
