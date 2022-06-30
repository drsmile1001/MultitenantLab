namespace MultitenantLab;

public interface ITenantContext
{
    string? GetTenantId();
}
