﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Persistence.Database.Configuration
{
    public class HeadquartersConfiguration
    {
        public HeadquartersConfiguration(EntityTypeBuilder<UNACEM.Domain.Headquarters> entityBuilder)
        {
            entityBuilder.HasKey(x => x.HeadquarterId);
            entityBuilder.Property(x => x.CreatedAt).IsRequired().HasColumnType("DateTime");
            entityBuilder.Property(x => x.UpdatedAt).HasColumnType("DateTime");
        }
    }
}