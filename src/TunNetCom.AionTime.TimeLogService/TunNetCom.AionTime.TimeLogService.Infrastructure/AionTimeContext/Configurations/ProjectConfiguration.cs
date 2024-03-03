namespace TunNetCom.AionTime.TimeLogService.Infrastructure.AionTimeContext.Configurations;

public partial class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> entity)
    {
        entity.Property(e => e.Id).ValueGeneratedNever();

        entity.HasOne(d => d.Organisation).WithMany(p => p.Projects).HasConstraintName("FKOrganisationProject");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<Project> entity);
}
