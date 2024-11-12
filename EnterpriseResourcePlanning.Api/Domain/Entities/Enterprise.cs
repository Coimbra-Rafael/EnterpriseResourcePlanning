using EnterpriseResourcePlanning.Api.Domain.Structs;

namespace EnterpriseResourcePlanning.Api.Domain.Entities;

public class Enterprise : IDisposable
{
    public CustomizedGuid CustomerId { get; set; }
    public Customer Customer { get; set; }
    public CustomizedGuid EnterpriseId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CnpjCpf { get; set; }
    public string StateRegistration { get; set; }
    public CustomizedGuid AddressId { get; set; }
    public Address Address { get; set; }
    

    public Enterprise()
    {
        
    }
    
    public Enterprise(CustomizedGuid customerId, string firstName, string lastName, string cnpjCpf, string stateRegistration, CustomizedGuid addressId, Address address, Customer customer)
    {
        CustomerId = customerId;
        EnterpriseId = CustomizedGuid.NewGuidCustomerId();
        FirstName = firstName;
        LastName = lastName;
        CnpjCpf = cnpjCpf;
        StateRegistration = stateRegistration;
        AddressId = addressId;
        Address = address;
        Customer = customer;
    }

    
    public Enterprise(CustomizedGuid customerId, CustomizedGuid enterpriseId, string firstName, string lastName, string cnpjCpf, string stateRegistration, CustomizedGuid addressId, Address address, Customer customer)
    {
        CustomerId = customerId;
        EnterpriseId = enterpriseId;
        FirstName = firstName;
        LastName = lastName;
        CnpjCpf = cnpjCpf;
        StateRegistration = stateRegistration;
        AddressId = addressId;
        Address = address;
        Customer = customer;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}