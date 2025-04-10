using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeLogService.Domain.Models.dbo;
using TimeLogService.Domain.Models.Dbo;

namespace TimeLogService.Infrastructure.AionTimeContext.Configurations
{
    public partial class WorkItemCommentConfiguration : IEntityTypeConfiguration<WorkItemComment>
    {
        public void Configure(EntityTypeBuilder<WorkItemComment> builder)
        {
            builder.ToTable("WorkItemComment");

            builder.Property(e => e.CommentText)
                .HasColumnType("varchar(max)")
                .IsUnicode(false);
            builder.Property(e => e.TenantId)
                .HasMaxLength(100);

            builder.HasOne(d => d.WorkItem)
                .WithMany(p => p.WorkItemComments)
                .HasPrincipalKey(p => p.Id)
                .HasForeignKey(d => d.WorkItemId)
                .HasConstraintName("FK_WorkItem_WorkItemComment")
                .OnDelete(DeleteBehavior.Cascade);

            OnConfigurePartial(builder);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<WorkItemComment> entity);
    }
}