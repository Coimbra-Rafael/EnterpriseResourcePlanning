using EnterpriseResourcePlanning.Api.Domain.Structs;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EnterpriseResourcePlanning.Api.Infrastructure.ConvertTypes;

public class CustomizedGuidConvert : ValueConverter<CustomizedGuid, Guid>
{
    public CustomizedGuidConvert(ConverterMappingHints? mappingHints = null)
        : base(
            id => id.Values,
            value => new CustomizedGuid(value),
            mappingHints)
    {
    }
}