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
            entityBuilder.Property(x => x.BrickA).HasColumnType("varchar").HasMaxLength(50);
            entityBuilder.Property(x => x.BrickB).HasColumnType("varchar").HasMaxLength(50);
            entityBuilder.Property(x => x.CreatedAt).IsRequired().HasColumnType("DateTime");
            entityBuilder.Property(x => x.UpdatedAt).HasColumnType("DateTime");
        }
    }
}
