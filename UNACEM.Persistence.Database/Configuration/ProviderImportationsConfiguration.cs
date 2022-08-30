﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UNACEM.Persistence.Database.Configuration
{
    public class ProviderImportationsConfiguration
    {
        public ProviderImportationsConfiguration(EntityTypeBuilder<UNACEM.Domain.ProviderImportations> entityBuilder)
        {
            entityBuilder.HasKey(x => x.ProviderImportationId);
    
            entityBuilder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.CreatedAt).IsRequired().HasColumnType("DateTime");
            entityBuilder.Property(x => x.UpdatedBy).HasMaxLength(50);
            entityBuilder.Property(x => x.UpdatedAt).HasColumnType("DateTime");
        }
    }
}