using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNACEM.Persistence.Database.Configuration
{
    public class ProviderInsulatingsConfiguration
    {
        public ProviderInsulatingsConfiguration(EntityTypeBuilder<UNACEM.Domain.ProviderInsulatings> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Name).HasColumnType("varchar").HasMaxLength(400);
            entityBuilder.Property(x => x.RecommendedZone).HasColumnType("varchar").HasMaxLength(4000);
            entityBuilder.Property(x => x.Composition).HasColumnType("varchar").HasMaxLength(4000);
            entityBuilder.Property(x => x.WaterMix).HasColumnType("varchar").HasMaxLength(4000);
            //entityBuilder.Property(x => x.CreatedAt).IsRequired().HasColumnType("DateTime");
            entityBuilder.Property(x => x.UpdatedAt).HasColumnType("DateTime");
        }
    }
}
