namespace ChickAndPaddy;

public interface IProfileService
{
    Task<bool> CheckRelationshipAsync();
    Task SetRelationshipAsync(bool paired);
}

