using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PinoyCode.Cqrs.Models;
using PinoyCode.Data.Infrustracture;
using PinoyCode.Domain.Ads.Models;
using PinoyCode.Domain.Identity;
using PinoyCode.Domain.Identity.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PinoyCode.Domain.Ads
{
    public class AdsDbContext : IdentityDbContext<User, Role, Guid>, IDbContext
    {
        private readonly IServiceProvider _serviceProvider;
        public AdsDbContext(IServiceProvider serviceProvider, DbContextOptions<AdsDbContext> options)
            :base(options)
        {
            _serviceProvider = serviceProvider;
        }

        public DbSet<AdPost> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AdPostImage> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(b =>
            {
                b.ToTable("Categories");
                b.Property(p => p.CreatedOnUtc)
                  .ValueGeneratedOnAdd();
                b.HasOne(p => p.Parent)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(p => p.ParentId);

                b.HasMany(p => p.Categories)
                    .WithOne(p => p.Parent)
                    .HasForeignKey(p => p.ParentId);

            });


            modelBuilder.Entity<AdPost>(b =>
            {
                b.ToTable("AdPosts");
                b.Property(p => p.CreatedOnUtc)
                  .ValueGeneratedOnAdd();
                b.HasMany(p => p.Images)
                  .WithOne(p => p.AdPost)
                  .HasForeignKey(p => p.AdPostId)
                  .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(p => p.FeaturedAd)
                  .WithOne(p => p.AdPost)
                  .HasForeignKey<FeaturedAd>(p => p.PostId);

            });

            modelBuilder.Entity<AdPostImage>(b =>
            {
                b.HasOne(p => p.AdPost)
                  .WithMany(p => p.Images)
                  .HasForeignKey(p => p.AdPostId);
                 
                b.ToTable("AdPostImages");
            });

            modelBuilder.Entity<FeaturedAd>(b =>
            {
                b.HasOne(p => p.AdPost)
                 .WithOne(p => p.FeaturedAd);
                b.Property(p => p.FeaturedOnUtc)
                  .ValueGeneratedOnAdd();

                b.HasIndex(p => p.PostId);

                b.ToTable("FeaturedAds");
            });

            /* Aggregates models from Cqrs pattern */

            modelBuilder.Entity<Aggregate>(b =>
                {
                    b.HasKey(p => p.Id);
         
                    b.HasMany(p => p.Events)
                      .WithOne(p => p.Aggregate)
                      .HasForeignKey(p => p.AggregateId)
                      .OnDelete(DeleteBehavior.Cascade);

                    b.ToTable("Aggregates");
                });


            modelBuilder.Entity<Event>(b =>
            {
                b.HasKey(p => p.Id);
                b.HasOne(p => p.Aggregate)
                  .WithMany(p => p.Events)
                  .HasForeignKey(p => p.AggregateId)
                  .OnDelete(DeleteBehavior.Cascade);

                b.ToTable("Events");
            });


            base.OnModelCreating(modelBuilder);

            foreach (var model in modelBuilder.Model.GetEntityTypes()
              .Where(p => p.Relational().TableName.StartsWith(@"AspNet")))
                {
                    string tableName = model.Relational().TableName.Remove(0, @"AspNet".Length);
                    model.Relational().TableName = tableName;
                }
        }

        public DbSet<T> Table<T>() where T : class
        {
            return base.Set<T>();
        }

        public int Commit()
        {
            return this.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await base.SaveChangesAsync();
        }

        public T GetService<T>()
        {
            return (T)_serviceProvider.GetService(typeof(T));
        }

     
    }
}
