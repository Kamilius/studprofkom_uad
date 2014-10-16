using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace studProfkom.Models.Mapping
{
  public class FacultyMap : EntityTypeConfiguration<Faculty>
  {
    public FacultyMap()
    {
      // Primary Key
      this.HasKey(t => t.Id)
          .HasMany(t => t.Applications)
          .WithRequired(a => a.Faculty)
          .WillCascadeOnDelete();

      // Properties
      this.Property(t => t.Name)
          .IsRequired();

      // Table & Column Mappings
      this.ToTable("Faculty");
      this.Property(t => t.Id).HasColumnName("Id");
      this.Property(t => t.Name).HasColumnName("Name");
    }
  }
}
