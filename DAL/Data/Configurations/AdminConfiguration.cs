

namespace DAL;

public class AdminConfiguration : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
      
        builder.Property(a => a.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(a => a.Email)
               .IsRequired()
               .HasMaxLength(150);

        builder.HasIndex(a => a.Email)
               .IsUnique();

        builder.Property(a => a.Password)
               .IsRequired();
     
    }
}
