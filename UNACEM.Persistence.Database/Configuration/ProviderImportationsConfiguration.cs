using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UNACEM.Persistence.Database.Configuration
{
    public class ProviderImportationsConfiguration
    {
        public ProviderImportationsConfiguration(EntityTypeBuilder<UNACEM.Domain.ProviderImportations> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
    
            entityBuilder.Property(x => x.Created_By).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.Created_At).IsRequired().HasColumnType("DateTime");
            entityBuilder.Property(x => x.Updated_By).HasMaxLength(50);
            entityBuilder.Property(x => x.Updated_At).HasColumnType("DateTime");
        }
    }
}
