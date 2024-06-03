namespace TunNetCom.AionTime.AzureDevopsService.API.Data.Configurations
{
    public partial class AzureDevopsHistoryConfiguration : IEntityTypeConfiguration<AzureDevopsHistory>
    {
#pragma warning disable CA1725 // Parameter names should match base declaration
        public void Configure(EntityTypeBuilder<AzureDevopsHistory> entity)
#pragma warning restore CA1725 // Parameter names should match base declaration
        {
            _ = entity.ToTable("AzureDevopsHistory");

            _ = entity.Property(e => e.Email).HasMaxLength(50);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<AzureDevopsHistory> entity);
    }
}