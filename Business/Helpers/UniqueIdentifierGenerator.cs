namespace Business.Helpers;

public abstract class UniqueIdentifierGenerator
{
    public static string Generate()
    {
        return Guid.NewGuid().ToString().Split('-')[0];
    }

}
