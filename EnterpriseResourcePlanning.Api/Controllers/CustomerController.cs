using EnterpriseResourcePlanning.Api.Applications.DTOs.Customer;
using EnterpriseResourcePlanning.Api.Applications.DTOs.Enterprise;
using EnterpriseResourcePlanning.Api.Domain.Entities;
using EnterpriseResourcePlanning.Api.Domain.Structs;
using EnterpriseResourcePlanning.Api.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseResourcePlanning.Api.Controllers;

[ApiController]
[Route("/customer")]
public class CustomerController : ControllerBase
{
    private readonly ErpDbContext _context;

    public CustomerController(ErpDbContext context)
    {
        _context = context;
    }
    [HttpGet] 
    public async Task<ActionResult<IEnumerable<CustomerDTO>>> Get()
    {
        var customers = await _context.Customers.ToListAsync();
        var customersDTO = new List<CustomerDTO>();
        foreach (var customer in customers)
        {
                var customerDTO = new CustomerDTO(CustomizedGuid.ParseCustomizedGuidToString(customer.CustomerId), customer.Name, customer.Email, customer.CreateOn, customer.UpdateOn);
                customersDTO.Add(customerDTO);
        }

        return Ok(customersDTO);
        
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDTO>> GetCustomer(string id)
    {
        var idGuid = CustomizedGuid.Parse(id);
        
        var customer = await _context.Customers
            .Where(c => c.CustomerId.Equals(idGuid))
            .Include(c => c.Enterprises)
            .FirstOrDefaultAsync(c => c.CustomerId.Equals(idGuid));

        if (customer == null)
        {
            return NotFound();
        }

        var enterprisesDTO = customer.Enterprises.Where(e => e.CustomerId.Equals(CustomizedGuid.Parse(id))).Select(enterprise => new EnterpriseDTO(
            enterprise.FirstName,
            enterprise.LastName,
            enterprise.CnpjCpf,
            enterprise.StateRegistration
        )).ToList();

        var customerDTO = new CustomerDTO(
            CustomizedGuid.ParseCustomizedGuidToString(customer.CustomerId),
            customer.Name,
            customer.Email,
            customer.CreateOn,
            customer.UpdateOn,
            enterprisesDTO
        );

        return Ok(customerDTO);
    }


    [HttpPost]
    public async Task<ActionResult<Customer>> Post(CreateCustomerDTO createCustomerDto)
    {
        try
        {
            using (var customer = new Customer(createCustomerDto.Licenca, createCustomerDto.Name, createCustomerDto.Email))
            {
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
                return await _context.Customers.Where( c=> c.CustomerId.Equals(customer.CustomerId)).FirstOrDefaultAsync();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
}