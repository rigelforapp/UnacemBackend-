using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Persistence.Database.Configuration
{
    public class ColorConfiguration
    {
        public ColorConfiguration(EntityTypeBuilder<UNACEM.Domain.Color> entityBuilder)
        {
            entityBuilder.HasKey(x => x.ColorId);

            entityBuilder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.CreatedAt).IsRequired().HasColumnType("DateTime");
            entityBuilder.Property(x => x.UpdatedBy).HasMaxLength(50);
            entityBuilder.Property(x => x.UpdatedAt).HasColumnType("DateTime");

        }
    }
}
