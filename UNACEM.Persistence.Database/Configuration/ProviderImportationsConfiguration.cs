using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UNACEM.Persistence.Database.Configuration
{
    public class ProviderImportationsConfiguration
    {
        public ProviderImportationsConfiguration(EntityTypeBuilder<UNACEM.Domain.ProviderImportations> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
    
            //entityBuilder.Property(x => x.CreatedBy);
            entityBuilder.Property(x => x.CreatedAt).IsRequired().HasColumnType("DateTime");
            //entityBuilder.Property(x => x.UpdatedBy);
            entityBuilder.Property(x => x.UpdatedAt).HasColumnType("DateTime");
        }
    }
}
