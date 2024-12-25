using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    ParentFolderId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Folders_Folders_ParentFolderId",
                        column: x => x.ParentFolderId,
                        principalTable: "Folders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Folders_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SharedItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerUserId = table.Column<int>(type: "integer", nullable: false),
                    SharedUserId = table.Column<int>(type: "integer", nullable: false),
                    SharedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SharedItemType = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SharedItems_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SharedItems_Users_SharedUserId",
                        column: x => x.SharedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SharedItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    FolderId = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Folders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "Folders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Files_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    FileId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 25, 17, 12, 29, 127, DateTimeKind.Utc).AddTicks(7610), "johndoe@example.com", "John", "Doe", "AQAAAAEAACcQAAAAEBZ4BfJwUIMIUCXXxRwj8lhgefiscpN2jVuihOt8vdB1MM9TaxiOXTaVvqXsEA3vpQ==" },
                    { 2, new DateTime(2024, 12, 25, 17, 12, 29, 128, DateTimeKind.Utc).AddTicks(9178), "janesmith@example.com", "Jane", "Smith", "AQAAAAEAACcQAAAAEJL7fjSdK2AWe1mCOaidJgvCVXGP+P8kkLPwXThG7W0FktYxHI9chAZe0PjUXgJnfw==" },
                    { 3, new DateTime(2024, 12, 25, 17, 12, 29, 129, DateTimeKind.Utc).AddTicks(9732), "michaeljohnson@example.com", "Michael", "Johnson", "AQAAAAEAACcQAAAAEMYrVSa+t5w5whb+8FHVbfGTc/DvZOjrfHdtPVZMME5c5WavrfEUKytbgmFgozMDzg==" },
                    { 4, new DateTime(2024, 12, 25, 17, 12, 29, 131, DateTimeKind.Utc).AddTicks(649), "emilydavis@example.com", "Emily", "Davis", "AQAAAAEAACcQAAAAEPcTkRXifSWvt/IpXDlcZ35i2Z28C+Ti2+OfiPw9BXeLN82/Cjec0DZyM2o/hcOIcw==" },
                    { 5, new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(1154), "davidlee@example.com", "David", "Lee", "AQAAAAEAACcQAAAAEL3M1Hs9ldanWq9iW+S2RmIh+5zJdzS6jec6Ez/jWkmTPPkT6d35PyAmLG9LNLIewg==" }
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "CreatedAt", "Name", "OwnerId", "ParentFolderId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(7113), "Documents", 1, null, new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(7262) },
                    { 4, new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(7419), "Projects", 4, null, new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(7419) }
                });

            migrationBuilder.InsertData(
                table: "SharedItems",
                columns: new[] { "Id", "OwnerUserId", "SharedAt", "SharedItemType", "SharedUserId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 12, 25, 17, 12, 29, 133, DateTimeKind.Utc).AddTicks(1647), "File", 2, null },
                    { 2, 3, new DateTime(2024, 12, 25, 17, 12, 29, 133, DateTimeKind.Utc).AddTicks(1923), "Folder", 4, null },
                    { 3, 4, new DateTime(2024, 12, 25, 17, 12, 29, 133, DateTimeKind.Utc).AddTicks(1924), "File", 5, null }
                });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "Content", "CreatedAt", "FolderId", "Name", "OwnerId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "This is the content of my resume.", new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(8650), 1, "Resume.pdf", 1, new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(8798) },
                    { 5, "Content for my project report.", new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(9077), 4, "Report.xlsx", 5, new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(9077) }
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "CreatedAt", "Name", "OwnerId", "ParentFolderId", "UpdatedAt" },
                values: new object[,]
                {
                    { 2, new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(7414), "Photos", 2, 1, new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(7415) },
                    { 3, new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(7417), "Music", 3, 1, new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(7418) },
                    { 5, new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(7421), "Videos", 5, 4, new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(7421) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "FileId", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, "This is my resume file.", new DateTime(2024, 12, 25, 17, 12, 29, 133, DateTimeKind.Utc).AddTicks(174), 1, new DateTime(2024, 12, 25, 17, 12, 29, 133, DateTimeKind.Utc).AddTicks(316), 1 },
                    { 4, "This is a great report!", new DateTime(2024, 12, 25, 17, 12, 29, 133, DateTimeKind.Utc).AddTicks(462), 5, new DateTime(2024, 12, 25, 17, 12, 29, 133, DateTimeKind.Utc).AddTicks(463), 4 }
                });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "Content", "CreatedAt", "FolderId", "Name", "OwnerId", "UpdatedAt" },
                values: new object[,]
                {
                    { 2, "This is the content of my presentation.", new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(9071), 2, "Presentation.pptx", 2, new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(9072) },
                    { 3, "A beautiful vacation photo content.", new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(9074), 2, "Vacation.jpeg", 3, new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(9074) },
                    { 4, "Audio content of a holiday song.", new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(9075), 3, "Holiday.mp3", 4, new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(9076) },
                    { 6, "Content of a holiday song in MP3 format.", new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(9080), 3, "Song.mp3", 1, new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(9081) },
                    { 7, "This is a document content.", new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(9082), 5, "Document.docx", 2, new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(9082) },
                    { 8, "Video file content for a movie.", new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(9083), 5, "Movie.mp4", 3, new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(9084) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "FileId", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 2, "Great vacation photo!", new DateTime(2024, 12, 25, 17, 12, 29, 133, DateTimeKind.Utc).AddTicks(459), 3, new DateTime(2024, 12, 25, 17, 12, 29, 133, DateTimeKind.Utc).AddTicks(459), 2 },
                    { 3, "I love this holiday song.", new DateTime(2024, 12, 25, 17, 12, 29, 133, DateTimeKind.Utc).AddTicks(461), 4, new DateTime(2024, 12, 25, 17, 12, 29, 133, DateTimeKind.Utc).AddTicks(461), 3 },
                    { 5, "This is an awesome movie!", new DateTime(2024, 12, 25, 17, 12, 29, 133, DateTimeKind.Utc).AddTicks(465), 8, new DateTime(2024, 12, 25, 17, 12, 29, 133, DateTimeKind.Utc).AddTicks(466), 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FileId",
                table: "Comments",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_FolderId",
                table: "Files",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_OwnerId",
                table: "Files",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_OwnerId",
                table: "Folders",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_ParentFolderId",
                table: "Folders",
                column: "ParentFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedItems_OwnerUserId",
                table: "SharedItems",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedItems_SharedUserId",
                table: "SharedItems",
                column: "SharedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedItems_UserId",
                table: "SharedItems",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "SharedItems");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Folders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
