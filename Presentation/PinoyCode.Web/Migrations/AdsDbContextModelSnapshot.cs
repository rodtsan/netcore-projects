using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PinoyCode.Domain.Ads;
using PinoyCode.Domain.Ads.Models;

namespace PinoyCode.Web.Migrations
{
    [DbContext(typeof(AdsDbContext))]
    partial class AdsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("PinoyCode.Cqrs.Models.Aggregate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AggregateType");

                    b.Property<DateTime>("CommitDateTime");

                    b.HasKey("Id");

                    b.ToTable("Aggregates");
                });

            modelBuilder.Entity("PinoyCode.Cqrs.Models.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AggregateId");

                    b.Property<string>("Body");

                    b.Property<DateTime>("CommitDateTime");

                    b.Property<int>("SequenceNumber");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("AggregateId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("PinoyCode.Domain.Ads.Models.AdPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime>("CreatedOnUtc")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(4000);

                    b.Property<bool>("Disabled");

                    b.Property<int>("Order");

                    b.Property<double>("Price");

                    b.Property<string>("Title")
                        .HasMaxLength(256);

                    b.Property<int>("Type");

                    b.Property<int?>("UpdatedById");

                    b.Property<DateTime?>("UpdatedOnUtc");

                    b.HasKey("Id");

                    b.ToTable("AdPosts");
                });

            modelBuilder.Entity("PinoyCode.Domain.Ads.Models.AdPostImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdPostId");

                    b.Property<byte[]>("ImageData");

                    b.Property<string>("ImageName")
                        .HasMaxLength(256);

                    b.Property<string>("ImageType")
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.HasIndex("AdPostId");

                    b.ToTable("AdPostImages");
                });

            modelBuilder.Entity("PinoyCode.Domain.Ads.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime>("CreatedOnUtc")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(4000);

                    b.Property<bool>("Disabled");

                    b.Property<int>("Order");

                    b.Property<int?>("ParentId");

                    b.Property<string>("Title")
                        .HasMaxLength(256);

                    b.Property<int?>("UpdatedById");

                    b.Property<DateTime?>("UpdatedOnUtc");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PinoyCode.Domain.Ads.Models.FeaturedAd", b =>
                {
                    b.Property<int>("PostId");

                    b.Property<DateTime>("ExpiredOnUtc");

                    b.Property<int?>("FeaturedById");

                    b.Property<DateTime?>("FeaturedOnUtc")
                        .ValueGeneratedOnAdd();

                    b.HasKey("PostId");

                    b.HasIndex("PostId");

                    b.ToTable("FeaturedAds");
                });

            modelBuilder.Entity("PinoyCode.Domain.Identity.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("PinoyCode.Domain.Identity.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("PinoyCode.Domain.Identity.Models.Role")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("PinoyCode.Domain.Identity.Models.User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("PinoyCode.Domain.Identity.Models.User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("PinoyCode.Domain.Identity.Models.Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PinoyCode.Domain.Identity.Models.User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PinoyCode.Cqrs.Models.Event", b =>
                {
                    b.HasOne("PinoyCode.Cqrs.Models.Aggregate", "Aggregate")
                        .WithMany("Events")
                        .HasForeignKey("AggregateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PinoyCode.Domain.Ads.Models.AdPostImage", b =>
                {
                    b.HasOne("PinoyCode.Domain.Ads.Models.AdPost", "AdPost")
                        .WithMany("Images")
                        .HasForeignKey("AdPostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PinoyCode.Domain.Ads.Models.Category", b =>
                {
                    b.HasOne("PinoyCode.Domain.Ads.Models.Category", "Parent")
                        .WithMany("Categories")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("PinoyCode.Domain.Ads.Models.FeaturedAd", b =>
                {
                    b.HasOne("PinoyCode.Domain.Ads.Models.AdPost", "AdPost")
                        .WithOne("FeaturedAd")
                        .HasForeignKey("PinoyCode.Domain.Ads.Models.FeaturedAd", "PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
