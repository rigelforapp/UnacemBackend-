using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Persistence.Database.Configuration
{
    public class BudgetsConfiguration
    {
        public BudgetsConfiguration(EntityTypeBuilder<UNACEM.Domain.Budgets> entityBuilder)
        {
            entityBuilder.HasKey(x => x.BudgetId);                      
            entityBuilder.Property(x => x.CreatedAt).HasColumnType("DateTime");
            entityBuilder.Property(x => x.UpdatedAt).HasColumnType("DateTime");
        }
    }
}