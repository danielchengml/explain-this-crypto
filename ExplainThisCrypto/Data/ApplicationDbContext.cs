using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ExplainThisCrypto.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace ExplainThisCrypto.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Coin> Coins { get; set; }
        public virtual DbSet<Description> Descriptions { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Tag>()
                .HasKey(t => new { t.CoinId, t.CategoryId });

            builder.Entity<Tag>()
                .HasOne(p => p.Coin)
                .WithMany(p => p.Category)
                .HasForeignKey(y => y.CoinId);

            builder.Entity<Tag>()
                .HasOne(p => p.Category)
                .WithMany(p => p.Coin)
                .HasForeignKey(y => y.CategoryId);
        }

            

        internal IIncludableQueryable<Description, Coin> Where(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public DbSet<ExplainThisCrypto.Models.Tag> Tag { get; set; }
    }
}
