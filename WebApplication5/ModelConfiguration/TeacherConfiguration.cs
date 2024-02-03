using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication5.Models;

namespace WebApplication5.ModelConfiguration
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable(nameof(Teacher));
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(50);
            builder.Property(t => t.Email).HasMaxLength(50);
            builder.Property(t => t.Phone).HasMaxLength(50);
            builder.Property(t => t.Address).HasMaxLength(50);
            builder.Property(t => t.Salary);
        }
    }
}
