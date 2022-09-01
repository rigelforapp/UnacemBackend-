using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Persistence.Database.Configuration
{
    public class StretchsConfiguration
    {
        public StretchsConfiguration(EntityTypeBuilder<UNACEM.Domain.Stretchs> entityBuilder)
        {
            entityBuilder.HasKey(x => x.StretchId);
            entityBuilder.Property(x => x.Created_At).IsRequired().HasColumnType("DateTime");
            entityBuilder.Property(x => x.Updated_At).HasColumnType("DateTime");
        }
    }
}
