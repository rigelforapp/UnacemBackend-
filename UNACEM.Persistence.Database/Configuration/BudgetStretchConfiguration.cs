using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Persistence.Database.Configuration
{
    public class BudgetStretchConfiguration
    {
        public BudgetStretchConfiguration(EntityTypeBuilder<UNACEM.Domain.BudgetStretch> entityBuilder)
        {
            entityBuilder.HasKey(x => x.BudgetStretchId);
            entityBuilder.Property(x => x.CreatedAt).IsRequired().HasColumnType("DateTime");
            entityBuilder.Property(x => x.UpdatedAt).HasColumnType("DateTime");
        }
    }
}
