using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiTester.Migrations
{
    /// <inheritdoc />
    public partial class CreateUserEntityAndDefineUserEntityRelationshipsBetweenOtherEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TableData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Hobbies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AccordionData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Username" },
                values: new object[] { 1, "AQAAAAIAAYagAAAAEATzWzTsWoRe9nDipd3Hc/j342w0Vyf/crcF3Tb820eHagJ6FL603sFhAa6/OlGAjw==", "admin" });

            migrationBuilder.InsertData(
                table: "AccordionData",
                columns: new[] { "Id", "Content", "Description", "Image", "Label", "Type", "UserId" },
                values: new object[,]
                {
                    { "eduvos", "I completed my BSc in Software Engineering at Eduvos...", "BSc Software Engineering", "/src/assets/eduvos.png", "Eduvos | Jan 2021 - Jul 2024", "Education", 1 },
                    { "highschool", "I completed my high school education at Bellville High School...", "HighSchool Student", "/src/assets/bellvillehighschool.png", "Bellville HighSchool | 2014 - 2019", "Education", 1 },
                    { "nebula", "As a Software Development Intern at 1Nebula...", "Software Development Intern", "/src/assets/1nebula.png", "1Nebula | Jan 2025 - Present", "Experience", 1 },
                    { "oceanbasket", "In my role as a Waiter at Ocean Basket Holdings...", "Waiter", "/src/assets/oceanbasket.png", "Ocean Basket | Nov 2022 - Jan 2025", "Experience", 1 },
                    { "rocomamas", "As a Waiter at RocoMamas...", "Waiter", "/src/assets/rocomamas.png", "RocoMamas | Dec 2021 - Oct 2022", "Experience", 1 }
                });

            migrationBuilder.InsertData(
                table: "Hobbies",
                columns: new[] { "Id", "Paragraph", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "I started practicing karate when I was just 4 years old, and it quickly became a huge part of my life. I trained in Shotokan Karate at my local dojo, where I dedicated myself to improving and eventually earned my black belt in 2016. That year, I had the incredible opportunity to travel to Japan, the birthplace of karate, to complete my black belt certification. It was an unforgettable experience, training with some of the most respected senseis in the world. Over the years, I competed in several regional and national tournaments, winning numerous medals, and attending international seminars. Though I dont train as intensely now, karate still holds a special place in my heart, and I occasionally participate in local competitions when I can.", "Karate", 1 },
                    { 2, "Ive been into gaming for as long as I can remember. It started when I was really young, with simple games on the family computer, but over the years, it became a bigger part of my life. Ive played just about everything from RPGs and strategy games to fast-paced FPS titles. My favorite games are those that offer a deep storyline and immersive worlds, like The Witcher 3 and Elder Scrolls V: Skyrim. Ive always enjoyed competing with friends and online players, especially in games like Fortnite and Valorant. Gaming has been a way for me to unwind, challenge myself, and connect with others, and even though I dont game as much as I used to, its still a hobby I hold dear.", "Gaming", 1 }
                });

            migrationBuilder.InsertData(
                table: "TableData",
                columns: new[] { "Id", "Key", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { 1, "Full Name:", "Personal Info", 1, "Meyer Hendrik Nigrini" },
                    { 2, "Date of Birth:", "Personal Info", 1, "29 August 2001" },
                    { 3, "Phone:", "Personal Info", 1, "074 444 5533" },
                    { 4, "Email:", "Personal Info", 1, "MeyerNigrini25@gmail.com" },
                    { 5, "Address:", "Personal Info", 1, "123 Maple Street, Springfield, IL, 62701" },
                    { 6, "Nationality:", "Personal Info", 1, "South African" },
                    { 7, "Occupation:", "Personal Info", 1, "Software Developer" },
                    { 8, "Company:", "Personal Info", 1, "1Nebula" },
                    { 9, "Marital Status:", "Personal Info", 1, "Single" },
                    { 10, "Languages:", "Personal Info", 1, "Afrikaans, English" },
                    { 11, "Programming Languages:", "Technical Skills", 1, "JavaScript, TypeScript, Python, Java." },
                    { 12, "Frontend Development:", "Technical Skills", 1, "HTML, CSS, React, Tailwind CSS." },
                    { 13, "Backend Development:", "Technical Skills", 1, "Node.js, Django, RESTful APIs." },
                    { 14, "Database Management:", "Technical Skills", 1, "MySQL, PostgreSQL, MongoDB." }
                });

            migrationBuilder.InsertData(
                table: "HobbiesDetails",
                columns: new[] { "Id", "HobbyId", "Key", "Value" },
                values: new object[,]
                {
                    { 1, 1, "Style", "GojuKai Karate, known for its emphasis on powerful strikes and precise techniques." },
                    { 2, 1, "Dedication", "Started at the age of 4 and trained consistently for over a decade to achieve black belt status." },
                    { 3, 1, "Japan Experience", "Traveled to Japan in 2016 to complete black belt certification, immersing yourself in the birthplace of karate and learning from world-renowned senseis." },
                    { 4, 1, "Competitions", "Participated in numerous regional and national tournaments, earning multiple medals." },
                    { 5, 1, "Current Engagement", "While no longer training intensively, you remain connected to karate through occasional participation in local competitions and by cherishing its values in daily life." },
                    { 6, 2, "Diverse Interests", "Enjoy playing a variety of genres, including RPGs, strategy games, and fast-paced FPS titles." },
                    { 7, 2, "Favorite Games", "The Witcher 3 and Elder Scrolls V: Skyrim for their deep storylines and immersive worlds." },
                    { 8, 2, "Competitive Edge", "Enjoy competing with friends and online players in multiplayer games like Fortnite and Valorant." },
                    { 9, 2, "Purpose", "Gaming serves as a way to unwind, challenge yourself, and connect with others." },
                    { 10, 2, "Current Engagement", "While not gaming as much as before, it remains a cherished hobby." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TableData_UserId",
                table: "TableData",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Hobbies_UserId",
                table: "Hobbies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccordionData_UserId",
                table: "AccordionData",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccordionData_Users_UserId",
                table: "AccordionData",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hobbies_Users_UserId",
                table: "Hobbies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TableData_Users_UserId",
                table: "TableData",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccordionData_Users_UserId",
                table: "AccordionData");

            migrationBuilder.DropForeignKey(
                name: "FK_Hobbies_Users_UserId",
                table: "Hobbies");

            migrationBuilder.DropForeignKey(
                name: "FK_TableData_Users_UserId",
                table: "TableData");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_TableData_UserId",
                table: "TableData");

            migrationBuilder.DropIndex(
                name: "IX_Hobbies_UserId",
                table: "Hobbies");

            migrationBuilder.DropIndex(
                name: "IX_AccordionData_UserId",
                table: "AccordionData");

            migrationBuilder.DeleteData(
                table: "AccordionData",
                keyColumn: "Id",
                keyValue: "eduvos");

            migrationBuilder.DeleteData(
                table: "AccordionData",
                keyColumn: "Id",
                keyValue: "highschool");

            migrationBuilder.DeleteData(
                table: "AccordionData",
                keyColumn: "Id",
                keyValue: "nebula");

            migrationBuilder.DeleteData(
                table: "AccordionData",
                keyColumn: "Id",
                keyValue: "oceanbasket");

            migrationBuilder.DeleteData(
                table: "AccordionData",
                keyColumn: "Id",
                keyValue: "rocomamas");

            migrationBuilder.DeleteData(
                table: "HobbiesDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HobbiesDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HobbiesDetails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HobbiesDetails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HobbiesDetails",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "HobbiesDetails",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "HobbiesDetails",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "HobbiesDetails",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "HobbiesDetails",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "HobbiesDetails",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TableData",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TableData",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TableData",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TableData",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TableData",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TableData",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TableData",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TableData",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TableData",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TableData",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TableData",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TableData",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TableData",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TableData",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Hobbies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hobbies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TableData");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Hobbies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AccordionData");
        }
    }
}
