using EnterpriseResourcePlanning.Api.Applications.DTOs.Address;

namespace EnterpriseResourcePlanning.Api.Applications.DTOs.Enterprise;

public record CreateEnterpriseDTO(string FirstName, string LastName, string CnpjCpf, string StateRegistration, CreateAddressDTO CreateAddressDto) : IDisposable
{
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}