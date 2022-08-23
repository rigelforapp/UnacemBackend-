using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace UNACEM.Common.Mapping
{
    public static class DtoMapperExtension
    {
        public static T MapTo<T>(this object value)
        {
            //var json = JsonSerializer.Serialize(harry, new JsonSerializerOptions()
            //{
            //    WriteIndented = true,
            //    ReferenceHandler = ReferenceHandler.Preserve
            //});
            var jsonOptions = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            return JsonSerializer.Deserialize<T>(
                JsonSerializer.Serialize(value, jsonOptions
                ), jsonOptions
                );
        }
    }
}
