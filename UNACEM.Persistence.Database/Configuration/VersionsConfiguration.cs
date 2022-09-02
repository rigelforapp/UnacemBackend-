using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Persistence.Database.Configuration
{
    public class VersionsConfiguration
    {
        public VersionsConfiguration(EntityTypeBuilder<UNACEM.Domain.Versions> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Date_Ini).IsRequired().HasColumnType("Date");
            entityBuilder.Property(x => x.Date_End).IsRequired().HasColumnType("Date");

            entityBuilder.Property(x => x.Created_At).IsRequired().HasColumnType("DateTime");
            entityBuilder.Property(x => x.Updated_At).HasColumnType("DateTime");

        }
    }
}
