using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleShop.DataAccess.Entities;
using SimpleShop.Core.models;

namespace SimpleShop.DataAccess.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<ItemEntity>
    {
        public void Configure(EntityTypeBuilder<ItemEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(i => i.Title)
                .HasMaxLength(Item.MAX_TITLE_LENGTH)
                .IsRequired();
            builder.Property(i => i.Description)
                .IsRequired();
            builder.Property(i => i.Price)
                .IsRequired();
        }
    }
}
