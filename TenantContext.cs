namespace MultitenantLab;

public class TenantContext : ITenantContext
{
    private readonly IHttpContextAccessor _accessor;

    public TenantContext(IHttpContextAccessor httpContextAccessor)
    {
        _accessor = httpContextAccessor;
    }

    public string? GetTenantId()
    {
        if (_accessor.HttpContext == null)
        {
            return null;
        }
        // 從HTTP上下文的路由中取得租户ID
        var canGet = _accessor.HttpContext.Request.RouteValues.TryGetValue("tenantId", out var tenantId);
        return canGet ? (string?)tenantId : null;
    }
}