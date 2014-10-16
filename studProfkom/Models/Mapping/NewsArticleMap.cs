using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace studProfkom.Models.Mapping
{
    public class NewsArticleMap : EntityTypeConfiguration<NewsArticle>
    {
        public NewsArticleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Text)
                .IsRequired();

            this.Property(t => t.ImageName)
              .IsRequired();

            this.Property(t => t.EventShortDescription)
                .HasMaxLength(50);

            this.Property(t => t.ArticleShortDescription)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("NewsArticle");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.PublicationDate).HasColumnName("PublicationDate");
            this.Property(t => t.Text).HasColumnName("Text");
            this.Property(t => t.ImageName).HasColumnName("ImageName");
            this.Property(t => t.IsEvent).HasColumnName("IsEvent");
            this.Property(t => t.EventStartDate).HasColumnName("EventStartDate");
            this.Property(t => t.EventShortDescription).HasColumnName("EventShortDescription");
            this.Property(t => t.GooglePlusUserId).HasColumnName("GooglePlusUserId");
            this.Property(t => t.GooglePlusAlbumId).HasColumnName("GooglePlusAlbumId");
            this.Property(t => t.ArticleShortDescription).HasColumnName("ArticleShortDescription");
        }
    }
}
