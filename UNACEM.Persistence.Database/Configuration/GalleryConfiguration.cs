using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Persistence.Database.Configuration
{
    public class GalleryConfiguration
    {
        public GalleryConfiguration(EntityTypeBuilder<UNACEM.Domain.Gallery> entityBuilder)
        {
            entityBuilder.HasKey(x => x.GalleryId);
            entityBuilder.Property(x => x.Type).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Description).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Title).IsRequired().HasMaxLength(50);

        }
    }
}
