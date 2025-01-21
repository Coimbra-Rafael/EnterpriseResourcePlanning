using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseResourcePlanning.Core.Entities;
public sealed class ConfigCustomers : IDisposable
{
    [Key]
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    
    
    [ForeignKey("CustomerId")]
    public Customers Customers { get; set; } = new Customers();
    

    [NotMapped]
    private bool _disposed = false;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~ConfigCustomers()
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

        _disposed = true;
    }
}
