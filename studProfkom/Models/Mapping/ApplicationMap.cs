using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace studProfkom.Models.Mapping
{
    public class ApplicationMap : EntityTypeConfiguration<Application>
    {
        public ApplicationMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.FullName)
                .IsRequired();

            this.Property(t => t.Phone)
                .IsRequired()
                .HasMaxLength(13);

            this.Property(t => t.CreateDate);

            this.Property(t => t.City)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Application");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FullName).HasColumnName("FullName");
            this.Property(t => t.FacultyId).HasColumnName("Faculty_FK");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.City).HasColumnName("City");
        }
    }
}
