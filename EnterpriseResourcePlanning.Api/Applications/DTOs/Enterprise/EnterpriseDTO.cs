namespace EnterpriseResourcePlanning.Api.Applications.DTOs.Enterprise;

public record EnterpriseDTO(string FirstName, string LastName, string CnpjCpf, string StateRegistration) : IDisposable
{
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}