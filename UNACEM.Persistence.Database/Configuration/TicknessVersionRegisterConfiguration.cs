using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNACEM.Persistence.Database.Configuration
{
    public class TicknessVersionRegisterConfiguration
    {
        public TicknessVersionRegisterConfiguration(EntityTypeBuilder<UNACEM.Domain.TicknessVersionRegisters> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
        }
    }
}
