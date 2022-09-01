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
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Group).HasColumnType("varchar").HasMaxLength(50);
            entityBuilder.Property(x => x.Brick_a).HasColumnType("varchar").HasMaxLength(50);
            entityBuilder.Property(x => x.Brick_b).HasColumnType("varchar").HasMaxLength(50);
            entityBuilder.Property(x => x.Created_At).IsRequired().HasColumnType("DateTime");
            entityBuilder.Property(x => x.Updated_At).HasColumnType("DateTime");
        }
    }
}
