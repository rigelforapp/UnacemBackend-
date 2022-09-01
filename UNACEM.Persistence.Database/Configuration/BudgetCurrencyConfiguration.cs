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
            entityBuilder.HasKey(x => x.BudgetCurrencyId);
          
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.Symbol).IsRequired().HasMaxLength(50);

            entityBuilder.Property(x => x.Created_At).IsRequired().HasColumnType("DateTime");
            entityBuilder.Property(x => x.Updated_At).HasColumnType("DateTime");
        }
    }
}
