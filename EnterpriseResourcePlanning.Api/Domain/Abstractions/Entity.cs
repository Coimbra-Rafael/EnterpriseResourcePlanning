namespace EnterpriseResourcePlanning.Api.Domain.Abstractions;

public abstract class Entity
{
    public DateTime CreateOn { get; set; }
    public DateTime UpdateOn { get; set; }

    protected Entity()
    {
        CreateOn = DateTime.Now;
        UpdateOn = DateTime.Now;
    }
    
    protected Entity(DateTime updateOn)
    {
        UpdateOn = updateOn;
    }
}