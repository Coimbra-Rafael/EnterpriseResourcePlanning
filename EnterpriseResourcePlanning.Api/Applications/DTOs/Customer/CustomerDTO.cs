using EnterpriseResourcePlanning.Api.Applications.DTOs.Enterprise;

namespace EnterpriseResourcePlanning.Api.Applications.DTOs.Customer;

public record CustomerDTO(string CustomerId, string Name, string Email, DateTime CreateOn, DateTime UpdateOn,  IEnumerable<EnterpriseDTO> EnterpriseDto = null) : IDisposable
{
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}