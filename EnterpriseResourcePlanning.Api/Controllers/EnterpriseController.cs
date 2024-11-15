﻿using EnterpriseResourcePlanning.Api.Applications.DTOs.Address;
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
    public async Task<ActionResult<IEnumerable<EnterpriseDTO>>> GetAllEnterprise([FromHeader] string customerId)
    {
        var enterprises = await _context.Enterprises
            .Where(e => e.CustomerId.Equals(CustomizedGuid.Parse(customerId)))
            .Include(e => e.Customer)
            .Include(e => e.Address)
            .ToListAsync();

        var listEnterpriseDTO = new List<EnterpriseDTO>();
        foreach (var enterprise in enterprises)
        {
            var enterpriseDTO = new EnterpriseDTO(CustomizedGuid.ParseCustomizedGuidToString(enterprise.EnterpriseId),
                enterprise.FirstName, enterprise.LastName, enterprise.CnpjCpf, enterprise.StateRegistration,
                new AddressDTO(CustomizedGuid.ParseCustomizedGuidToString(enterprise.AddressId), enterprise.Address.Cep,
                    enterprise.Address.PublicPlace, enterprise.Address.Complement, enterprise.Address.Neighborhood,
                    enterprise.Address.NumberAddress, enterprise.Address.Telephone));
            listEnterpriseDTO.Add(enterpriseDTO);
        }

        return Ok(listEnterpriseDTO);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EnterpriseDTO>> GetEnterpriseId(string id, [FromHeader] string customerId)
    {
        var enterprise = await _context.Enterprises.Where(e =>
                e.CustomerId.Equals(CustomizedGuid.Parse(customerId)) &&
                e.EnterpriseId.Equals(CustomizedGuid.Parse(id)))
            .Include(e => e.Customer)
            .Include(e => e.Address)
            .FirstOrDefaultAsync();


        return Ok(new EnterpriseDTO(CustomizedGuid.ParseCustomizedGuidToString(enterprise.EnterpriseId),
            enterprise.FirstName, enterprise.LastName, enterprise.CnpjCpf, enterprise.StateRegistration,
            new AddressDTO(CustomizedGuid.ParseCustomizedGuidToString(enterprise.AddressId), enterprise.Address.Cep,
                enterprise.Address.PublicPlace, enterprise.Address.Complement, enterprise.Address.Neighborhood,
                enterprise.Address.NumberAddress, enterprise.Address.Telephone)));
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

            var result = await _context.Enterprises
                .Where(e => e.EnterpriseId.Equals(enterprise.EnterpriseId))
                .Include(e => e.Customer)
                .Include(e => e.Address)
                .FirstOrDefaultAsync();


            return Ok(new EnterpriseDTO(CustomizedGuid.ParseCustomizedGuidToString(result.EnterpriseId),
                result.FirstName, result.LastName, result.CnpjCpf, result.StateRegistration,
                new AddressDTO(CustomizedGuid.ParseCustomizedGuidToString(result.AddressId), result.Address.Cep,
                    result.Address.PublicPlace, result.Address.Complement, result.Address.Neighborhood,
                    result.Address.NumberAddress, result.Address.Telephone)));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}