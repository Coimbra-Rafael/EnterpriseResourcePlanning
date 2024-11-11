namespace EnterpriseResourcePlanning.Api.Applications.DTOs.Customer;

public record CreateCustomerDTO(string Licenca, string Name, string Email) : IDisposable
{
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}