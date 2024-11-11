using EnterpriseResourcePlanning.Api.Domain.Abstractions;
using EnterpriseResourcePlanning.Api.Domain.Structs;

namespace EnterpriseResourcePlanning.Api.Domain.Entities;

public class Customer : Entity, IDisposable
{
    public CustomizedGuid CustomerId { get; private set; }
    public string Licenca { get; private set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public ICollection<Enterprise> Enterprises { get; set; } = new List<Enterprise>();

    public Customer(){}
    
    public Customer(string licenca, string name, string email)
    {
        CustomerId = CustomizedGuid.NewGuidCustomerId();
        Licenca = licenca;
        Name = name;
        Email = email;
    }

    public Customer(CustomizedGuid customerId, string licenca, string name, string email)
    {
        CustomerId = customerId;
        Licenca = licenca;
        Name = name;
        Email = email;
    }

    public void AddEnterprise(Enterprise empresa)
    {
        Enterprises.Add(empresa);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}