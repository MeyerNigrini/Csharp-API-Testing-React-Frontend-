using ApiTester.Application.Models;
using ApiTester.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using ApiTester.Infrastructure.Helpers;

namespace ApiTester.Infrastructure.Data
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {

            // Seed Users
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = 1,
                    Username = "admin",
                    PasswordHash = "AQAAAAIAAYagAAAAEATzWzTsWoRe9nDipd3Hc/j342w0Vyf/crcF3Tb820eHagJ6FL603sFhAa6/OlGAjw=="

                }
            );

            // Seed Accordion Data
            modelBuilder.Entity<AccordionEntity>().HasData(
                new AccordionEntity
                {
                    Id = "eduvos",
                    UserId = 1, 
                    Label = "Eduvos | Jan 2021 - Jul 2024",
                    Description = "BSc Software Engineering",
                    Content = "I completed my BSc in Software Engineering at Eduvos...",
                    Type = "Education",
                    Image = "/src/assets/eduvos.png"
                },
                new AccordionEntity
                {
                    Id = "highschool",
                    UserId = 1,
                    Label = "Bellville HighSchool | 2014 - 2019",
                    Description = "HighSchool Student",
                    Content = "I completed my high school education at Bellville High School...",
                    Type = "Education",
                    Image = "/src/assets/bellvillehighschool.png"
                },
                new AccordionEntity
                {
                    Id = "nebula",
                    UserId = 1,
                    Label = "1Nebula | Jan 2025 - Present",
                    Description = "Software Development Intern",
                    Content = "As a Software Development Intern at 1Nebula...",
                    Type = "Experience",
                    Image = "/src/assets/1nebula.png"
                },
                new AccordionEntity
                {
                    Id = "oceanbasket",
                    UserId = 1,
                    Label = "Ocean Basket | Nov 2022 - Jan 2025",
                    Description = "Waiter",
                    Content = "In my role as a Waiter at Ocean Basket Holdings...",
                    Type = "Experience",
                    Image = "/src/assets/oceanbasket.png"
                },
                new AccordionEntity
                {
                    Id = "rocomamas",
                    UserId = 1,
                    Label = "RocoMamas | Dec 2021 - Oct 2022",
                    Description = "Waiter",
                    Content = "As a Waiter at RocoMamas...",
                    Type = "Experience",
                    Image = "/src/assets/rocomamas.png"
                }
            );

            // Seed Hobbies
            modelBuilder.Entity<HobbiesEntity>().HasData(
                new HobbiesEntity
                {
                    Id = 1,
                    UserId = 1,
                    Title = "Karate",
                    Paragraph = "I started practicing karate when I was just 4 years old, and it quickly became a huge part of my life. I trained in Shotokan Karate at my local dojo, where I dedicated myself to improving and eventually earned my black belt in 2016. That year, I had the incredible opportunity to travel to Japan, the birthplace of karate, to complete my black belt certification. It was an unforgettable experience, training with some of the most respected senseis in the world. Over the years, I competed in several regional and national tournaments, winning numerous medals, and attending international seminars. Though I dont train as intensely now, karate still holds a special place in my heart, and I occasionally participate in local competitions when I can."
                },
                new HobbiesEntity
                {
                    Id = 2,
                    UserId = 1,
                    Title = "Gaming",
                    Paragraph = "Ive been into gaming for as long as I can remember. It started when I was really young, with simple games on the family computer, but over the years, it became a bigger part of my life. Ive played just about everything from RPGs and strategy games to fast-paced FPS titles. My favorite games are those that offer a deep storyline and immersive worlds, like The Witcher 3 and Elder Scrolls V: Skyrim. Ive always enjoyed competing with friends and online players, especially in games like Fortnite and Valorant. Gaming has been a way for me to unwind, challenge myself, and connect with others, and even though I dont game as much as I used to, its still a hobby I hold dear."
                }
            );

            // Seed Hobbies Details 
            modelBuilder.Entity<HobbiesDetailEntity>().HasData(
                new HobbiesDetailEntity
                {
                    Id = 1,
                    HobbyId = 1,
                    Key = "Style",
                    Value = "GojuKai Karate, known for its emphasis on powerful strikes and precise techniques."
                },
                new HobbiesDetailEntity
                {
                    Id = 2,
                    HobbyId = 1,
                    Key = "Dedication",
                    Value = "Started at the age of 4 and trained consistently for over a decade to achieve black belt status."
                },
                new HobbiesDetailEntity
                {
                    Id = 3,
                    HobbyId = 1,
                    Key = "Japan Experience",
                    Value = "Traveled to Japan in 2016 to complete black belt certification, immersing yourself in the birthplace of karate and learning from world-renowned senseis."
                },
                new HobbiesDetailEntity
                {
                    Id = 4,
                    HobbyId = 1,
                    Key = "Competitions",
                    Value = "Participated in numerous regional and national tournaments, earning multiple medals."
                },
                new HobbiesDetailEntity
                {
                    Id = 5,
                    HobbyId = 1,
                    Key = "Current Engagement",
                    Value = "While no longer training intensively, you remain connected to karate through occasional participation in local competitions and by cherishing its values in daily life."
                },
                new HobbiesDetailEntity
                {
                    Id = 6,
                    HobbyId = 2,
                    Key = "Diverse Interests",
                    Value = "Enjoy playing a variety of genres, including RPGs, strategy games, and fast-paced FPS titles."
                },
                new HobbiesDetailEntity
                {
                    Id = 7,
                    HobbyId = 2,
                    Key = "Favorite Games",
                    Value = "The Witcher 3 and Elder Scrolls V: Skyrim for their deep storylines and immersive worlds."
                },
                new HobbiesDetailEntity
                {
                    Id = 8,
                    HobbyId = 2,
                    Key = "Competitive Edge",
                    Value = "Enjoy competing with friends and online players in multiplayer games like Fortnite and Valorant."
                },
                new HobbiesDetailEntity
                {
                    Id = 9,
                    HobbyId = 2,
                    Key = "Purpose",
                    Value = "Gaming serves as a way to unwind, challenge yourself, and connect with others."
                },
                new HobbiesDetailEntity
                {
                    Id = 10,
                    HobbyId = 2,
                    Key = "Current Engagement",
                    Value = "While not gaming as much as before, it remains a cherished hobby."
                }

            );

            // Seed Table Data
            modelBuilder.Entity<InfoEntity>().HasData(
                new InfoEntity
                {
                    Id = 1,
                    UserId = 1,
                    Type = "Personal Info",
                    Key = "Full Name:",
                    Value = "Meyer Hendrik Nigrini"
                },
                new InfoEntity
                {
                    Id = 2,
                    UserId = 1,
                    Type = "Personal Info",
                    Key = "Date of Birth:",
                    Value = "29 August 2001"
                },
                new InfoEntity
                {
                    Id = 3,
                    UserId = 1,
                    Type = "Personal Info",
                    Key = "Phone:",
                    Value = "074 444 5533"
                },
                new InfoEntity
                {
                    Id = 4,
                    UserId = 1,
                    Type = "Personal Info",
                    Key = "Email:",
                    Value = "MeyerNigrini25@gmail.com"
                },
                new InfoEntity
                {
                    Id = 5,
                    UserId = 1,
                    Type = "Personal Info",
                    Key = "Address:",
                    Value = "123 Maple Street, Springfield, IL, 62701"
                },
                new InfoEntity
                {
                    Id = 6,
                    UserId = 1,
                    Type = "Personal Info",
                    Key = "Nationality:",
                    Value = "South African"
                },
                new InfoEntity
                {
                    Id = 7,
                    UserId = 1,
                    Type = "Personal Info",
                    Key = "Occupation:",
                    Value = "Software Developer"
                },
                new InfoEntity
                {
                    Id = 8,
                    UserId = 1,
                    Type = "Personal Info",
                    Key = "Company:",
                    Value = "1Nebula"
                },
                new InfoEntity
                {
                    Id = 9,
                    UserId = 1,
                    Type = "Personal Info",
                    Key = "Marital Status:",
                    Value = "Single"
                },
                new InfoEntity
                {
                    Id = 10,
                    UserId = 1,
                    Type = "Personal Info",
                    Key = "Languages:",
                    Value = "Afrikaans, English"
                },
                new InfoEntity
                {
                    Id = 11,
                    UserId = 1,
                    Type = "Technical Skills",
                    Key = "Programming Languages:",
                    Value = "JavaScript, TypeScript, Python, Java."
                },
                new InfoEntity
                {
                    Id = 12,
                    UserId = 1,
                    Type = "Technical Skills",
                    Key = "Frontend Development:",
                    Value = "HTML, CSS, React, Tailwind CSS."
                },
                new InfoEntity
                {
                    Id = 13,
                    UserId = 1,
                    Type = "Technical Skills",
                    Key = "Backend Development:",
                    Value = "Node.js, Django, RESTful APIs."
                },
                new InfoEntity
                {
                    Id = 14,
                    UserId = 1,
                    Type = "Technical Skills",
                    Key = "Database Management:",
                    Value = "MySQL, PostgreSQL, MongoDB."
                }
            );
        }
    }
}
