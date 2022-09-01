using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Persistence.Database.Configuration
{
    public class TyresConfiguration
    {
        public TyresConfiguration(EntityTypeBuilder<UNACEM.Domain.Tyres> entityBuilder)
        {
            entityBuilder.HasKey(x => x.TyreId);

            entityBuilder.Property(x => x.Created_At).IsRequired().HasColumnType("DateTime");
            entityBuilder.Property(x => x.Updated_At).HasColumnType("DateTime");

        }
    }
}
