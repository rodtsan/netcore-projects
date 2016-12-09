using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using CqrsModels = PinoyCode.Cqrs.Models;

namespace PinoyCode.Web.Migrations.DbContextBaseMigrations
{
    public partial class AddAggregate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(name: "Aggregates",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                AggregateType = table.Column<string>(nullable:true),
                CommitDateTime = table.Column<DateTime>(nullable:true)
            },constraints: table =>
            {
                table.PrimaryKey("PK_Aggregates", x => x.Id);
            });

            migrationBuilder.CreateTable(name: "Events",
           columns: table => new
           {
               Id = table.Column<Guid>(nullable: false),
               Type = table.Column<string>(nullable: true),
               Body = table.Column<string>(nullable: true),
               CommitDateTime = table.Column<DateTime>(nullable: true),
               SequenceNumber = table.Column<int>(nullable: true),
               AggregateId = table.Column<Guid>(nullable: false),
           }, constraints: table =>
           {
               table.PrimaryKey("PK_Events", x => x.Id);
               table.ForeignKey(
                        name: "FK_Events_Aggregates_AggregateId",
                        column: x => x.AggregateId,
                        principalTable: "Aggregates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
           });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Events");

            migrationBuilder.DropTable(
             name: "Aggregates");
        }
    }
}
