﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Software_Project.Migrations
{
    public partial class Roles : Migration
    {
                protected override void Up(MigrationBuilder migrationBuilder)
                {
                    migrationBuilder.InsertData(
                        table: "AspNetRoles",
                        columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                        values: new object[] { Guid.NewGuid().ToString(), "Doctor", "Doctor".ToUpper(), Guid.NewGuid().ToString() }
                        );
                    migrationBuilder.InsertData(
                    table: "AspNetRoles",
                    columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                    values: new object[] { Guid.NewGuid().ToString(), "Admin", "Admin".ToUpper(), Guid.NewGuid().ToString() }
                    );
                   migrationBuilder.InsertData(
                    table: "AspNetRoles",
                    columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                    values: new object[] { Guid.NewGuid().ToString(), "Patient", "Patient".ToUpper(), Guid.NewGuid().ToString() }
                    );
        }

                protected override void Down(MigrationBuilder migrationBuilder)
                {
                    migrationBuilder.Sql("Delete from [AspNetRoles]");
                }
    }
}
