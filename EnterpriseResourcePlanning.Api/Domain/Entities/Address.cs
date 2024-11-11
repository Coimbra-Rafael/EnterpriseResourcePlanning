using EnterpriseResourcePlanning.Api.Domain.Abstractions;
using EnterpriseResourcePlanning.Api.Domain.Structs;

namespace EnterpriseResourcePlanning.Api.Domain.Entities;

public class Address : Entity, IDisposable
{
    public CustomizedGuid AddressId { get; set; }
    public string Cep { get; set; }
    public string PublicPlace { get; set; }
    public string Complement { get; set; }
    public string Neighborhood { get; set; }
    public string NumberAddress { get; set; }
    public string Telephone { get; set; }

    public Address()    {}

    public Address(string cep, string publicPlace, string complement, string neighborhood, string numberAddress, string telephone)
    {
        AddressId = CustomizedGuid.NewGuidCustomerId();
        Cep = cep;
        PublicPlace = publicPlace;
        Complement = complement;
        Neighborhood = neighborhood;
        NumberAddress = numberAddress;
        Telephone = telephone;
    }

    public Address(CustomizedGuid addressId, string cep, string publicPlace, string complement, string neighborhood, string numberAddress, string telephone)
    {
        AddressId = addressId;
        Cep = cep;
        PublicPlace = publicPlace;
        Complement = complement;
        Neighborhood = neighborhood;
        NumberAddress = numberAddress;
        Telephone = telephone;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}