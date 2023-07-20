namespace Infrastructure.EntityConfigurations
{
    using Domain.Example.Model;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Example entity configuration/mapping.
    /// </summary>
    public class ExampleEntityTypeConfiguration
        : IEntityTypeConfiguration<ExampleEntity>
    {
        /// <summary>
        /// Configure entity.
        /// </summary>
        /// <param name="builder">Entity builder.</param>
        public void Configure(EntityTypeBuilder<ExampleEntity> builder)
        {
            builder.ToTable("Example", "dbo");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).UseIdentityColumn();
            builder.Property(x => x.Name);
            builder.Property(x => x.Age);
            builder.Property(x => x.CreationDate);
            builder.Property(x => x.Value);
        }
    }
}
