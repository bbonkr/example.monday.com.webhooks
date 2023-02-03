using Example.MondayCom.Webhooks.App.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.MondayCom.Webhooks.App.DbContexts.EntityTypeConfigurations;

public class MondayComRequestTypeConfiguration : IEntityTypeConfiguration<MondayComRequest>
{
    public void Configure(EntityTypeBuilder<MondayComRequest> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(36)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Headers);
        builder.Property(x => x.Payload);

        builder.ToTable("MondayComRequests");
    }
}
