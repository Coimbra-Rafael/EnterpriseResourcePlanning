namespace EnterpriseResourcePlanning.Api.Domain.Structs;

public readonly record struct CustomizedGuid(Guid Values)
{
    public static CustomizedGuid Empty => new (Guid.Empty);
    public static CustomizedGuid NewGuidCustomerId() => new(Guid.NewGuid());

    public static bool TryParse(string s, out CustomizedGuid result)
    {
        if (Guid.TryParse(s, out var guidResult))
        {
            result = new CustomizedGuid(guidResult);
            return true;
        }

        result = Empty;
        return false;
    }
    public static CustomizedGuid Parse(string s) 
    {
        return new CustomizedGuid(Guid.Parse(s));
    }

    public static string ParseCustomizedGuidToString(CustomizedGuid customizedGuid)
    {
        return customizedGuid.Values.ToString();
    }
}