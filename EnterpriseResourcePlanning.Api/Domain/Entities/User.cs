using EnterpriseResourcePlanning.Api.Domain.Abstractions;
using EnterpriseResourcePlanning.Api.Domain.Structs;

namespace EnterpriseResourcePlanning.Api.Domain.Entities;

public class User : Entity, IDisposable
{
    public CustomizedGuid CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public CustomizedGuid UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
    public ICollection<UserEnterprise>? UsersEnterprises { get; set; }
    
    
    public User() 
    {
        UsersEnterprises = new List<UserEnterprise>(); 
    }

    
    public User(CustomizedGuid customerId, CustomizedGuid userId, string? firstName, string? lastName, string? username, string? password, string? confirmPassword)
    {
        CustomerId = customerId;
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Password = password;
        ConfirmPassword = confirmPassword;
        UsersEnterprises = new List<UserEnterprise>(); 
    }

    public User(CustomizedGuid customerId, CustomizedGuid userId, string? firstName, string? lastName, string? username, string? password, string? confirmPassword, ICollection<UserEnterprise>? usersEnterprises)
    {
        CustomerId = customerId;
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Password = password;
        ConfirmPassword = confirmPassword;
        UsersEnterprises = usersEnterprises ?? new List<UserEnterprise>();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}