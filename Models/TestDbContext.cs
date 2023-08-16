using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace odata_error.Models
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
            Database.EnsureCreated();

            this.LoadTestData();

        }



        public DbSet<AzureClassUser> AzureClassUsers { get; set; } = default!;


        public DbSet<ConfigNode> ConfigNodes { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AzureClassUser>();

            modelBuilder.Entity<ConfigNode>()
                .HasAlternateKey(cn => new { cn.ParentCode, cn.Code });

            modelBuilder.Entity<ConfigNode>()
                .HasOne<ConfigNode>(cn => cn.CodeType)
                .WithMany(cn => cn.CodeTypeConfigNodeValues)
                .HasForeignKey(cn => new { cn.CodeTypeKey, cn.CodeTypeCode })
                .HasPrincipalKey(cn => new { cn.ParentCode, cn.Code });

            modelBuilder.Entity<ConfigNode>()
                .HasOne<ConfigNode>(cn => cn.ValueType)
                .WithMany(cn => cn.ValueTypeConfigNodeValues)
                .HasForeignKey(cn => new { cn.ValueTypeKey, cn.ValueTypeCode })
                .HasPrincipalKey(cn => new { cn.ParentCode, cn.Code });

            modelBuilder.Entity<ConfigNode>()
                .HasMany(cn => cn.UserClassAzureClassUsers)
                .WithOne(u => u.UserClass)
                .HasForeignKey(u => new { u.UserClassKey, u.UserClassCode })
                .HasPrincipalKey(cn => new { cn.ParentCode, cn.Code });

        }

    }


}
