using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Persistence.Database.Configuration
{
    public class BudgetCurrencyConfiguration
    {
        public BudgetCurrencyConfiguration(EntityTypeBuilder<UNACEM.Domain.BudgetCurrency> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
          
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(4000);
            entityBuilder.Property(x => x.Symbol).IsRequired().HasMaxLength(4000);

            entityBuilder.Property(x => x.CreatedAt).IsRequired().HasColumnType("DateTime");
            entityBuilder.Property(x => x.UpdatedAt).HasColumnType("DateTime");
        }
    }
}
