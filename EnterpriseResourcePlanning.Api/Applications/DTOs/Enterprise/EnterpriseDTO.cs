using EnterpriseResourcePlanning.Api.Applications.DTOs.Address;

namespace EnterpriseResourcePlanning.Api.Applications.DTOs.Enterprise;

public record EnterpriseDTO(string EnterpriseId, string FirstName, string LastName, string CnpjCpf, string StateRegistration,AddressDTO AddressDto =  null) : IDisposable
{
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}