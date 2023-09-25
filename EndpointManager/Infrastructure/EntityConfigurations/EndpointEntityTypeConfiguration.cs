namespace Infrastructure.EntityConfigurations
{
    using Domain.Endpoint.Enum;
    using Domain.Endpoint.Model;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Endpoint Entity definition.
    /// </summary>
    public class EndpointEntityTypeConfiguration : IEntityTypeConfiguration<EndpointEntity>
    {
        /// <summary>
        /// Configure entity.
        /// </summary>
        /// <param name="builder">Entity type builder.</param>
        public void Configure(EntityTypeBuilder<EndpointEntity> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.SerialNumber).IsRequired();
            builder.Property(b => b.ModelId).IsRequired();
            builder.Property(b => b.MeterNumber).IsRequired();
            builder.Property(b => b.FirmwareVersion).IsRequired();
            builder.Property(b => b.State).IsRequired();
        }
    }
}
