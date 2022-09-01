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
            entityBuilder.HasKey(x => x.Id);           
            entityBuilder.Property(x => x.Created_At).IsRequired().HasColumnType("DateTime");
            entityBuilder.Property(x => x.Updated_At).HasColumnType("DateTime");
        }
    }
}
