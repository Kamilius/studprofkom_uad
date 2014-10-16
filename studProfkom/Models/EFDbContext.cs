using studProfkom.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace studProfkom.Models
{
	public partial class EFDbContext : DbContext
	{
		static EFDbContext()
		{
			Database.SetInitializer<EFDbContext>(null);
		}

		public EFDbContext()
			: base("Name=StudProfkomUADConnectionString")
		{
		}

		public DbSet<NewsArticle> NewsArticles { get; set; }
		public DbSet<Application> Applications { get; set; }
    public DbSet<Faculty> Faculties { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new NewsArticleMap());
      modelBuilder.Configurations.Add(new ApplicationMap());
      modelBuilder.Configurations.Add(new FacultyMap());
		}
	}
}