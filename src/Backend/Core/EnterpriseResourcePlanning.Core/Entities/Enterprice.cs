using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseResourcePlanning.Core.Entities;

public sealed class Enterprice : IDisposable
{
    [Key]
    public Guid EnterpriseId { get; set; }
    public string FantasyName { get; set; } = string.Empty!;
    public string ReasonSocial { get; set; } = string.Empty!;
    public string CnpjCpf { get; set; } = string.Empty!;
    public string StateRegistration{ get; set; } = string.Empty!;
    public string Email { get; set; } = string.Empty!;


    [NotMapped]
    private bool _disposed = false;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~Enterprice()
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