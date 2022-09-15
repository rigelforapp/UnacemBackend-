using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNACEM.Persistence.Database.Configuration
{
    public class BudgetsCiConfiguration
    {
        public BudgetsCiConfiguration(EntityTypeBuilder<UNACEM.Domain.BudgetsCi> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Line).HasMaxLength(255);
            entityBuilder.Property(x => x.Description).HasMaxLength(255);
            entityBuilder.Property(x => x.Date).HasColumnType("DateTime");
            entityBuilder.Property(x => x.CreatedAt).HasColumnType("DateTime");
            entityBuilder.Property(x => x.UpdatedAt).HasColumnType("DateTime");
            entityBuilder.Property(x => x.DeletedAt).HasColumnType("DateTime");
        }
    }
}
