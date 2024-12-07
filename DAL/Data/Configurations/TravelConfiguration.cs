namespace DAL;

public class TravelConfiguration : IEntityTypeConfiguration<Travel>
{
    public void Configure(EntityTypeBuilder<Travel> builder)
    {

        builder.Property(t => t.Title)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(t => t.Description)
               .IsRequired()
               .HasMaxLength(1000);

        builder.Property(t => t.Price)
               .IsRequired()
               .HasColumnType("decimal(18,2)");

        builder.Property(t => t.CreatedAt)
               .HasDefaultValueSql("GETUTCDATE()");

        builder.HasOne(t => t.Company)
               .WithMany(c => c.Travels)
               .HasForeignKey(t => t.CompanyId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Company).WithMany(e => e.Travels).HasForeignKey(e => e.CompanyId);
    }
}
