﻿using Microsoft.EntityFrameworkCore;
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

            entityBuilder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.CreatedAt).IsRequired().HasColumnType("DateTime");
            entityBuilder.Property(x => x.UpdatedBy).HasMaxLength(50);
            entityBuilder.Property(x => x.UpdatedAt).HasColumnType("DateTime");

        }
    }
}