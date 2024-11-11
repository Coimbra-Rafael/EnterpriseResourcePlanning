using EnterpriseResourcePlanning.Api.Applications.DTOs.Enterprise;
using EnterpriseResourcePlanning.Api.Domain.Entities;
using EnterpriseResourcePlanning.Api.Domain.Structs;
using EnterpriseResourcePlanning.Api.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseResourcePlanning.Api.Controllers;

[ApiController]
[Route("/enterprise")]
public class EnterpriseController : ControllerBase
{
    private readonly ErpDbContext _context;

    public EnterpriseController(ErpDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Enterprise>>> Get([FromHeader] string customerId)
    {
        return Ok(await _context.Enterprises.Where(e => e.CustomerId.Equals(CustomizedGuid.Parse(customerId)))
            .ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Enterprise>> Get([FromHeader] string id, [FromQuery] string customerId)
    {
        var enterprise = await _context.Enterprises.Where(e =>
                e.CustomerId.Equals(CustomizedGuid.Parse(customerId)) &&
                e.EnterpriseId.Equals(CustomizedGuid.Parse(id))).Include(e => e.Address)
            .FirstOrDefaultAsync();

        return Ok(enterprise);
    }

    [HttpPost]
    public async Task<ActionResult<Enterprise>> Post([FromHeader] string idCustomer,
        [FromBody] CreateEnterpriseDTO enterpriseDto)
    {
        try
        {
            using var address = new Address();
            using var enterprise = new Enterprise();
            
            address.AddressId = CustomizedGuid.NewGuidCustomerId();
            address.Cep = enterpriseDto.CreateAddressDto.Cep;
            address.PublicPlace = enterpriseDto.CreateAddressDto.PublicPlace;
            address.NumberAddress = enterpriseDto.CreateAddressDto.NumberAddress;
            address.Complement = enterpriseDto.CreateAddressDto.Complement;
            address.Neighborhood = enterpriseDto.CreateAddressDto.Neighborhood;
            address.Telephone = enterpriseDto.CreateAddressDto.Telephone;
            enterprise.EnterpriseId = CustomizedGuid.NewGuidCustomerId();
            enterprise.CustomerId = CustomizedGuid.Parse(idCustomer);
            enterprise.FirstName = enterpriseDto.FirstName;
            enterprise.LastName = enterpriseDto.LastName;
            enterprise.CnpjCpf = enterpriseDto.CnpjCpf;
            enterprise.StateRegistration = enterpriseDto.StateRegistration;
            enterprise.AddressId = address.AddressId;
            
            await _context.Addresses.AddAsync(address);
            await _context.Enterprises.AddAsync(enterprise);
            await _context.SaveChangesAsync();

            var result = _context.Enterprises.Where(e => e.EnterpriseId.Equals(enterprise.EnterpriseId)).FirstOrDefaultAsync();
                
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}