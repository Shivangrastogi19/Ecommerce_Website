using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.DatabaseContext
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions <ApplicationDbContext>options) : base(options)
		{
		}
		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	modelBuilder.Entity<Product>()
		//		.HasOne(p => p.Category)
		//		.WithMany(c => c.Products)
		//		.HasForeignKey(p => p.Category_id);

		//	modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
		//}
		public DbSet<Category> Categories{ get; set; }
		public DbSet<Product> Products{ get; set; }
	}
}
