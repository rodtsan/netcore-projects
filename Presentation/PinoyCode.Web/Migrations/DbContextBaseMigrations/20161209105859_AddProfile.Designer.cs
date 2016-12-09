using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PinoyCode.Data;

namespace PinoyCode.Web.Migrations.DbContextBaseMigrations
{
    [DbContext(typeof(DbContextBase))]
    [Migration("20161209105859_AddProfile")]
    partial class AddProfile
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PinoyCode.Data.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<DateTime>("RegisteredOn");

                    b.HasKey("Id");

                    b.ToTable("Profiles");
                });
        }
    }
}
