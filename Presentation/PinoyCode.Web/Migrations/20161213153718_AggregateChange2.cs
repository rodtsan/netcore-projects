using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PinoyCode.Web.Migrations
{
    public partial class AggregateChange2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FeaturedAds_PostId",
                table: "FeaturedAds");

            migrationBuilder.CreateIndex(
                name: "IX_FeaturedAds_PostId",
                table: "FeaturedAds",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FeaturedAds_PostId",
                table: "FeaturedAds");

            migrationBuilder.CreateIndex(
                name: "IX_FeaturedAds_PostId",
                table: "FeaturedAds",
                column: "PostId",
                unique: true);
        }
    }
}
