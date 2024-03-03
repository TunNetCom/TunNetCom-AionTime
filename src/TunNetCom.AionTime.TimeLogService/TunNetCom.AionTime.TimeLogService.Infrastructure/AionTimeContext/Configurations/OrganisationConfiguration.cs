namespace TunNetCom.AionTime.TimeLogService.Infrastructure.AionTimeContext.Configurations;

public partial class OrganisationConfiguration : IEntityTypeConfiguration<Organisation>
{
    public void Configure(EntityTypeBuilder<Organisation> entity)
    {
        entity.Property(e => e.Id).ValueGeneratedNever();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<Organisation> entity);
}
