using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseResourcePlanning.Core.Entities;

public sealed class Address : IDisposable
{
    [Key]
    public Guid AddressId { get; set; }
    public string Street { get; set; } = string.Empty!;
    public string Number { get; set; } = string.Empty!;
    public string Neighborhood { get; set; } = string.Empty!;
    public string City { get; set; } = string.Empty!;
    public string State { get; set; } = string.Empty!;
    public string Country { get; set; } = "Brazil";
    public string ZipCode { get; set; } = string.Empty!;
    public string Complement { get; set; } = string.Empty!;
    public string Reference { get; set; } = string.Empty!;


    [NotMapped]
    private bool _disposed = false;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~Address()
    {
        Dispose(false);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed) return;

        if (disposing)
        {
           GC.SuppressFinalize(this);
        }

        // Libera recursos não gerenciados aqui

        _disposed = true;
    }
}