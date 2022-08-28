using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Persistence.Database.Configuration
{
    public class UsersConfiguration
    {
        public UsersConfiguration(EntityTypeBuilder<UNACEM.Domain.Users> entityBuilder)
        {
            entityBuilder.HasKey(x => x.UserId);           
            entityBuilder.Property(x => x.CreatedAt).IsRequired().HasColumnType("DateTime");
            entityBuilder.Property(x => x.UpdatedAt).HasColumnType("DateTime");
        }
    }
}
