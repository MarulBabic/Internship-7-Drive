using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "SharedItems",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FolderId",
                table: "SharedItems",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 14, 39, 56, 661, DateTimeKind.Utc).AddTicks(1393), new DateTime(2025, 1, 3, 14, 39, 56, 661, DateTimeKind.Utc).AddTicks(1624) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 14, 39, 56, 661, DateTimeKind.Utc).AddTicks(1850), new DateTime(2025, 1, 3, 14, 39, 56, 661, DateTimeKind.Utc).AddTicks(1851) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 14, 39, 56, 661, DateTimeKind.Utc).AddTicks(1853), new DateTime(2025, 1, 3, 14, 39, 56, 661, DateTimeKind.Utc).AddTicks(1854) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 14, 39, 56, 661, DateTimeKind.Utc).AddTicks(1856), new DateTime(2025, 1, 3, 14, 39, 56, 661, DateTimeKind.Utc).AddTicks(1856) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 14, 39, 56, 661, DateTimeKind.Utc).AddTicks(1858), new DateTime(2025, 1, 3, 14, 39, 56, 661, DateTimeKind.Utc).AddTicks(1858) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(8574), new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(8877) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(9356), new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(9357) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(9361), new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(9362) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(9364), new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(9364) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(9366), new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(9367) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(9372), new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(9373) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(9374), new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(9375) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(9377), new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(9378) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(5536), new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(5767) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(6015), new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(6016) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(6020), new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(6020) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(6023), new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(6023) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(6025), new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(6026) });

            migrationBuilder.UpdateData(
                table: "SharedItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FileId", "FolderId", "SharedAt" },
                values: new object[] { null, null, new DateTime(2025, 1, 3, 14, 39, 56, 661, DateTimeKind.Utc).AddTicks(3315) });

            migrationBuilder.UpdateData(
                table: "SharedItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FileId", "FolderId", "SharedAt" },
                values: new object[] { null, null, new DateTime(2025, 1, 3, 14, 39, 56, 661, DateTimeKind.Utc).AddTicks(3761) });

            migrationBuilder.UpdateData(
                table: "SharedItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FileId", "FolderId", "SharedAt" },
                values: new object[] { null, null, new DateTime(2025, 1, 3, 14, 39, 56, 661, DateTimeKind.Utc).AddTicks(3763) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 1, 3, 14, 39, 56, 651, DateTimeKind.Utc).AddTicks(3360), "AQAAAAEAACcQAAAAEDTvSlfYdk381h3pa+yqtlJ2u6laog3vs5EUCSh0LX0FV6BsPKLsqw0Ngwrs5aC6pA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 1, 3, 14, 39, 56, 653, DateTimeKind.Utc).AddTicks(3981), "AQAAAAEAACcQAAAAEC9/eUeMPCYi/FWCQVzfZ0UUXT7phRS9ZqanMLM8j0rP8aQSsiX5QZU9DL5bOZDjeg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 1, 3, 14, 39, 56, 655, DateTimeKind.Utc).AddTicks(1042), "AQAAAAEAACcQAAAAECHKS4r4iTHRbwSNY37RLNxtQiuh7t/jPB+ZAWuh8BQ7SKiefxM+j4lHUmQxDgBSFw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 1, 3, 14, 39, 56, 657, DateTimeKind.Utc).AddTicks(2277), "AQAAAAEAACcQAAAAEFY7kJnwQiALGRCizZePTjyfufklsO2/H7N+Khw4lRrVNN6F6ATPVoe1iFAebh56sQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 1, 3, 14, 39, 56, 659, DateTimeKind.Utc).AddTicks(1286), "AQAAAAEAACcQAAAAEG+6AmyOkmh2FwuEUZwaCoP8oOscANK01q4N8TpmsOvuAc/GjNdS+/hTAwmaBwVZ3g==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileId",
                table: "SharedItems");

            migrationBuilder.DropColumn(
                name: "FolderId",
                table: "SharedItems");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 25, 17, 12, 29, 133, DateTimeKind.Utc).AddTicks(174), new DateTime(2024, 12, 25, 17, 12, 29, 133, DateTimeKind.Utc).AddTicks(316) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 25, 17, 12, 29, 133, DateTimeKind.Utc).AddTicks(459), new DateTime(2024, 12, 25, 17, 12, 29, 133, DateTimeKind.Utc).AddTicks(459) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 25, 17, 12, 29, 133, DateTimeKind.Utc).AddTicks(461), new DateTime(2024, 12, 25, 17, 12, 29, 133, DateTimeKind.Utc).AddTicks(461) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 25, 17, 12, 29, 133, DateTimeKind.Utc).AddTicks(462), new DateTime(2024, 12, 25, 17, 12, 29, 133, DateTimeKind.Utc).AddTicks(463) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 25, 17, 12, 29, 133, DateTimeKind.Utc).AddTicks(465), new DateTime(2024, 12, 25, 17, 12, 29, 133, DateTimeKind.Utc).AddTicks(466) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(8650), new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(8798) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(9071), new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(9072) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(9074), new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(9074) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(9075), new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(9076) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(9077), new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(9077) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(9080), new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(9081) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(9082), new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(9082) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(9083), new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(9084) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(7113), new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(7262) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(7414), new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(7415) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(7417), new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(7418) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(7419), new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(7419) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(7421), new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(7421) });

            migrationBuilder.UpdateData(
                table: "SharedItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "SharedAt",
                value: new DateTime(2024, 12, 25, 17, 12, 29, 133, DateTimeKind.Utc).AddTicks(1647));

            migrationBuilder.UpdateData(
                table: "SharedItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "SharedAt",
                value: new DateTime(2024, 12, 25, 17, 12, 29, 133, DateTimeKind.Utc).AddTicks(1923));

            migrationBuilder.UpdateData(
                table: "SharedItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "SharedAt",
                value: new DateTime(2024, 12, 25, 17, 12, 29, 133, DateTimeKind.Utc).AddTicks(1924));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 12, 25, 17, 12, 29, 127, DateTimeKind.Utc).AddTicks(7610), "AQAAAAEAACcQAAAAEBZ4BfJwUIMIUCXXxRwj8lhgefiscpN2jVuihOt8vdB1MM9TaxiOXTaVvqXsEA3vpQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 12, 25, 17, 12, 29, 128, DateTimeKind.Utc).AddTicks(9178), "AQAAAAEAACcQAAAAEJL7fjSdK2AWe1mCOaidJgvCVXGP+P8kkLPwXThG7W0FktYxHI9chAZe0PjUXgJnfw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 12, 25, 17, 12, 29, 129, DateTimeKind.Utc).AddTicks(9732), "AQAAAAEAACcQAAAAEMYrVSa+t5w5whb+8FHVbfGTc/DvZOjrfHdtPVZMME5c5WavrfEUKytbgmFgozMDzg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 12, 25, 17, 12, 29, 131, DateTimeKind.Utc).AddTicks(649), "AQAAAAEAACcQAAAAEPcTkRXifSWvt/IpXDlcZ35i2Z28C+Ti2+OfiPw9BXeLN82/Cjec0DZyM2o/hcOIcw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 12, 25, 17, 12, 29, 132, DateTimeKind.Utc).AddTicks(1154), "AQAAAAEAACcQAAAAEL3M1Hs9ldanWq9iW+S2RmIh+5zJdzS6jec6Ez/jWkmTPPkT6d35PyAmLG9LNLIewg==" });
        }
    }
}
