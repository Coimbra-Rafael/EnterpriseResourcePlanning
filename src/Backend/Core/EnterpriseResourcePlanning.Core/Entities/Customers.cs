using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseResourcePlanning.Core.Entities;

public sealed class Customers : IDisposable
{
    [Key]
    public Guid Id { get; set; }

    public string License { get; set; } = string.Empty!;
    public string FantasyName { get; set; } = string.Empty!;

    [NotMapped]
    private bool _disposed = false;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~Customers()
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