using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Persistence.Database.Configuration
{
    public class BrickFormatsConfiguration
    {
        public BrickFormatsConfiguration(EntityTypeBuilder<UNACEM.Domain.BrickFormats> entityBuilder)
        {
            entityBuilder.HasKey(x => x.BrickFormatId);
            entityBuilder.Property(x => x.Group).HasColumnType("varchar").HasMaxLength(50);
            entityBuilder.Property(x => x.Brick_a).HasColumnType("varchar").HasMaxLength(50);
            entityBuilder.Property(x => x.Brick_b).HasColumnType("varchar").HasMaxLength(50);
            entityBuilder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.CreatedAt).IsRequired().HasColumnType("DateTime");
            entityBuilder.Property(x => x.UpdatedBy).HasMaxLength(50);
            entityBuilder.Property(x => x.UpdatedAt).HasColumnType("DateTime");

        }
    }
}
