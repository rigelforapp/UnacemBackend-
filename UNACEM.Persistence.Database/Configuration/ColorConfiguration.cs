using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Persistence.Database.Configuration
{
    public class ColorConfiguration
    {
        public ColorConfiguration(EntityTypeBuilder<UNACEM.Domain.Color> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);

        }
    }
}
