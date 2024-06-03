namespace TunNetCom.AionTime.AzureDevopsService.API.Data.Configurations;

public partial class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
#pragma warning disable CA1725 // Parameter names should match base declaration
    public void Configure(EntityTypeBuilder<Organization> entity)
#pragma warning restore CA1725 // Parameter names should match base declaration
    {
        _ = entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07DE523F87");

        _ = entity.ToTable("Organization");

        _ = entity.HasIndex(e => e.Name, "IX_Organization_Name_Unique").IsUnique();

        _ = entity.Property(e => e.Name).HasMaxLength(255);
        _ = entity.Property(e => e.Pat).HasMaxLength(150);

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<Organization> entity);
}