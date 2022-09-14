using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Persistence.Database.Configuration
{
    public class ProviderBricksConfiguration
    {
        public ProviderBricksConfiguration(EntityTypeBuilder<UNACEM.Domain.ProviderBricks> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);

            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.RecommendedZone).IsRequired().HasMaxLength(1000);
            entityBuilder.Property(x => x.Composition).IsRequired().HasMaxLength(1000);
            entityBuilder.Property(x => x.Density).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Porosity).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Ccs).IsRequired().HasMaxLength(100);
            //entityBuilder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(50);
            //entityBuilder.Property(x => x.CreationDate).IsRequired().HasColumnType("DateTime");
            //entityBuilder.Property(x => x.ModifiedBy).HasMaxLength(50);
            //entityBuilder.Property(x => x.ModificationDate).HasColumnType("DateTime");
        }
    }
}
