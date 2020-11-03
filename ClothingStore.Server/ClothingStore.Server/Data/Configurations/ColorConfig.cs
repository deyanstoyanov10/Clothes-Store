﻿namespace ClothingStore.Server.Data.Configurations
{
    using Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static Infrastructure.EntityConfigConstants;

    public class ColorConfig : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(ColorNameMaxLength);

            builder
                .Property(c => c.HexCode)
                .IsRequired()
                .HasMaxLength(ColorHexMaxLength);
        }
    }
}
