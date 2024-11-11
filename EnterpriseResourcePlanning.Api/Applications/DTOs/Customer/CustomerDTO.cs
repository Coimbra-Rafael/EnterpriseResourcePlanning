namespace EnterpriseResourcePlanning.Api.Applications.DTOs.Customer;

public record CustomerDTO(string CustomerId, string Name, string Email, DateTime CreateOn, DateTime UpdateOn) : IDisposable
{
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}