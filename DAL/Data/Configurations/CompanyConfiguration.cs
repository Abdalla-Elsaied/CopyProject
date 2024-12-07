
namespace DAL;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {

        builder.Property(c => c.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(c => c.Email)
               .IsRequired()
               .HasMaxLength(150);

        builder.HasIndex(c => c.Email)
               .IsUnique();

        builder.Property(c => c.Password)
               .IsRequired();

     
    }
}
