using EnterpriseResourcePlanning.Api.Domain.Abstractions;
using EnterpriseResourcePlanning.Api.Domain.Structs;

namespace EnterpriseResourcePlanning.Api.Domain.Entities;

public class UserEnterprise : Entity, IDisposable
{
    public CustomizedGuid UsuarioId { get; set; }
    public User? User { get; set; }
    public CustomizedGuid EnterpriseId { get; set; }
    public Enterprise? Enterprise { get; set; }

    
    public UserEnterprise() 
    {
    }

   
    public UserEnterprise(CustomizedGuid usuarioId, CustomizedGuid enterpriseId)
    {
        UsuarioId = usuarioId;
        EnterpriseId = enterpriseId;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}