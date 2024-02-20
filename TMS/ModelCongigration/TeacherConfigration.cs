using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMS.Models;

namespace TMS.ModelCongigration;

public class TeacherConfigration : IEntityTypeConfiguration<Teacher>
{
	public void Configure(EntityTypeBuilder<Teacher> builder)
	{
		builder.ToTable(nameof(Teacher));
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Name).HasMaxLength(56).IsRequired();
		builder.Property(x => x.Phone).HasMaxLength(56).IsRequired();
		builder.Property(x => x.Email).HasMaxLength(56).IsRequired();
		builder.Property(x => x.Address).HasMaxLength(56).IsRequired();

	}
}
