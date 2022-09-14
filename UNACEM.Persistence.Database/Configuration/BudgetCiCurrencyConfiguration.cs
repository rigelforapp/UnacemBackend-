using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNACEM.Persistence.Database.Configuration
{
    public class BudgetCiCurrencyConfiguration
    {
        public BudgetCiCurrencyConfiguration(EntityTypeBuilder<UNACEM.Domain.BudgetCiCurrency> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Name).HasColumnType("varchar").HasMaxLength(500);
            entityBuilder.Property(x => x.Symbol).HasColumnType("varchar").HasMaxLength(500);
            entityBuilder.Property(x => x.UpdatedAt).HasColumnType("DateTime");
        }
    }
}
