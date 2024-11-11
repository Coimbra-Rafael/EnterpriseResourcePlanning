namespace EnterpriseResourcePlanning.Api.Applications.DTOs.Address;

public record CreateAddressDTO(string Cep, string PublicPlace, string Complement, string Neighborhood, string NumberAddress, string Telephone) : IDisposable
{
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}