using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNACEM.Persistence.Database.Configuration
{
    public class TicknessConfiguration
    {
        public TicknessConfiguration(EntityTypeBuilder<UNACEM.Domain.Tickness> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
        }
    }
}
